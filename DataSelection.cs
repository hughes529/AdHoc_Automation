using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AdHoc.PRF;

namespace AdHOC_Automation_APP
{
    public partial class DataSelection : Form
    {
        private PRF currentPRF;
        private string[] files;

        public DataSelection(PRF prf)
        {
            InitializeComponent();
            this.currentPRF = prf;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.removeOldUI();
            this.makeComboBoxes();            
        }



        private void removeOldUI()
        {
            Control.ControlCollection controls = this.Controls;
            foreach (Control c in controls)
            {
                if ((int)c.Tag == -1)
                {
                    this.Controls.Remove(c);
                }
            }
        }

        private void makeComboBoxes()
        {
            int yOffset = 12;
            int dataSourceCount = 1;
            string[] f = Directory.GetFiles(Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1) + @"\SUPPLIED\");
            List<string> temp = new List<string>();
            if (Int32.TryParse(this.dataFileTextBox.Text, out dataSourceCount))
            {
                for (int i = 1; i <= dataSourceCount; i++)
                {
                    ComboBox box = new ComboBox();
                    foreach (string s in f)
                    {
                        if (Path.GetExtension(s).Equals(".xlsx") || Path.GetExtension(s).Equals(".xls") || Path.GetExtension(s).Equals(".txt") || Path.GetExtension(s).Equals(".TXT") || Path.GetExtension(s).Equals(".csv") || Path.GetExtension(s).Equals(".CSV"))
                        {
                            box.Items.Add(s);
                            temp.Add(s);
                        }
                    }
                    box.Tag = -1;
                    box.Width = 100;
                    box.Location = new Point(122, yOffset);
                    yOffset += 6;
                }
                this.files = temp.ToArray();
            }
            else
            {
                string s = this.dataFileTextBox.Text;
                this.dataFileTextBox.Text = "";
                MessageBox.Show("Does " + s + " look like a number to you?");
            }
        }
    }
}
