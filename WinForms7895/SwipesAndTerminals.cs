using Domain.Entities;
using Infrastructure.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using WinForms7895.WebServiceReference;

namespace WinForms7895
{
    //IWebServiceCallback - inherited to define the actual implementation
    //of a callback Method (GetStatus) of WebService
    public partial class SwipesAndTerminals : Form, IWebServiceCallback
    {
        /*----Initializing the necessary objects----*/
        TerminalRepository terminalRepo = new TerminalRepository();
        SwipeRepository swipeRepo = new SwipeRepository();
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
            DeleteSwipes();

            //when a user clicks the button,
            //buttons will be disabled 
            //until the collection of swipes are fully executed
            DisableControls();

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
            //once the terminals update finishes, enable the buttons
            EnableControls();
        }


        /// <summary>
        /// event handler for *Show Swipes* button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwipes_Click(object sender, EventArgs e)
        {
            var swipes = swipeRepo.GetSwipes();
            dgvSwipes.DataSource = swipes;
        }

        
        /// <summary>
        /// Enables buttons for a click event
        /// </summary>
        private void EnableControls()
        {
            btnStart.Enabled = true;
            btnSwipes.Enabled = true;
            ControlBox = true;
        }

        /// <summary>
        /// Disables the buttons from clicking event
        /// </summary>
        private void DisableControls()
        {
            ControlBox = false;
            btnStart.Enabled = false;
            btnSwipes.Enabled = false;
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


        /// <summary>
        /// Deletes swipes from the database
        /// </summary>
        private void DeleteSwipes()
        {
            var swipes = swipeRepo.GetSwipes();
            swipeRepo.DeleteSwipes(swipes);
        }
    }
}
