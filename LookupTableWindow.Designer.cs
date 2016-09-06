namespace AdHOC_Automation_APP
{
    partial class LookupTableWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.basePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.columnComboBox = new System.Windows.Forms.ComboBox();
            this.leftCheckBox = new System.Windows.Forms.CheckBox();
            this.rightCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pwTextBox = new System.Windows.Forms.TextBox();
            this.worksheetComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.basePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GroupID Builder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "How many columns make  up the ID?";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(231, 125);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(52, 20);
            this.idTextBox.TabIndex = 2;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(289, 124);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(42, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // basePanel
            // 
            this.basePanel.Controls.Add(this.textBox3);
            this.basePanel.Controls.Add(this.textBox2);
            this.basePanel.Controls.Add(this.rightCheckBox);
            this.basePanel.Controls.Add(this.leftCheckBox);
            this.basePanel.Controls.Add(this.columnComboBox);
            this.basePanel.Controls.Add(this.label3);
            this.basePanel.Location = new System.Drawing.Point(44, 155);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(287, 95);
            this.basePanel.TabIndex = 4;
            this.basePanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Column:";
            // 
            // columnComboBox
            // 
            this.columnComboBox.FormattingEnabled = true;
            this.columnComboBox.Location = new System.Drawing.Point(52, 9);
            this.columnComboBox.Name = "columnComboBox";
            this.columnComboBox.Size = new System.Drawing.Size(202, 21);
            this.columnComboBox.TabIndex = 1;
            // 
            // leftCheckBox
            // 
            this.leftCheckBox.AutoSize = true;
            this.leftCheckBox.Location = new System.Drawing.Point(6, 47);
            this.leftCheckBox.Name = "leftCheckBox";
            this.leftCheckBox.Size = new System.Drawing.Size(47, 17);
            this.leftCheckBox.TabIndex = 2;
            this.leftCheckBox.Tag = "left";
            this.leftCheckBox.Text = "Left:";
            this.leftCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightCheckBox
            // 
            this.rightCheckBox.AutoSize = true;
            this.rightCheckBox.Location = new System.Drawing.Point(6, 72);
            this.rightCheckBox.Name = "rightCheckBox";
            this.rightCheckBox.Size = new System.Drawing.Size(54, 17);
            this.rightCheckBox.TabIndex = 3;
            this.rightCheckBox.Tag = "right";
            this.rightCheckBox.Text = "Right:";
            this.rightCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(59, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Tag = "left";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(59, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Tag = "right";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data File:";
            // 
            // fileComboBox
            // 
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(103, 33);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(228, 21);
            this.fileComboBox.TabIndex = 9;
            this.fileComboBox.SelectedIndexChanged += new System.EventHandler(this.fileComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password:";
            // 
            // pwTextBox
            // 
            this.pwTextBox.Enabled = false;
            this.pwTextBox.Location = new System.Drawing.Point(103, 61);
            this.pwTextBox.Name = "pwTextBox";
            this.pwTextBox.Size = new System.Drawing.Size(228, 20);
            this.pwTextBox.TabIndex = 11;
            this.pwTextBox.Leave += new System.EventHandler(this.passwordFinsihedEntering);
            // 
            // worksheetComboBox
            // 
            this.worksheetComboBox.Enabled = false;
            this.worksheetComboBox.FormattingEnabled = true;
            this.worksheetComboBox.Location = new System.Drawing.Point(103, 88);
            this.worksheetComboBox.Name = "worksheetComboBox";
            this.worksheetComboBox.Size = new System.Drawing.Size(228, 21);
            this.worksheetComboBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Worksheet:";
            // 
            // LookupTableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(354, 262);
            this.Controls.Add(this.worksheetComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pwTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.basePanel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LookupTableWindow";
            this.Text = "LookupTableWindow";
            this.basePanel.ResumeLayout(false);
            this.basePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.ComboBox columnComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox rightCheckBox;
        private System.Windows.Forms.CheckBox leftCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pwTextBox;
        private System.Windows.Forms.ComboBox worksheetComboBox;
        private System.Windows.Forms.Label label6;
    }
}