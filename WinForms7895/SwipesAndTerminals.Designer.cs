
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
            this.lblTerminal = new System.Windows.Forms.Label();
            this.lblSwipe = new System.Windows.Forms.Label();
            this.btnSwipes = new System.Windows.Forms.Button();
            this.dgvSwipes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSwipes)).BeginInit();
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
            this.dgvTerminals.Location = new System.Drawing.Point(13, 41);
            this.dgvTerminals.MultiSelect = false;
            this.dgvTerminals.Name = "dgvTerminals";
            this.dgvTerminals.ReadOnly = true;
            this.dgvTerminals.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTerminals.Size = new System.Drawing.Size(240, 327);
            this.dgvTerminals.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 386);
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
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Location = new System.Drawing.Point(13, 13);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(52, 13);
            this.lblTerminal.TabIndex = 2;
            this.lblTerminal.Text = "Terminals";
            // 
            // lblSwipe
            // 
            this.lblSwipe.AutoSize = true;
            this.lblSwipe.Location = new System.Drawing.Point(292, 13);
            this.lblSwipe.Name = "lblSwipe";
            this.lblSwipe.Size = new System.Drawing.Size(41, 13);
            this.lblSwipe.TabIndex = 2;
            this.lblSwipe.Text = "Swipes";
            // 
            // btnSwipes
            // 
            this.btnSwipes.Location = new System.Drawing.Point(295, 386);
            this.btnSwipes.Name = "btnSwipes";
            this.btnSwipes.Size = new System.Drawing.Size(88, 23);
            this.btnSwipes.TabIndex = 3;
            this.btnSwipes.Text = "Show Swipes";
            this.btnSwipes.UseVisualStyleBackColor = true;
            this.btnSwipes.Click += new System.EventHandler(this.btnSwipes_Click);
            // 
            // dgvSwipes
            // 
            this.dgvSwipes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSwipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSwipes.Location = new System.Drawing.Point(295, 41);
            this.dgvSwipes.Name = "dgvSwipes";
            this.dgvSwipes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSwipes.Size = new System.Drawing.Size(552, 327);
            this.dgvSwipes.TabIndex = 4;
            // 
            // SwipesAndTerminals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 437);
            this.Controls.Add(this.dgvSwipes);
            this.Controls.Add(this.btnSwipes);
            this.Controls.Add(this.lblSwipe);
            this.Controls.Add(this.lblTerminal);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvTerminals);
            this.Name = "SwipesAndTerminals";
            this.Text = "Swipes and Terminals";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSwipes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTerminals;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer appTimer;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.Label lblSwipe;
        private System.Windows.Forms.Button btnSwipes;
        private System.Windows.Forms.DataGridView dgvSwipes;
    }
}

