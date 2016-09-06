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
using Adhoc_Adobe_Library_3_5;

namespace AdHOC_Automation_APP
{
    public partial class PRF_Entry : Form
    {
        private PRF currentPRF;
        private BackgroundWorker bw = new BackgroundWorker();
        private AdHocFileManager fileManager;
        private string devProdFolderPath;
        private string devProdProductionPath;

        public PRF_Entry()
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(prfScreen_Closed);

            this.bw.WorkerReportsProgress = false;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new DoWorkEventHandler(processPRF);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(jobCompleted);

            //test entry
            //ExcelProcessing.getQuotesAndNewLineCount(@"C:\Users\BHughes\Desktop\LFSMMKT v2.xlsx", "", 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        //GO button
        private void button1_Click(object sender, EventArgs e)
        {
            //start progress bar 
            this.startProgressBar();

            //prcoessPRF
            bw.RunWorkerAsync();
        }

        private void processPRF(object sender, EventArgs e)
        {
            int prfNumber;
            if (Int32.TryParse(PRF_BOX.Text, out prfNumber))
            {
                try
                {
                    this.currentPRF = new PRF(prfNumber.ToString());
                    this.fileManager = new AdHocFileManager(this.currentPRF, this.dataMatrixBox.Checked, this.premergeCheckBox.Checked);
                    this.fileManager.startJob();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
                finally
                {
                    this.devProdFolderPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1);
                    this.devProdProductionPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID;
                }
            }
            else
            {
                MessageBox.Show("The entered PRF number is not a number, try again");
            }
            //old
            //string path = "";
            //    //convert PRF to int to ensure it is actually a number
            //    int parse;
            //    bool cont = Int32.TryParse(PRF_BOX.Text, out parse);
            //    if (cont)
            //    {//build PRF and process 
            //        this.currentPRF = new PRF(PRF_BOX.Text);
            //        try {
            //            path = adhocAutoModel.processSinglePRF(currentPRF, dataMatrixBox.Checked, premergeCheckBox.Checked);
            //            if (path.Length > 0)
            //            {
            //                //successfully procesed and populated PRF, show COL_ folder, hide PRF window and show production options
            //                Process.Start(path);
            //                this.bw.CancelAsync();
            //            }
            //        }
            //        catch (prfException excep)
            //        {
            //            if (excep.errorCode == 3)//PRF not in DB
            //            {
            //                MessageBox.Show("Error in retreiving PRF data, please check your PRF number");
            //            }
            //            else if (excep.errorCode == 0)//COL_ already exists
            //            {
            //                MessageBox.Show(excep.Message);
            //                this.bw.CancelAsync();
            //            }
            //            else
            //            {
            //                MessageBox.Show(excep.Message);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Bad PRF Entered, must be 6 digit number");
            //    }
            }

        private void jobCompleted(object sender, EventArgs e)
        {
            this.bw.Dispose();
            //stop progress bar
            this.stopProgressBar();
            this.Hide();
            ProductionWindow prodWinow = new ProductionWindow(this.currentPRF, this.fileManager);
            //ProdWindowLite prodWinow = new ProdWindowLite(this.currentPRF);
            prodWinow.Show();
            Process.Start(this.devProdFolderPath);
        }

        private void PRF_Entry_Load(object sender, EventArgs e)
        {
        
        }

        private void PRF_BOX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        //reset button
        private void button2_Click_3(object sender, EventArgs e)
        {
            button1.Enabled = true;
            PRF_BOX.Enabled = true;
            PRF_BOX.Text = "";
            dataMatrixBox.Checked = false;
            premergeCheckBox.Checked = false;
            currentPRF = null;
        }

        private void prfScreen_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
