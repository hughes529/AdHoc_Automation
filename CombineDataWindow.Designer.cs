namespace AdHOC_Automation_APP
{
    partial class CombineDataWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileTabCountTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.baseExcelPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.excelFileComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.combineButton = new System.Windows.Forms.Button();
            this.baseCSVPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.csvFileComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.baseExcelPanel.SuspendLayout();
            this.baseCSVPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of files/tabs to combine:";
            // 
            // fileTabCountTextBox
            // 
            this.fileTabCountTextBox.Location = new System.Drawing.Point(178, 5);
            this.fileTabCountTextBox.Name = "fileTabCountTextBox";
            this.fileTabCountTextBox.Size = new System.Drawing.Size(54, 20);
            this.fileTabCountTextBox.TabIndex = 1;
            this.fileTabCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(238, 35);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(42, 23);
            this.doneButton.TabIndex = 2;
            this.doneButton.Text = "done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // baseExcelPanel
            // 
            this.baseExcelPanel.Controls.Add(this.textBox1);
            this.baseExcelPanel.Controls.Add(this.label4);
            this.baseExcelPanel.Controls.Add(this.comboBox1);
            this.baseExcelPanel.Controls.Add(this.label3);
            this.baseExcelPanel.Controls.Add(this.excelFileComboBox);
            this.baseExcelPanel.Controls.Add(this.label2);
            this.baseExcelPanel.Location = new System.Drawing.Point(21, 90);
            this.baseExcelPanel.Name = "baseExcelPanel";
            this.baseExcelPanel.Size = new System.Drawing.Size(265, 110);
            this.baseExcelPanel.TabIndex = 3;
            this.baseExcelPanel.Tag = "p";
            this.baseExcelPanel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(80, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Tag = "w";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Worksheet:";
            // 
            // excelFileComboBox
            // 
            this.excelFileComboBox.FormattingEnabled = true;
            this.excelFileComboBox.Location = new System.Drawing.Point(80, 13);
            this.excelFileComboBox.Name = "excelFileComboBox";
            this.excelFileComboBox.Size = new System.Drawing.Size(170, 21);
            this.excelFileComboBox.TabIndex = 1;
            this.excelFileComboBox.Tag = "f";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "File Type:";
            // 
            // fileTypeComboBox
            // 
            this.fileTypeComboBox.FormattingEnabled = true;
            this.fileTypeComboBox.Location = new System.Drawing.Point(178, 35);
            this.fileTypeComboBox.Name = "fileTypeComboBox";
            this.fileTypeComboBox.Size = new System.Drawing.Size(54, 21);
            this.fileTypeComboBox.TabIndex = 5;
            // 
            // combineButton
            // 
            this.combineButton.Location = new System.Drawing.Point(21, 61);
            this.combineButton.Name = "combineButton";
            this.combineButton.Size = new System.Drawing.Size(75, 23);
            this.combineButton.TabIndex = 6;
            this.combineButton.Text = "Combine";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // baseCSVPanel
            // 
            this.baseCSVPanel.Controls.Add(this.textBox2);
            this.baseCSVPanel.Controls.Add(this.label7);
            this.baseCSVPanel.Controls.Add(this.csvFileComboBox);
            this.baseCSVPanel.Controls.Add(this.label6);
            this.baseCSVPanel.Location = new System.Drawing.Point(21, 90);
            this.baseCSVPanel.Name = "baseCSVPanel";
            this.baseCSVPanel.Size = new System.Drawing.Size(265, 78);
            this.baseCSVPanel.TabIndex = 7;
            this.baseCSVPanel.Tag = "p";
            this.baseCSVPanel.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = ",";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Delimiter:";
            // 
            // csvFileComboBox
            // 
            this.csvFileComboBox.FormattingEnabled = true;
            this.csvFileComboBox.Location = new System.Drawing.Point(80, 12);
            this.csvFileComboBox.Name = "csvFileComboBox";
            this.csvFileComboBox.Size = new System.Drawing.Size(170, 21);
            this.csvFileComboBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "File:";
            // 
            // CombineDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(298, 219);
            this.Controls.Add(this.baseCSVPanel);
            this.Controls.Add(this.combineButton);
            this.Controls.Add(this.fileTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.fileTabCountTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseExcelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CombineDataWindow";
            this.Text = "CombineDataWindow";
            this.baseExcelPanel.ResumeLayout(false);
            this.baseExcelPanel.PerformLayout();
            this.baseCSVPanel.ResumeLayout(false);
            this.baseCSVPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileTabCountTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Panel baseExcelPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox excelFileComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox fileTypeComboBox;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.Panel baseCSVPanel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox csvFileComboBox;
        private System.Windows.Forms.Label label6;
    }
}