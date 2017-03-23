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
            this.labelForceApplied = new System.Windows.Forms.Label();
            this.testSetupCancelBtn = new System.Windows.Forms.Button();
            this.testSetupOkBtn = new System.Windows.Forms.Button();
            this.labelCableType = new System.Windows.Forms.Label();
            this.numericUpDownTestLoops = new System.Windows.Forms.NumericUpDown();
            this.labelTestRepeat = new System.Windows.Forms.Label();
            this.numericUpDownForce = new System.Windows.Forms.NumericUpDown();
            this.textBoxCableType = new System.Windows.Forms.TextBox();
            this.labelTestDuration = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelRestDuration = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestLoops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForce)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.labelRestDuration);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.labelTestDuration);
            this.groupBox2.Controls.Add(this.textBoxCableType);
            this.groupBox2.Controls.Add(this.numericUpDownForce);
            this.groupBox2.Controls.Add(this.labelForceApplied);
            this.groupBox2.Controls.Add(this.testSetupCancelBtn);
            this.groupBox2.Controls.Add(this.testSetupOkBtn);
            this.groupBox2.Controls.Add(this.labelCableType);
            this.groupBox2.Controls.Add(this.numericUpDownTestLoops);
            this.groupBox2.Controls.Add(this.labelTestRepeat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 376);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Parameters";
            // 
            // labelForceApplied
            // 
            this.labelForceApplied.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForceApplied.Location = new System.Drawing.Point(8, 120);
            this.labelForceApplied.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelForceApplied.Name = "labelForceApplied";
            this.labelForceApplied.Size = new System.Drawing.Size(174, 23);
            this.labelForceApplied.TabIndex = 7;
            this.labelForceApplied.Text = "Force to be Applied (kg) : ";
            this.labelForceApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // testSetupCancelBtn
            // 
            this.testSetupCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.testSetupCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSetupCancelBtn.Location = new System.Drawing.Point(236, 324);
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
            this.testSetupOkBtn.Location = new System.Drawing.Point(54, 324);
            this.testSetupOkBtn.Name = "testSetupOkBtn";
            this.testSetupOkBtn.Size = new System.Drawing.Size(122, 46);
            this.testSetupOkBtn.TabIndex = 5;
            this.testSetupOkBtn.Text = "OK";
            this.testSetupOkBtn.UseVisualStyleBackColor = true;
            this.testSetupOkBtn.Click += new System.EventHandler(this.testSetupOkBtn_Click);
            // 
            // labelCableType
            // 
            this.labelCableType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCableType.Location = new System.Drawing.Point(8, 20);
            this.labelCableType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelCableType.Name = "labelCableType";
            this.labelCableType.Size = new System.Drawing.Size(169, 32);
            this.labelCableType.TabIndex = 3;
            this.labelCableType.Text = "Cable Type/Description :";
            this.labelCableType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownTestLoops
            // 
            this.numericUpDownTestLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTestLoops.Location = new System.Drawing.Point(274, 265);
            this.numericUpDownTestLoops.Name = "numericUpDownTestLoops";
            this.numericUpDownTestLoops.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownTestLoops.TabIndex = 2;
            // 
            // labelTestRepeat
            // 
            this.labelTestRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestRepeat.Location = new System.Drawing.Point(8, 260);
            this.labelTestRepeat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTestRepeat.Name = "labelTestRepeat";
            this.labelTestRepeat.Size = new System.Drawing.Size(174, 32);
            this.labelTestRepeat.TabIndex = 1;
            this.labelTestRepeat.Text = "Number of Test Loops :  ";
            this.labelTestRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownForce
            // 
            this.numericUpDownForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownForce.Location = new System.Drawing.Point(274, 119);
            this.numericUpDownForce.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownForce.Name = "numericUpDownForce";
            this.numericUpDownForce.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownForce.TabIndex = 8;
            // 
            // textBoxCableType
            // 
            this.textBoxCableType.Location = new System.Drawing.Point(11, 55);
            this.textBoxCableType.Multiline = true;
            this.textBoxCableType.Name = "textBoxCableType";
            this.textBoxCableType.Size = new System.Drawing.Size(383, 49);
            this.textBoxCableType.TabIndex = 9;
            // 
            // labelTestDuration
            // 
            this.labelTestDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestDuration.Location = new System.Drawing.Point(8, 158);
            this.labelTestDuration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTestDuration.Name = "labelTestDuration";
            this.labelTestDuration.Size = new System.Drawing.Size(167, 23);
            this.labelTestDuration.TabIndex = 10;
            this.labelTestDuration.Text = "Test Duration (mm:ss) :";
            this.labelTestDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(274, 157);
            this.dateTimePicker1.MaxDate = new System.DateTime(2007, 12, 6, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Value = new System.DateTime(2007, 12, 6, 0, 0, 0, 0);
            // 
            // labelRestDuration
            // 
            this.labelRestDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestDuration.Location = new System.Drawing.Point(8, 194);
            this.labelRestDuration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelRestDuration.Name = "labelRestDuration";
            this.labelRestDuration.Size = new System.Drawing.Size(167, 23);
            this.labelRestDuration.TabIndex = 12;
            this.labelRestDuration.Text = "Rest Duration (mm:ss) :";
            this.labelRestDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(274, 194);
            this.dateTimePicker2.MaxDate = new System.DateTime(2007, 12, 6, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker2.TabIndex = 13;
            this.dateTimePicker2.Value = new System.DateTime(2007, 12, 6, 0, 0, 0, 0);
            // 
            // TestSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 400);
            this.Controls.Add(this.groupBox2);
            this.Name = "TestSetup";
            this.Text = "Test Setup";
            this.Load += new System.EventHandler(this.TestSetup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestLoops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button testSetupCancelBtn;
        private System.Windows.Forms.Button testSetupOkBtn;
        private System.Windows.Forms.Label labelCableType;
        private System.Windows.Forms.NumericUpDown numericUpDownTestLoops;
        private System.Windows.Forms.Label labelTestRepeat;
        private System.Windows.Forms.Label labelForceApplied;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelTestDuration;
        private System.Windows.Forms.TextBox textBoxCableType;
        private System.Windows.Forms.NumericUpDown numericUpDownForce;
        private System.Windows.Forms.Label labelRestDuration;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}