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
    public partial class CombineDataWindow : Form
    {
        private PRF currentPRF;
        private string[] csvFilePaths;
        private string[] excelFilePaths;
        private readonly List<string> flatExts = new List<string> { ".csv", ".CSV", ".txt", ".TXT" };
        private readonly List<string> xclExts = new List<string> { ".xls", ".xlsx" };
        private int tabsOrFilesToCombine;
        private string devProdFolderPath;
        private string devProdProductionPath;

        public CombineDataWindow(PRF prf)
        {
            InitializeComponent();
            this.currentPRF = prf;
            this.fileTypeComboBox.Items.Add("CSV");
            this.fileTypeComboBox.Items.Add("Excel");
            this.fileTypeComboBox.SelectedIndex = 0;

            this.devProdFolderPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1);
            this.devProdProductionPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID;
            this.populateComboBoxes();
        }

        private void populateComboBoxes()
        {
            string[] files = Directory.GetFiles(this.devProdFolderPath + @"\SUPPLIED");
            List<string> tempCSVFiles = new List<string>();
            List<string> tempXCLFiles = new List<string>();
            
            foreach (string s in files)
            {
                if (flatExts.Contains(Path.GetExtension(s)))
                {
                    this.csvFileComboBox.Items.Add(Path.GetFileName(s));
                    tempCSVFiles.Add(s);
                }
                else if (xclExts.Contains(Path.GetExtension(s)))
                {
                    this.excelFileComboBox.Items.Add(Path.GetFileName(s));
                    tempXCLFiles.Add(s);
                }
            }

            this.csvFilePaths = tempCSVFiles.ToArray();
            this.excelFilePaths = tempXCLFiles.ToArray();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            int count;
            if (Int32.TryParse(this.fileTabCountTextBox.Text, out count))
            {
                this.tabsOrFilesToCombine = count;
                if (this.fileTypeComboBox.SelectedIndex == 0)
                {
                    this.buildCSVInterface(count);
                }
                else if (this.fileTypeComboBox.SelectedIndex == 1)
                {
                    this.buildExcelInterface(count);
                }
                this.doneButton.Enabled = false;
                this.fileTabCountTextBox.Enabled = false;
                this.fileTypeComboBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("That's not a valid number, try again idiot.");
            }
        }

        private void buildCSVInterface(int count)
        {
            this.baseCSVPanel.Visible = true;
            for (int c = 2; c <= count; c++)
            {
                Panel p = new Panel();
                p.Location = this.baseCSVPanel.Location;
                p.Size = this.baseCSVPanel.Size;
                p.Tag = -1;
                foreach (Control cont in this.baseCSVPanel.Controls)
                {
                    if (cont.GetType() == typeof(Label))
                    {
                        Label l = new Label();
                        l.Location = cont.Location;
                        l.Size = cont.Size;
                        l.Text = cont.Text;
                        p.Controls.Add(l);
                    }
                    else if (cont.GetType() == typeof(ComboBox))
                    {
                        ComboBox cb = new ComboBox();
                        ComboBox temp = (ComboBox)cont;
                        cb.Location = temp.Location;
                        cb.Size = temp.Size;
                        foreach (string s in temp.Items)
                        {
                            cb.Items.Add(s);
                        }
                        p.Controls.Add(cb);
                    }
                    else if (cont.GetType() == typeof(TextBox))
                    {
                        TextBox t = new TextBox();
                        t.Location = cont.Location;
                        t.Size = cont.Size;
                        t.Text = cont.Text;
                        p.Controls.Add(t);
                    }
                }
                p.Location = new Point(this.baseCSVPanel.Location.X, this.baseCSVPanel.Location.Y + (75 * (c - 1)));
                this.Controls.Add(p);
            }
        }

        private void buildExcelInterface(int count)
        {
            this.baseExcelPanel.Visible = true;
            int c = 2;
            while (c <= count)
            {
                Panel p = new Panel();
                p.Location = this.baseExcelPanel.Location;
                p.Tag = -1;
                foreach (Control cont in this.baseExcelPanel.Controls)
                {
                    if (cont.GetType() == typeof(Label))
                    {
                        Label l = new Label();
                        l.Location = cont.Location;
                        l.Size = cont.Size;
                        l.Text = cont.Text;
                        p.Controls.Add(l);
                    } else if (cont.GetType() == typeof(ComboBox))
                    {
                        ComboBox cb = new ComboBox();
                        cb.Location = cont.Location;
                        cb.Size = cont.Size;
                        ComboBox temp = (ComboBox)cont;
                        foreach (string s in temp.Items)
                        {
                            cb.Items.Add(s);
                        }
                        if (cont.Tag.Equals("f"))
                        {
                            cb.SelectedIndexChanged += new EventHandler(this.fileIndexChanged);
                        }
                        p.Controls.Add(cb);
                    }
                    else if (cont.GetType() == typeof(TextBox))
                    {
                        TextBox t = new TextBox();
                        t.Location = cont.Location;
                        t.Size = cont.Size;
                        t.Text = cont.Text;
                        t.Leave += new EventHandler(this.passwordDoneTyping);
                        p.Controls.Add(t);
                    }
                }
                p.Location = new Point(this.baseExcelPanel.Location.X, this.baseExcelPanel.Location.Y + (55 * c-1));
                //p.Parent = this;
                this.Controls.Add(p);
                c++;
            }
        }

        private void combineButton_Click(object sender, EventArgs e)
        {
            if (this.fileTypeComboBox.SelectedIndex == 0)
            {
                this.combineCSVFiles();
            }
            else if (this.fileTypeComboBox.SelectedIndex == 1)
            {
                this.combineExcelFiles();
            }
        }

        private void combineCSVFiles()
        {
            //iterate over the controls and grab the panels with tag p, get the data source names and delimeters, impor the data, compare headers, and then export if all is good
            List<DataTable> tables = new List<DataTable>();

            foreach (Control c in this.Controls)
            {
                if (c.Tag != null && c.Tag.Equals("p"))//found the panel
                {
                    string file = "";
                    string delim = "";
                    foreach (Control subC in c.Controls)
                    {
                        //get the combo box index 
                        if (subC.GetType() == typeof(ComboBox))
                        {
                            ComboBox cb = (ComboBox)subC;
                            file = this.csvFilePaths[cb.SelectedIndex];
                        }
                        else if (subC.GetType() == typeof(TextBox))
                        {    //get the text box
                            TextBox temp = (TextBox)subC;
                            delim = temp.Text;
                        }
                    }
                    //make the table
                    DataTable newtable = dataImport.importCSVData(file, delim);
                    tables.Add(newtable);
                }
            }
            DataTable combineTable = new DataTable();
            try
            {
                combineTable = DataCombiner.combineDataTables(tables.ToArray());
            }
            catch
            {
                MessageBox.Show("Headers do not match, unable to combine the data");
            }
            finally
            {
                TableExport.exportTableToCSV(combineTable, this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID + ".csv");
            }
        }

        private void combineExcelFiles()
        {
            //iterate over the controls and grab the panels with tag -1, get the data source names password and worksheet, impor the data, compare headers, and then export if all is good
            List<DataTable> tables = new List<DataTable>();

            foreach (Control c in this.Controls)
            {
                if (c.Tag != null && c.Tag.Equals("p"))//found the panel
                {
                    string file = "";
                    string pw = "";
                    int index = 0;
                    foreach (Control subC in c.Controls)
                    {
                        if (subC.GetType() == typeof(TextBox))
                        {
                            pw = subC.Text;
                        }
                        else if (subC.GetType() == typeof(ComboBox))
                        {
                                ComboBox cb = (ComboBox)subC;
                            if (subC.Tag != null && subC.Tag.Equals("f"))
                            {
                                file = this.excelFilePaths[cb.SelectedIndex];
                            }
                            else if (subC.Tag != null && subC.Tag.Equals("w"))
                            {
                                index = cb.SelectedIndex; 
                            }
                        }
                    }
                    //make a temp csv and import that way instead of trying to have a stroke importing excel data into a GD table
                    string path = Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                    tables.Add(ExcelProcessing.saveExcelToCSV(file, path, pw, index));
                }
            }

            try
            {
                DataTable combineTable = DataCombiner.combineDataTables(tables.ToArray());
                TableExport.exportTableToCSV(combineTable, this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID + ".csv");
            }
            catch
            {
                MessageBox.Show("Headers do not match, unable to combine the data");
            }

        }

        private void fileIndexChanged(object sender, EventArgs e)
        {
            //get the file
            ComboBox cb = (ComboBox)sender;
            string file = this.excelFilePaths[cb.SelectedIndex];
            string pw = "";
            Control parent = cb.Parent;
            //get the damn password first
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    pw = c.Text;
                }
            }
            
            foreach (Control c in parent.Controls)
            {
                if (c.Tag != null && c.Tag.Equals("w"))
                {
                    ComboBox worksheetCB = (ComboBox)c;
                    bool needPW = ExcelProcessing.checkIfPasswordIsNeeded(file);
                    if (!needPW)
                    {
                        string[] worksheets = ExcelProcessing.getWorksheets(file, "");
                        foreach (string s in worksheets)
                        {
                            worksheetCB.Items.Add(s);
                        }
                    }
                    else if (needPW && pw.Length > 0)
                    {
                        string[] worksheets = ExcelProcessing.getWorksheets(file, pw);
                        foreach (string s in worksheets)
                        {
                            worksheetCB.Items.Add(s);
                        }
                    }
                }
            }
        }

        private void passwordDoneTyping(object sender, EventArgs e)
        {
            try
            {
                //check if a file has been selected, if so populate the worksheet cb otherwise weep
                TextBox t = (TextBox)sender;
                Control parent = t.Parent;
                foreach (Control c in parent.Controls)
                {
                    if (c.Tag != null && c.Tag.Equals("f"))
                    {
                        ComboBox cb = (ComboBox)c;
                        if (cb.SelectedIndex > -1)
                        {
                            string file = this.excelFilePaths[cb.SelectedIndex];
                            string[] worksheets = ExcelProcessing.getWorksheets(file, t.Text);
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("That password seems to not be correct...");
            }
        }










    }
}
