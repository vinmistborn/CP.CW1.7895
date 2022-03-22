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
    public partial class SwipesAndTerminals : Form, IWebServiceCallback
    {
        TerminalRepository terminalRepo = new TerminalRepository();
        List<Terminal> terminals = new List<Terminal>();

        public SwipesAndTerminals()
        {
            InitializeComponent();
            terminals = terminalRepo.GetTerminals();

            appTimer.Interval = 300;
            appTimer.Start();

            dgvTerminals.DefaultCellStyle.SelectionBackColor = dgvTerminals.DefaultCellStyle.BackColor;
            dgvTerminals.DefaultCellStyle.SelectionForeColor = dgvTerminals.DefaultCellStyle.ForeColor;

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            ControlBox = false;
            btnStart.Enabled = false;
            dgvTerminals.DataSource = terminals;
            InstanceContext instanceContext = new InstanceContext(this);
            IWebService webServiceClient = new WebServiceClient(instanceContext);
            await webServiceClient.StartCollectingSwipesAsync();           
            UpdateTerminals();
            btnStart.Enabled = true;
            ControlBox = true;
        }

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

        private void UpdateTerminals()
        {
            foreach (var terminal in terminals)
            {
                terminal.Status = "Waiting";
                terminalRepo.Update(terminal);
            }
        }

        private void appTimer_Tick(object sender, EventArgs e)
        {
            BlinkCell();
        }

        public void GetStatus(Terminal[] updatedTerminals)
        {
            dgvTerminals.DataSource = updatedTerminals;
            BlinkCell();
        }
    }
}
