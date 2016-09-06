namespace AdHOC_Automation_APP
{
    partial class PRF_Entry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRF_Entry));
            this.PRF_BOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataMatrixBox = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.premergeCheckBox = new System.Windows.Forms.CheckBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PRF_BOX
            // 
            this.PRF_BOX.Location = new System.Drawing.Point(54, 13);
            this.PRF_BOX.Name = "PRF_BOX";
            this.PRF_BOX.Size = new System.Drawing.Size(202, 20);
            this.PRF_BOX.TabIndex = 0;
            this.PRF_BOX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PRF_BOX_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRF #";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataMatrixBox
            // 
            this.dataMatrixBox.AutoSize = true;
            this.dataMatrixBox.Location = new System.Drawing.Point(54, 51);
            this.dataMatrixBox.Name = "dataMatrixBox";
            this.dataMatrixBox.Size = new System.Drawing.Size(80, 17);
            this.dataMatrixBox.TabIndex = 4;
            this.dataMatrixBox.Text = "Data Matrix";
            this.dataMatrixBox.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(54, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // premergeCheckBox
            // 
            this.premergeCheckBox.AutoSize = true;
            this.premergeCheckBox.Location = new System.Drawing.Point(159, 51);
            this.premergeCheckBox.Name = "premergeCheckBox";
            this.premergeCheckBox.Size = new System.Drawing.Size(71, 17);
            this.premergeCheckBox.TabIndex = 12;
            this.premergeCheckBox.Text = "Premerge";
            this.premergeCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(262, 47);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 13;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // PRF_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(362, 107);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.premergeCheckBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataMatrixBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PRF_BOX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PRF_Entry";
            this.Text = "PRF Box";
            this.Load += new System.EventHandler(this.PRF_Entry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PRF_BOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox dataMatrixBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox premergeCheckBox;
        private System.Windows.Forms.Button resetButton;
    }
}

