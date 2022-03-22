
namespace WinForms7895
{
    partial class SwipesAndTerminals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTerminals = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.appTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTerminals
            // 
            this.dgvTerminals.AllowUserToAddRows = false;
            this.dgvTerminals.AllowUserToDeleteRows = false;
            this.dgvTerminals.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTerminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminals.Enabled = false;
            this.dgvTerminals.EnableHeadersVisualStyles = false;
            this.dgvTerminals.Location = new System.Drawing.Point(13, 13);
            this.dgvTerminals.MultiSelect = false;
            this.dgvTerminals.Name = "dgvTerminals";
            this.dgvTerminals.ReadOnly = true;
            this.dgvTerminals.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTerminals.Size = new System.Drawing.Size(240, 327);
            this.dgvTerminals.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 364);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // appTimer
            // 
            this.appTimer.Tick += new System.EventHandler(this.appTimer_Tick);
            // 
            // SwipesAndTerminals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 406);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvTerminals);
            this.Name = "SwipesAndTerminals";
            this.Text = "Swipes and Terminals";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTerminals;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer appTimer;
    }
}

