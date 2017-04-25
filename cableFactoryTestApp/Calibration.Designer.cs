namespace cableFactoryTestApp
{
    partial class Calibration
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelLoad = new System.Windows.Forms.Label();
            this.labelBoxLoadCell = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.buttonCalibrate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(99, 179);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 33);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.Location = new System.Drawing.Point(12, 36);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(128, 17);
            this.labelLoad.TabIndex = 1;
            this.labelLoad.Text = "Load Cell Reading:";
            // 
            // labelBoxLoadCell
            // 
            this.labelBoxLoadCell.BackColor = System.Drawing.SystemColors.Window;
            this.labelBoxLoadCell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBoxLoadCell.Location = new System.Drawing.Point(170, 36);
            this.labelBoxLoadCell.Name = "labelBoxLoadCell";
            this.labelBoxLoadCell.Size = new System.Drawing.Size(100, 23);
            this.labelBoxLoadCell.TabIndex = 26;
            this.labelBoxLoadCell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(12, 80);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(121, 17);
            this.labelOffset.TabIndex = 27;
            this.labelOffset.Text = "Offset (<+/-><#>):";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(170, 80);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(100, 22);
            this.textBoxOffset.TabIndex = 28;
            this.textBoxOffset.Text = "+0";
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.Location = new System.Drawing.Point(70, 131);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(150, 26);
            this.buttonCalibrate.TabIndex = 29;
            this.buttonCalibrate.Text = "Calibrate";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            // 
            // Calibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 220);
            this.Controls.Add(this.buttonCalibrate);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.labelBoxLoadCell);
            this.Controls.Add(this.labelLoad);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Calibration";
            this.Text = "Calibration";
            this.Load += new System.EventHandler(this.Calibration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.Label labelBoxLoadCell;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Button buttonCalibrate;
    }
}