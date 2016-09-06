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
using System.Diagnostics;
using AdHoc.PRF;

namespace AdHOC_Automation_APP
{
    public partial class PDL_Selector : Form
    {
        public string validPDLPath;
        public string invalidPDLPath;
        public string indiciaPath;
        private string[] files;
        private string[] indicias;
        private string[] usedPDLFiles;
        private readonly PRF currentPRF;
        //private readonly bool xmpieUSED;
        private AdHocFileManager fm;

        public PDL_Selector(PRF prf, AdHocFileManager fm)
        {
            this.currentPRF = prf;
            this.fm = fm;
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(PDL_SelectorClosed);

            //get all pdl files
            this.populateComboBoxes();

            //set default to 0 or NONE for each combobox
            validSelector.SelectedIndex = 0;
            invalidSelector.SelectedIndex = 0;
            indicaSelector.SelectedIndex = 0;
        }

        private void populateComboBoxes()
        {
            this.populatePDLComboBoxes();

            this.populateIndiciaComboBox();
        }

        private void populateIndiciaComboBox()
        {
            try
            {
                indicaSelector.Items.Add("NONE");

                //some folders are indicia, some are indicias
                string indiciaPath = System.IO.Directory.Exists(Properties.Settings.Default.devProdBase + "\\" + this.currentPRF.ClientID + "\\Indicias") ? Properties.Settings.Default.devProdBase + "\\" + this.currentPRF.ClientID + "\\Indicias" : Properties.Settings.Default.devProdBase + "\\" + this.currentPRF.ClientID + "\\Indicia";

                String[] temp = System.IO.Directory.GetFiles(indiciaPath);
                Stack<string> indiciaStack = new Stack<string>();

                indicaSelector.Items.Add("NONE");
                foreach (string s in temp)
                {
                    if (Path.GetExtension(s).Equals(".pdf") || Path.GetExtension(s).Equals(".PDF"))
                    {
                        indiciaStack.Push(s);
                        indicaSelector.Items.Add(Path.GetFileName(s));
                    }
                }
                this.indicias = indiciaStack.ToArray();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);                
            }
        }

        private void populatePDLComboBoxes()
        {
            string pdlFolder = @"\\oh50ms04\DevProd\Inkjet PDLs";
            this.files = System.IO.Directory.GetFiles(pdlFolder);
            validSelector.Items.Add("NONE");
            invalidSelector.Items.Add("NONE");
            //populate the pdls
            bool isNumTen = (this.currentPRF.FinishedWidth.Equals("4.125") && this.currentPRF.FinishedHeight.Equals("9.5")) || (this.currentPRF.FinishedHeight.Equals("4.125") && this.currentPRF.FinishedWidth.Equals("9.5"));
            List<string> tempPDL = new List<string>();
            foreach (string s in files)
            {
                if (s.Contains(this.currentPRF.FinishedWidth) && s.Contains(this.currentPRF.FinishedHeight) && !isNumTen)
                {
                    validSelector.Items.Add(Path.GetFileName(s));
                    invalidSelector.Items.Add(Path.GetFileName(s));
                    tempPDL.Add(s);
                }
                else if (isNumTen && s.Contains("#10"))
                {
                    validSelector.Items.Add(Path.GetFileName(s));
                    invalidSelector.Items.Add(Path.GetFileName(s));
                    tempPDL.Add(s);
                }
            }
            this.usedPDLFiles = tempPDL.ToArray();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = validSelector.SelectedIndex - 1;
            if (i >= 0)
            {
                this.validPDLPath = this.usedPDLFiles[i];
            }
            else if (i == -1)
            {
                this.validPDLPath = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = invalidSelector.SelectedIndex - 1;
            if (i >= 0)
            {
                this.invalidPDLPath = this.usedPDLFiles[i];
            }
            else if (i == -1)
            {
                this.invalidPDLPath = "";
            }
        }

        //finsihed button
        private void button1_Click(object sender, EventArgs e)
        {
            //make sure no path is null
            if (this.indiciaPath == null)
            {
                this.indiciaPath = "";
            }
            if (this.validPDLPath == null)
            {
                this.validPDLPath = "";
            }
            if (this.invalidPDLPath == null)
            {
                this.invalidPDLPath = "";
            }
            //start copy and return return path, check if path contains | and open appropriate windows
            try
            {
                this.fm.masterAppDone(this.validPDLPath, this.invalidPDLPath);
                string name = Path.GetFileName(this.indiciaPath);
                File.Copy(this.indiciaPath, Properties.Settings.Default.inkjetBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID + @"\VALIDS\" + name);
                Process.Start(Properties.Settings.Default.inkjetBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID);
                PRF_Entry entry = new PRF_Entry();
                this.Hide();
                entry.Show();
                //old
                //string path = adhocAutoModel.copyProdFilesToFiveDigit(this.currentPRF, this.validPDLPath, this.invalidPDLPath, this.indiciaPath, this.xmpieUSED);
                //    if (path.Length > 0)
                //    {
                //        if (path.Contains("|"))
                //        {
                //            int i = path.IndexOf("|");
                //            string one = path.Substring(0, i);
                //            string two = path.Substring(i + 1);
                //            Process.Start(one);
                //            Process.Start(two);
                //        }
                //        else
                //        {
                //            Process.Start(path);
                //        }
                //        this.Hide();
                //        PRF_Entry entry = new PRF_Entry();
                //        entry.Show();
                //        //start make a dump for FID jobs
                //        if (this.currentPRF.ClientID.Equals("FID"))
                //        {
                //            if (System.Environment.Is64BitOperatingSystem)
                //            {
                //                Process.Start(@"\\oh50ms04\DevProd\Nicodemus\PROJECTS\EXEC\MADMK4-64.exe");
                //            }
                //            else
                //            {
                //                Process.Start(@"\\oh50ms04\DevProd\Nicodemus\PROJECTS\EXEC\MADMK4-32.exe");
                //            }
                //        }

                //    }
                //}
                //catch (prfException excep)
                //{
                //    if (excep.errorCode != 1)
                //    {
                //        MessageBox.Show(excep.Message);
                //    }
                //    else
                //    {
                //        Process.Start(excep.returnValue);
                //        MessageBox.Show(excep.Message);
                //    }            
                //}
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void indicaSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = indicaSelector.SelectedIndex - 1;
            if (i > 0)
            {
                this.indiciaPath = indicias[i];
            }
            else if (i == -1)
            {
                this.indiciaPath = "";
            }
        }

        private void PDL_SelectorClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
