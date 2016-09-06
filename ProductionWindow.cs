using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using AdHoc.PRF;

namespace AdHOC_Automation_APP
{
    public partial class ProductionWindow : Form
    {
        private readonly PRF currentPRF;
        private BackgroundWorker bw = new BackgroundWorker();
        private AdHocFileManager fm;
        private readonly List<string> flatExts = new List<string> { ".csv", ".CSV", ".txt", ".TXT" };
        private readonly List<string> xclExts = new List<string> { ".xls", ".xlsx" };
        private string[] suppliedDataFiles;
        private bool isExcelFile;
        private ComboBox worksheetComboBox;
        private string devProdFolderPath;
        private string devProdProductionPath;

        public ProductionWindow(PRF prf, AdHocFileManager fm)
        {
            InitializeComponent();
            this.currentPRF = prf;
            this.fm = fm;
            this.FormClosed += new FormClosedEventHandler(ProductionWindow_FormClosing);

            this.bw.WorkerReportsProgress = false;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Done);

            //add in the supplied files to combo box
            this.populateFileComboBox();
            this.isExcelFile = false;

            this.devProdFolderPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1);
            this.devProdProductionPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID;

        }

        private void populateFileComboBox()
        {
            string[] files = Directory.GetFiles(Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.ToString().Substring(1) + @"\SUPPLIED\");
            List<string> temp = new List<string>();
            foreach (string s in files)
            {
                string ext = Path.GetExtension(s);
                if (this.flatExts.Contains(ext) || this.xclExts.Contains(ext))
                {
                    temp.Add(s);
                    this.fileComboBox.Items.Add(Path.GetFileName(s));
                }
            }

            this.suppliedDataFiles = temp.ToArray();
            temp = null;
        }

        //master app done button
        private void processButton_Click(object sender, EventArgs e)
        {
            this.startProgressBar();
            this.bw.RunWorkerAsync();
        }

        private void bw_Done(object sender, EventArgs e)
        {
            this.stopProgressBar();

            if (!this.currentPRF.InkJet)
            {
                this.Hide();
                PRF_Entry entry = new PRF_Entry();
                entry.Show();
            }
            else
            {
                PDL_Selector pdl = new PDL_Selector(this.currentPRF, this.fm);
                this.Hide();
                pdl.Show();
            }
        }

        private void bw_DoWork(object sender, EventArgs e)
        {
            if (!this.currentPRF.InkJet)
            {
                this.fm.masterAppDone("", "");
                Process.Start(this.devProdProductionPath);
            }
        }

        private void suppliedButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = this.fm.copyNewSuppliedFilesToDevProd(this.currentPRF);
                if (path.Length > 0)
                {
                    Process.Start(path);
                }
                string devFolder = @"\\oh50ms01\oh50public\Digital Orders\Development" + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID;
                if (Directory.Exists(devFolder))
                {
                    MessageBox.Show("There is a folder present on 01 with the PRF number.  Ensure it is deleted/moved before reprocessing the job");
                }
            }
            catch (prfException excep)
            {
                MessageBox.Show(excep.Message);                
            }
        }

        private void prfHTML_Click(object sender, EventArgs e)
        {
            string path = this.fm.generateNewPRFHTML(this.currentPRF);
            if (path.Length > 0)
            {
                Process.Start(path);
            }
        }

        private void ProductionWindow_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void startProgressBar()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;
        }

        private void stopProgressBar()
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Step = 0;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.isExcelFile)
                {
                    if (this.worksheetComboBox.SelectedIndex >= 0)
                    {
                        //int[] counts = ExcelProcessing.getQuotesAndNewLineCount(this.suppliedDataFiles[this.fileComboBox.SelectedIndex], this.pwOrDelimTextBox.Text, this.worksheetComboBox.SelectedIndex + 1);
                        //if (counts[0] != 0 || counts[1] != 0)
                        //{
                        //    MessageBox.Show("The selected data file contains " + counts[0] + " quotes, and " + counts[1] + " new line characters");
                        //}
                        string saveAsPath = this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID + ".csv";
                        DataTable table = ExcelProcessing.saveExcelToCSV(this.suppliedDataFiles[this.fileComboBox.SelectedIndex], saveAsPath, this.pwOrDelimTextBox.Text, this.worksheetComboBox.SelectedIndex + 1);
                        TableExport.exportTableToCSV(table, saveAsPath);
                        Process.Start(saveAsPath);
                    }
                    else
                    {
                        MessageBox.Show("You must select a worksheet first");
                    }
                }
                else
                {
                    DataTable table = dataImport.importCSVData(this.suppliedDataFiles[this.fileComboBox.SelectedIndex], this.pwOrDelimTextBox.Text);
                    string saveAsPath = this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID + ".csv";
                    TableExport.exportTableToCSV(table, saveAsPath);
                    Process.Start(saveAsPath);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(this.suppliedDataFiles[this.fileComboBox.SelectedIndex]);
            if (this.flatExts.Contains(ext))
            {
                this.buildCSVInterface();
                this.isExcelFile = false;
            }
            else if (this.xclExts.Contains(ext))
            {
                this.buildExcelInterface();
                this.isExcelFile = true;
            }
        }

        private void buildCSVInterface()
        {
            this.pwOrDelimLabel.Text = "Delimiter:";
            this.pwOrDelimLabel.Location = new Point(32, 237);
            if (this.worksheetComboBox != null)
            {
                this.worksheetComboBox.Hide();
                this.worksheetComboBox = null;
            }
        }

        private void buildExcelInterface()
        {
            this.pwOrDelimLabel.Text = "Password:";
            this.pwOrDelimLabel.Location = new Point(26, 237);

            this.worksheetComboBox = new ComboBox();
            this.worksheetComboBox.Size = new Size(201, 20);
            this.worksheetComboBox.Location = new Point(88, 267);
            this.Controls.Add(worksheetComboBox);
            this.worksheetLabel.Visible = true;

            if (!ExcelProcessing.checkIfPasswordIsNeeded(this.suppliedDataFiles[this.fileComboBox.SelectedIndex]))
            {
                string[] sheets = ExcelProcessing.getWorksheets(this.suppliedDataFiles[this.fileComboBox.SelectedIndex], this.pwOrDelimTextBox.Text);
                foreach (string s in sheets)
                {
                    this.worksheetComboBox.Items.Add(s);
                }
            }
        }

        private void combineButton_Click(object sender, EventArgs e)
        {
            CombineDataWindow cdw = new CombineDataWindow(this.currentPRF);
            cdw.FormClosed += new FormClosedEventHandler(this.combineOrLookupWindowClose);
            cdw.Show();
            this.Enabled = false;
        }

        private void genLookupButton_Click(object sender, EventArgs e)
        {
            string path = this.devProdFolderPath + @"\SUPPLIED";
            LookupTableWindow lt = new LookupTableWindow(this.currentPRF, Directory.GetFiles(path));
            lt.FormClosed += new FormClosedEventHandler(this.combineOrLookupWindowClose);
            lt.Show();
            this.Enabled = false;
        }

        private void passwordDoneEntering(object sender, EventArgs e)
        {
            if (isExcelFile)
            {
                try
                {
                    string pw = this.pwOrDelimTextBox.Text;
                    if (pw.Length > 0)
                    {
                        string[] sheets = ExcelProcessing.getWorksheets(this.suppliedDataFiles[this.fileComboBox.SelectedIndex], pw);
                        foreach (string s in sheets)
                        {
                            this.worksheetComboBox.Items.Add(s);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Incorrect password entered for the selected data file.  Try again human.");
                }
            }            
        }

        private void combineOrLookupWindowClose(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            PRF_Entry pe = new PRF_Entry();
            this.Hide();
            pe.Show();
            this.Dispose();
        }
    }
}
