namespace AdHOC_Automation_APP
{
    partial class PDL_Selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDL_Selector));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.validSelector = new System.Windows.Forms.ComboBox();
            this.invalidSelector = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.indicaSelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valid/Domestic PDL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Invalid/Foreign PDL";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // validSelector
            // 
            this.validSelector.FormattingEnabled = true;
            this.validSelector.Location = new System.Drawing.Point(120, 19);
            this.validSelector.Name = "validSelector";
            this.validSelector.Size = new System.Drawing.Size(382, 21);
            this.validSelector.TabIndex = 2;
            this.validSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // invalidSelector
            // 
            this.invalidSelector.FormattingEnabled = true;
            this.invalidSelector.Location = new System.Drawing.Point(120, 46);
            this.invalidSelector.Name = "invalidSelector";
            this.invalidSelector.Size = new System.Drawing.Size(382, 21);
            this.invalidSelector.TabIndex = 3;
            this.invalidSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Finished";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Indicia";
            // 
            // indicaSelector
            // 
            this.indicaSelector.FormattingEnabled = true;
            this.indicaSelector.Location = new System.Drawing.Point(120, 72);
            this.indicaSelector.Name = "indicaSelector";
            this.indicaSelector.Size = new System.Drawing.Size(382, 21);
            this.indicaSelector.TabIndex = 6;
            this.indicaSelector.SelectedIndexChanged += new System.EventHandler(this.indicaSelector_SelectedIndexChanged);
            // 
            // PDL_Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 130);
            this.Controls.Add(this.indicaSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.invalidSelector);
            this.Controls.Add(this.validSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PDL_Selector";
            this.Text = "PDL_Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox validSelector;
        private System.Windows.Forms.ComboBox invalidSelector;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox indicaSelector;
    }
}