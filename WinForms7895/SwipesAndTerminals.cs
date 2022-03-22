using Domain.Entities;
using Infrastructure.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using WinForms7895.WebServicerReference;

namespace WinForms7895
{
    //IWebServiceCallback - inherited to define the actual implementation
    //of a callback Method (GetStatus) of WebService
    public partial class SwipesAndTerminals : Form, IWebServiceCallback
    {
        /*----Initializing the necessary objects----*/
        TerminalRepository terminalRepo = new TerminalRepository();
        List<Terminal> terminals = new List<Terminal>();

        public SwipesAndTerminals()
        {
            InitializeComponent();
            terminals = terminalRepo.GetTerminals();

            //Setting timer settings to blink cells
            appTimer.Interval = 300;
            appTimer.Start();

            //Setting the default background colors of data grid view cells
            dgvTerminals.DefaultCellStyle.SelectionBackColor = dgvTerminals.DefaultCellStyle.BackColor;
            dgvTerminals.DefaultCellStyle.SelectionForeColor = dgvTerminals.DefaultCellStyle.ForeColor;

        }

        /// <summary>
        /// Event handler (method) for a start button click
        /// </summary>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            //when a user clicks the button,
            //both exit and the button will be disabled 
            //until the collection of swipes are fully executed
            ControlBox = false;
            btnStart.Enabled = false;

            //assigning terminals to data grid view
            dgvTerminals.DataSource = terminals;

            //creating an instance of webservice to include callback method implementation
            InstanceContext instanceContext = new InstanceContext(this);
            //creating an instance of webservice client and passing the instance context
            IWebService webServiceClient = new WebServiceClient(instanceContext);
            //executing the collection of swipes process asynchronously
            await webServiceClient.StartCollectingSwipesAsync();           
            
            //once the collecting ends, the status of terminals will be updated to waiting
            UpdateTerminals();
            //once the terminals update finishes, enable the start and exit buttons
            btnStart.Enabled = true;
            ControlBox = true;
        }


        /// <summary>
        /// Modifies the color cells to simulate a blink effect
        /// </summary>
        private void BlinkCell()
        {
            for (int i = 0; i < dgvTerminals.Rows.Count; i++)
            {
                var currentCell = dgvTerminals.Rows[i].Cells[1];

                if ((string)currentCell.Value == "InProcess")
                {
                    currentCell.Style.BackColor =
                                    currentCell.Style.BackColor != Color.Yellow
                                                                ? Color.Yellow : Color.White;
                }
                else if ((string)currentCell.Value == "Waiting")
                {
                    currentCell.Style.BackColor =
                                    currentCell.Style.BackColor == Color.White
                                                                ? Color.LightPink : Color.White;
                }
                else
                {
                    currentCell.Style.BackColor = Color.Turquoise;                                                                
                }
            }
        }

        /// <summary>
        /// Updates terminals status
        /// </summary>
        private void UpdateTerminals()
        {
            foreach (var terminal in terminals)
            {
                terminal.Status = "Waiting";
                terminalRepo.Update(terminal);
            }
        }

        //Timer event to execute blink effect
        private void appTimer_Tick(object sender, EventArgs e)
        {
            BlinkCell();
        }

        /// <summary>
        /// The implementation of Callback method
        /// Modifies the datagrid view with updated terminals
        /// </summary>
        /// <param name="updatedTerminals">terminals with updated status</param>
        public void GetStatus(Terminal[] updatedTerminals)
        {
            dgvTerminals.DataSource = updatedTerminals;
            BlinkCell();
        }
    }
}
