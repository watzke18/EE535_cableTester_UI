namespace cableFactoryTestApp
{
    partial class TestSetup
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.testSetupCancelBtn = new System.Windows.Forms.Button();
            this.testSetupOkBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelCableType = new System.Windows.Forms.Label();
            this.numericUpDownTestLoops = new System.Windows.Forms.NumericUpDown();
            this.labelTestRepeat = new System.Windows.Forms.Label();
            this.labelForceApplied = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestLoops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.labelForceApplied);
            this.groupBox2.Controls.Add(this.testSetupCancelBtn);
            this.groupBox2.Controls.Add(this.testSetupOkBtn);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.labelCableType);
            this.groupBox2.Controls.Add(this.numericUpDownTestLoops);
            this.groupBox2.Controls.Add(this.labelTestRepeat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 340);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Parameters";
            // 
            // testSetupCancelBtn
            // 
            this.testSetupCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.testSetupCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSetupCancelBtn.Location = new System.Drawing.Point(240, 288);
            this.testSetupCancelBtn.Name = "testSetupCancelBtn";
            this.testSetupCancelBtn.Size = new System.Drawing.Size(122, 46);
            this.testSetupCancelBtn.TabIndex = 6;
            this.testSetupCancelBtn.Text = "Cancel";
            this.testSetupCancelBtn.UseVisualStyleBackColor = true;
            this.testSetupCancelBtn.Click += new System.EventHandler(this.testSetupCancelBtn_Click);
            // 
            // testSetupOkBtn
            // 
            this.testSetupOkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.testSetupOkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSetupOkBtn.Location = new System.Drawing.Point(55, 288);
            this.testSetupOkBtn.Name = "testSetupOkBtn";
            this.testSetupOkBtn.Size = new System.Drawing.Size(122, 46);
            this.testSetupOkBtn.TabIndex = 5;
            this.testSetupOkBtn.Text = "OK";
            this.testSetupOkBtn.UseVisualStyleBackColor = true;
            this.testSetupOkBtn.Click += new System.EventHandler(this.testSetupOkBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(212, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 26);
            this.comboBox1.TabIndex = 4;
            // 
            // labelCableType
            // 
            this.labelCableType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCableType.Location = new System.Drawing.Point(8, 37);
            this.labelCableType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCableType.Name = "labelCableType";
            this.labelCableType.Size = new System.Drawing.Size(115, 32);
            this.labelCableType.TabIndex = 3;
            this.labelCableType.Text = "Cable Type :";
            this.labelCableType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownTestLoops
            // 
            this.numericUpDownTestLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTestLoops.Location = new System.Drawing.Point(266, 228);
            this.numericUpDownTestLoops.Name = "numericUpDownTestLoops";
            this.numericUpDownTestLoops.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownTestLoops.TabIndex = 2;
            // 
            // labelTestRepeat
            // 
            this.labelTestRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestRepeat.Location = new System.Drawing.Point(8, 220);
            this.labelTestRepeat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTestRepeat.Name = "labelTestRepeat";
            this.labelTestRepeat.Size = new System.Drawing.Size(203, 32);
            this.labelTestRepeat.TabIndex = 1;
            this.labelTestRepeat.Text = "Number of Test Loops :  ";
            this.labelTestRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelForceApplied
            // 
            this.labelForceApplied.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForceApplied.Location = new System.Drawing.Point(8, 86);
            this.labelForceApplied.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelForceApplied.Name = "labelForceApplied";
            this.labelForceApplied.Size = new System.Drawing.Size(169, 32);
            this.labelForceApplied.TabIndex = 7;
            this.labelForceApplied.Text = "Force Applied (kg) :  ";
            this.labelForceApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(266, 91);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 24);
            this.numericUpDown1.TabIndex = 8;
            // 
            // TestSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 364);
            this.Controls.Add(this.groupBox2);
            this.Name = "TestSetup";
            this.Text = "Test Setup";
            this.Load += new System.EventHandler(this.TestSetup_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestLoops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button testSetupCancelBtn;
        private System.Windows.Forms.Button testSetupOkBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelCableType;
        private System.Windows.Forms.NumericUpDown numericUpDownTestLoops;
        private System.Windows.Forms.Label labelTestRepeat;
        private System.Windows.Forms.Label labelForceApplied;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}