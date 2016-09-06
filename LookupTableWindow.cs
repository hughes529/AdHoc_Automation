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

namespace AdHOC_Automation_APP
{
    public partial class LookupTableWindow : Form
    {
        private PRF currentPRF;
        private string[] dataFiles;
        private bool isExcelFile;

        public LookupTableWindow(PRF prf, string[] files)
        {
            InitializeComponent();
            this.currentPRF = prf;
            this.dataFiles = files;

            //populate the file combobox
            foreach (string s in files)
            {
                this.fileComboBox.Items.Add(Path.GetFileName(s));
            }
        }

        private void passwordFinsihedEntering(object sender, EventArgs e)
        {
            try
            {
                string[] ws = ExcelProcessing.getWorksheets(this.dataFiles[this.fileComboBox.SelectedIndex], this.pwTextBox.Text);
                foreach (string s in ws)
                {
                    this.worksheetComboBox.Items.Add(s);
                }
            }
            catch
            {
                MessageBox.Show("Inccorect password entered");
            }
        }

        private void fileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(this.dataFiles[this.fileComboBox.SelectedIndex]);
            if(ext.Equals(".xlsx") || ext.Equals(".xls"))
            {
                this.pwTextBox.Enabled = true;
                this.worksheetComboBox.Enabled = true;
                this.isExcelFile = true;

                if (!ExcelProcessing.checkIfPasswordIsNeeded(this.dataFiles[this.fileComboBox.SelectedIndex]))
                {
                    string[] ws = ExcelProcessing.getWorksheets(this.dataFiles[this.fileComboBox.SelectedIndex], "");
                    foreach (string s in ws)
                    {
                        this.worksheetComboBox.Items.Add(s);
                    }
                }
            }
            else
            {
                this.isExcelFile = false;
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (this.isExcelFile)
            {
                string path = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1) + @"\DATA\" + this.currentPRF.JobID + "_ORIG.csv";
                ExcelProcessing.saveExcelToCSV(this.dataFiles[this.fileComboBox.SelectedIndex], path, this.pwTextBox.Text, this.worksheetComboBox.SelectedIndex);
                table = dataImport.importCSVData(path);
            }
            else
            {
                table = dataImport.importCSVData(this.dataFiles[this.fileComboBox.SelectedIndex]);
            }

            try
            {
                int columnCount = Int32.Parse(this.idTextBox.Text);
                this.basePanel.Visible = true;
                foreach (DataColumn col in table.Columns)
                {
                    this.columnComboBox.Items.Add(col.ColumnName);
                }

                for (int i = 2; i < columnCount; i++)
                {
                    Panel p = new Panel();
                    p.Size = this.basePanel.Size;
                    p.Location = new Point(this.basePanel.Location.X, this.basePanel.Location.Y + 50 * (i - 1));
                    foreach (Control c in this.basePanel.Controls)
                    {
                        if (c.GetType() == typeof(Label))
                        {
                            Label l = new Label();
                            l.Size = c.Size;
                            l.Location = c.Location;
                            l.Text = c.Text;
                            p.Controls.Add(l);
                        }
                        else if (c.GetType() == typeof(ComboBox))
                        {
                            ComboBox cb = new ComboBox();
                            ComboBox temp = (ComboBox)c;
                            cb.Size = temp.Size;
                            cb.Location = temp.Location;
                            foreach (string s in temp.Items)
                            {
                                cb.Items.Add(s);
                            }
                            p.Controls.Add(cb);
                        }
                        else if (c.GetType() == typeof(CheckBox))
                        {

                        }
                        else if (c.GetType() == typeof(TextBox))
                        {

                        }
                        this.Controls.Add(p);
                    }
                }
            }
            catch
            {
                MessageBox.Show("That's not a number");
            }
        }

    }
}
