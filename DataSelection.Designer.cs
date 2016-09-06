namespace AdHOC_Automation_APP
{
    partial class DataSelection
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
            this.dataFileTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of data files:";
            // 
            // dataFileTextBox
            // 
            this.dataFileTextBox.Location = new System.Drawing.Point(122, 6);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.Size = new System.Drawing.Size(46, 20);
            this.dataFileTextBox.TabIndex = 1;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(175, 5);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(256, 6);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 51);
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "Done Selecting Data";
            this.finishButton.UseVisualStyleBackColor = true;
            // 
            // DataSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 265);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.dataFileTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DataSelection";
            this.Text = "DataSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dataFileTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button finishButton;
    }
}