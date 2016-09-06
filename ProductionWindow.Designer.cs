namespace AdHOC_Automation_APP
{
    partial class ProductionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionWindow));
            this.processButton = new System.Windows.Forms.Button();
            this.suppliedButton = new System.Windows.Forms.Button();
            this.prfHTML = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pwOrDelimTextBox = new System.Windows.Forms.TextBox();
            this.pwOrDelimLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.genLookupButton = new System.Windows.Forms.Button();
            this.combineButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.worksheetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(12, 12);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(98, 51);
            this.processButton.TabIndex = 0;
            this.processButton.Text = "MasterApp Finished Processing";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // suppliedButton
            // 
            this.suppliedButton.Location = new System.Drawing.Point(116, 12);
            this.suppliedButton.Name = "suppliedButton";
            this.suppliedButton.Size = new System.Drawing.Size(98, 52);
            this.suppliedButton.TabIndex = 1;
            this.suppliedButton.Text = "Get New Supplied Files";
            this.suppliedButton.UseVisualStyleBackColor = true;
            this.suppliedButton.Click += new System.EventHandler(this.suppliedButton_Click);
            // 
            // prfHTML
            // 
            this.prfHTML.Location = new System.Drawing.Point(220, 12);
            this.prfHTML.Name = "prfHTML";
            this.prfHTML.Size = new System.Drawing.Size(98, 52);
            this.prfHTML.TabIndex = 2;
            this.prfHTML.Text = "Generate New PRF HTML";
            this.prfHTML.UseVisualStyleBackColor = true;
            this.prfHTML.Click += new System.EventHandler(this.prfHTML_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(202, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // fileComboBox
            // 
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(88, 199);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(229, 21);
            this.fileComboBox.TabIndex = 7;
            this.fileComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data Source:";
            // 
            // pwOrDelimTextBox
            // 
            this.pwOrDelimTextBox.Location = new System.Drawing.Point(88, 233);
            this.pwOrDelimTextBox.Name = "pwOrDelimTextBox";
            this.pwOrDelimTextBox.Size = new System.Drawing.Size(229, 20);
            this.pwOrDelimTextBox.TabIndex = 11;
            this.pwOrDelimTextBox.Leave += new System.EventHandler(this.passwordDoneEntering);
            // 
            // pwOrDelimLabel
            // 
            this.pwOrDelimLabel.AutoSize = true;
            this.pwOrDelimLabel.Location = new System.Drawing.Point(26, 237);
            this.pwOrDelimLabel.Name = "pwOrDelimLabel";
            this.pwOrDelimLabel.Size = new System.Drawing.Size(56, 13);
            this.pwOrDelimLabel.TabIndex = 12;
            this.pwOrDelimLabel.Text = "Password:";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 146);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(98, 23);
            this.convertButton.TabIndex = 13;
            this.convertButton.Text = "Convert To CSV";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // genLookupButton
            // 
            this.genLookupButton.Location = new System.Drawing.Point(219, 111);
            this.genLookupButton.Name = "genLookupButton";
            this.genLookupButton.Size = new System.Drawing.Size(98, 39);
            this.genLookupButton.TabIndex = 14;
            this.genLookupButton.Text = "Generate Lookup Table";
            this.genLookupButton.UseVisualStyleBackColor = true;
            this.genLookupButton.Click += new System.EventHandler(this.genLookupButton_Click);
            // 
            // combineButton
            // 
            this.combineButton.Location = new System.Drawing.Point(219, 162);
            this.combineButton.Name = "combineButton";
            this.combineButton.Size = new System.Drawing.Size(98, 23);
            this.combineButton.TabIndex = 15;
            this.combineButton.Text = "Combine Data";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "OR";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(220, 76);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(97, 23);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // worksheetLabel
            // 
            this.worksheetLabel.AutoSize = true;
            this.worksheetLabel.Location = new System.Drawing.Point(20, 267);
            this.worksheetLabel.Name = "worksheetLabel";
            this.worksheetLabel.Size = new System.Drawing.Size(62, 13);
            this.worksheetLabel.TabIndex = 18;
            this.worksheetLabel.Text = "Worksheet:";
            this.worksheetLabel.Visible = false;
            // 
            // ProductionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(329, 299);
            this.Controls.Add(this.worksheetLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combineButton);
            this.Controls.Add(this.genLookupButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.pwOrDelimLabel);
            this.Controls.Add(this.pwOrDelimTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileComboBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.prfHTML);
            this.Controls.Add(this.suppliedButton);
            this.Controls.Add(this.processButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductionWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button suppliedButton;
        private System.Windows.Forms.Button prfHTML;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwOrDelimTextBox;
        private System.Windows.Forms.Label pwOrDelimLabel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button genLookupButton;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label worksheetLabel;
    }
}