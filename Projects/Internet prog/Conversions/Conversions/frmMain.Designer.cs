namespace Conversions
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstConversions = new System.Windows.Forms.ListBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnManageConversions = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValueToConvert = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstConversions
            // 
            this.lstConversions.FormattingEnabled = true;
            this.lstConversions.ItemHeight = 15;
            this.lstConversions.Location = new System.Drawing.Point(32, 85);
            this.lstConversions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstConversions.Name = "lstConversions";
            this.lstConversions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstConversions.Size = new System.Drawing.Size(168, 169);
            this.lstConversions.TabIndex = 1;
            this.lstConversions.Tag = "Conversions";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(230, 25);
            this.lstResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstResults.Name = "lstResults";
            this.lstResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstResults.Size = new System.Drawing.Size(289, 229);
            this.lstResults.TabIndex = 2;
            this.lstResults.TabStop = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(32, 269);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(78, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Con&vert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnManageConversions
            // 
            this.btnManageConversions.Location = new System.Drawing.Point(230, 269);
            this.btnManageConversions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageConversions.Name = "btnManageConversions";
            this.btnManageConversions.Size = new System.Drawing.Size(162, 23);
            this.btnManageConversions.TabIndex = 4;
            this.btnManageConversions.Text = "&Manage Conversions";
            this.btnManageConversions.UseVisualStyleBackColor = true;
            this.btnManageConversions.Click += new System.EventHandler(this.btnManageConversions_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(439, 269);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Value to convert:";
            // 
            // txtValueToConvert
            // 
            this.txtValueToConvert.Location = new System.Drawing.Point(32, 41);
            this.txtValueToConvert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValueToConvert.Name = "txtValueToConvert";
            this.txtValueToConvert.Size = new System.Drawing.Size(106, 23);
            this.txtValueToConvert.TabIndex = 0;
            this.txtValueToConvert.Tag = "Value to convert";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Conversions";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(120, 269);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(560, 306);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValueToConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageConversions);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lstConversions);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversions";
            this.Load += new System.EventHandler(this.frmConversions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstConversions;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnManageConversions;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValueToConvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
    }
}

