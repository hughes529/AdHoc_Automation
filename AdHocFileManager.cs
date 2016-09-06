using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using AdHoc.PRF;

namespace AdHOC_Automation_APP
{
    public class AdHocFileManager
    {
        private PRF currentPRF;
        bool isDM;
        bool isPre;
        private List<string> maildExtensions = new List<string>() { ".cpt", ".cqt", ".csm", ".hdr", ".mcr", ".mpa", ".mpu", ".pbc", ".pqt", ".seg" };
        private string devProdFolderPath;
        private string devProdProductionPath;

        public AdHocFileManager(PRF prf, bool isDataMatrix, bool isPremerge)
        {
            this.currentPRF = prf;
            this.isDM = isDataMatrix;
            this.isPre = isPremerge;

            this.devProdFolderPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1);
            this.devProdProductionPath = Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID;
        }

        public void startJob()
        {
            //get supplied files
            this.copySuppliedFiles();
            //PRF.html
            this.generatePRFTextFile(this.devProdFolderPath + @"\SUPPLIED\PRF.html");
        }

        public void masterAppDone(string validPDLPath, string invalidPDLPath)
        {
            //backup the 6 digit to data
            try
            {
                this.backUP6DigitFolder();
            }
            catch
            {
                throw new Exception("Error in backing up 6 digit folder");
            }
            finally
            {
                //copy over data to the appropriate folders
                this.copyDataToFolders(validPDLPath, invalidPDLPath);
                if (this.currentPRF.InkJet && !this.currentPRF.IGEN && !this.currentPRF.NUVERA)
                {
                    Directory.Delete(this.devProdProductionPath, true);
                }
            }

        }

        public string generateNewPRFHTML(PRF currentPRF)
        {
            string retVal = "";
            string sourceFileName = Properties.Settings.Default.suppliedURL + currentPRF.ClientID + "\\" + currentPRF.JobID;
            string destFileName = this.devProdFolderPath + "\\SUPPLIED\\PRF.html";
            string newFilepath = this.checkIfPRFTextFileExists(destFileName);
            this.generatePRFTextFile(newFilepath);
            retVal = this.devProdFolderPath + @"\SUPPLIED\";
            return retVal;
        }

        public string copyNewSuppliedFilesToDevProd(PRF prf)
        {
            try
            {
                string suppliedFilePath = Properties.Settings.Default.suppliedURL + prf.ClientID + "\\" + prf.JobID;
                string devProdSuppliedPath = this.devProdFolderPath + "\\SUPPLIED";
                string oldSuppliedPath = devProdSuppliedPath + "\\OLD";
                //get files in supplied and move to OLD
                String[] oldSuppliedFiles = System.IO.Directory.GetFiles(devProdSuppliedPath);
                if (oldSuppliedFiles.Length > 0)
                {
                    Stack<string> oldFileStack = new Stack<string>();
                    foreach (string s in oldSuppliedFiles)
                    {
                        if (!s.Contains(".html"))
                        {
                            oldFileStack.Push(s);
                        }
                    }
                    this.moveSuppliedToOldDirectory(oldSuppliedPath, oldFileStack);
                }
                //get files in orig_supplied and copy to devprod_supplied
                string[] files = Directory.GetFiles(suppliedFilePath);
                foreach (string s in files)
                {
                    string name = Path.GetFileName(s);
                    File.Copy(s, this.devProdFolderPath + @"\SUPPLIED\" + name, true);
                }

                return devProdSuppliedPath;
            }
            catch (Exception e)
            {
                throw new prfException(e.Message);
            }
        }

        #region private methods

        private void moveSuppliedToOldDirectory(string directory, Stack<String> files)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
            while (files.Count > 0)
            {
                string s = files.Pop();
                string newFile = this.getNewFileName(s, directory);
                if (System.IO.File.Exists(newFile))
                {
                    System.IO.File.Delete(s);
                }
                else
                {
                    System.IO.File.Move(s, newFile);
                }
            }
        }

        private string getNewFileName(string filePath, string directory)
        {
            //get last occurance of \, grab file name, append to directory and create file
            int i = filePath.LastIndexOf("\\") + 1;
            string fileName = filePath.Substring(i);
            string newFile = directory + "\\" + fileName;
            return newFile;
            //string fileName = Path.GetFileName(filePath);
            //return (directory + "\\" + fileName);
        }

        private void generatePRFTextFile(string path)
        {
            //open stream write with specified filepath and name, use reflectioin on PRF object to get all object fields, 
            //the appropriate field value and write a single line to PRF.txt
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.Write("<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"UTF-8\">\n<title>" + this.currentPRF.JobID.ToString() + "</title></head>\n<body>\n");
            file.Write("<table style=\"width:100%\">\n");
            Type t = this.currentPRF.GetType();
            System.Reflection.FieldInfo[] p = t.GetFields();
            foreach (var prop in p)
            {
                file.WriteLine("<tr>");
                int i = prop.ToString().LastIndexOf(' ');
                string name = prop.ToString().Substring(i++);
                string value = prop.GetValue(this.currentPRF).ToString();
                if (value == null)
                {
                    value = "";
                }
                file.WriteLine("<td>" + name + "</td>\n" + "<td>" + value + "</td>\n</tr>");
            }
            file.Write("</table>\n</body>\n</html>");
            file.Close();
        }

        private string checkIfPRFTextFileExists(string suppliedDirectory)
        {
            string filePath = "";
            //base case - check if PRF.txt exists, then if PRF_V2.txt exists, etc etc.  if true, recurrsivley call until a unique file name is generated
            if (System.IO.File.Exists(suppliedDirectory))
            {
                string directory = Path.GetDirectoryName(suppliedDirectory);
                string fileName = Path.GetFileName(suppliedDirectory);
                int indexOfV = fileName.LastIndexOf('V');
                if (indexOfV == -1)//case for PRF.txt
                {
                    int indexOfPeriod = fileName.LastIndexOf('.');//use indexOfPeriod - 1 as insert point for _V2
                    string supp2 = Path.Combine(directory, fileName.Insert(indexOfPeriod--, "_V2"));
                    filePath = checkIfPRFTextFileExists(supp2);//recurssive call, check if PRF_V2.txt exists
                }
                else//all other PRF_V#.txt cases
                {
                    int indexOfPeriod = fileName.LastIndexOf('.');
                    string version = fileName.Substring(indexOfV + 1, indexOfPeriod - indexOfV - 1);//grab the current version, substring between V and . in text file name
                    try
                    {
                        int oldVersion = Convert.ToInt32(version);//make sure version is a number
                        int newVersion = oldVersion + 1;//increment version
                        string supp2 = Path.Combine(directory, fileName.Replace("V" + version, "V" + newVersion.ToString()));
                        filePath = checkIfPRFTextFileExists(supp2);//recurssive call to check if new version file exists
                    }
                    catch (Exception e)
                    {
                        throw new prfException(e.ToString());
                    }
                }
            }
            //termianting case - if suppliedDirectory does not exist return suppliedDirectory 
            else
            {
                filePath = suppliedDirectory;
            }
            return filePath;
        }

        private void copyDataToFolders(string validPDLPath, string invalidPDLPath)
        {
            //start with Data Folder
            this.copyFilesForDataFolder();
            //proof
            List<string>[] files = this.copyFilesForProofFolder();
            //inkjet
            if (this.currentPRF.InkJet)
            {
                this.copyFilesForInkjetFolder(files, validPDLPath, invalidPDLPath);
            }
        }

        private void copyFilesForDataFolder()
        {
            //ZIP file
            string zipFile = this.currentPRF.Location + "_" + this.currentPRF.ClientID + @"_" + this.currentPRF.JobID + "_ZIP.csv";
            if (File.Exists(this.devProdProductionPath + @"\" + zipFile))
            {
                File.Copy(this.devProdProductionPath + @"\" + zipFile, this.devProdFolderPath + @"\DATA\" + zipFile, true);
            }
        }

        private List<string>[] copyFilesForProofFolder()
        {
            //start with files in 6 digit
            string[] files = Directory.GetFiles(this.devProdProductionPath);
            //make lists for quick iteration later
            List<string> validFiles = new List<string>();
            List<string> invalidFiles = new List<string>();
            List<string> maildatFiles = new List<string>();

            this.getValidAndInvalidDataFiles(files, validFiles, invalidFiles);

            //move on to valids folder for postal paperwork and maildats
            this.getMaildatAndPostalFiles(maildatFiles, validFiles);

            //add in the batch list files here
            if (File.Exists(this.devProdProductionPath + @"\VALIDS\" + this.currentPRF.JobID.Substring(1) + this.currentPRF.Print.Substring(0, 1) + "11_BL.CSV"))
            {
                validFiles.Add(this.devProdProductionPath + @"\VALIDS\" + this.currentPRF.JobID.Substring(1) + this.currentPRF.Print.Substring(0, 1) + "11_BL.CSV");
            }

            if (File.Exists(this.devProdProductionPath + @"\INVALIDS\" + this.currentPRF.JobID.Substring(1) + "I11_BL.CSV"))
            {
                invalidFiles.Add(this.devProdProductionPath + @"\INVALIDS\" + this.currentPRF.JobID.Substring(1) + "I11_BL.CSV");
            }

            //copy over to proof folder
            foreach (string s in validFiles)
            {
                string name = Path.GetFileName(s);
                if (!s.Contains("_BL"))
                {
                    File.Copy(s, this.devProdFolderPath + @"\PROOF\" + name, true);
                }
            }
            foreach (string s in invalidFiles)
            {
                string name = Path.GetFileName(s);
                if (!s.Contains("_BL"))
                {
                    File.Copy(s, this.devProdFolderPath + @"\PROOF\" + name, true);
                }
            }
            //move and zip the maildat files
            if (maildatFiles.Count > 0)
            {
                this.moveMaildatsAndZip(maildatFiles);
            }

            return new List<string>[] { validFiles, invalidFiles };
        }

        private void copyFilesForInkjetFolder(List<string>[] files, string validPDLPath, string invalidPDLPath)
        {
            List<string> validFiles = files[0];
            List<string> invalidFiles = files[1];

            Directory.CreateDirectory(this.devProdFolderPath + @"\INKJET\VALIDS\PDL");
            foreach (string s in validFiles)
            {
                string name = Path.GetFileName(s);
                if (!name.Equals(this.currentPRF.JobID.Substring(1) + "M.CSV"))
                {
                    File.Copy(s, this.devProdFolderPath + @"\INKJET\VALIDS\" + name, true);
                }
            }
            string validPDLName = Path.GetFileName(validPDLPath);
            File.Copy(validPDLPath, this.devProdFolderPath + @"\INKJET\VALIDS\PDL\" + validPDLName, true);

            if (invalidPDLPath.Length > 0)
            {
                Directory.CreateDirectory(this.devProdFolderPath + @"\INKJET\INVALIDS\PDL");
                foreach (string s in invalidFiles)
                {
                    string name = Path.GetFileName(s);
                    File.Copy(s, this.devProdFolderPath + @"\INKJET\INVALIDS\" + name, true);
                }
                string invalidPDLName = Path.GetFileName(invalidPDLPath);
                File.Copy(invalidPDLPath, this.devProdFolderPath + @"\INKJET\INVALIDS\PDL\" + invalidPDLName, true);
            }
            DirectoryCopy(this.devProdFolderPath + @"\INKJET", Properties.Settings.Default.inkjetBase + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID, true);
        }

        private void moveMaildatsAndZip(List<string>maildatFiles)
        {
            string maildatDir = this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID + "_MAILDAT";
            Directory.CreateDirectory(maildatDir);
            foreach (string s in maildatFiles)
            {
                string name = Path.GetFileName(s);
                File.Move(s, maildatDir + @"\" + name);
            }
            ZipFile zip = new ZipFile();
            zip.AddDirectory(maildatDir);
            zip.Save(this.devProdFolderPath + @"\PROOF\" + this.currentPRF.JobID + "_MAILDAT.zip");
        }

        private void getValidAndInvalidDataFiles(string[] files, List<string> validFiles, List<string> invalidFiles)
        {
            foreach (string s in files)
            {
                string name = Path.GetFileName(s);
                if (name.Contains(this.currentPRF.JobID.Substring(1) + "D11") || name.Contains(this.currentPRF.JobID.Substring(1) + "S11") || name.Contains(this.currentPRF.JobID.Substring(1) + "X") || name.Contains(this.currentPRF.JobID.Substring(1) + "M") || name.Contains("_BL"))
                {
                    validFiles.Add(s);
                }
                else if (this.currentPRF.CASS && (name.Contains(this.currentPRF.JobID.Substring(1) + "I11") || name.Contains(this.currentPRF.JobID.Substring(1) + "Z11")) || name.Contains("_BL"))
                {
                    invalidFiles.Add(s);
                }
                else if (name.Equals(currentPRF.Location + "_" + this.currentPRF.ClientID + "_" + this.currentPRF.JobID + "_REC.CSV"))
                {
                    File.Copy(s, Properties.Settings.Default.devProdBase + this.currentPRF.ClientID + @"\" + currentPRF.Location + "_" + this.currentPRF.JobID.Substring(1) + @"\PROOF\" + name, true);
                }
            }
        }

        private void getMaildatAndPostalFiles(List<string> maildatFiles, List<string> validFiles)
        {
            string[] vFiles = Directory.GetFiles(this.devProdProductionPath + @"\VALIDS\");
            foreach (string s in vFiles)
            {
                string name = Path.GetFileName(s);
                string ext = Path.GetExtension(s);
                if (name.Equals(this.currentPRF.JobID.Substring(1) + "_CASS.PDF") || name.Equals(this.currentPRF.JobID.Substring(1) + "_NCOA.PDF") || name.Equals(this.currentPRF.JobID.Substring(1) + "_PSR.PDF"))
                {
                    validFiles.Add(s);
                }
                else if (this.maildExtensions.Contains(ext))
                {
                    maildatFiles.Add(s);
                }
            }
        }

        private void backUP6DigitFolder()
        {
            string dest = this.devProdFolderPath + @"\DATA\" + this.currentPRF.JobID;
            this.DirectoryCopy(this.devProdProductionPath, dest, true);
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!dir.Exists)
                {
                    throw new Exception("Source directory does not exist or could not be found: " + sourceDirName);
                }

                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }

                // If copying subdirectories, copy them and their contents to new location. 
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
            catch
            {
                throw new Exception(Path.GetDirectoryName(sourceDirName) + " already present and can't be copied");
            }
        }

        private void copySuppliedFiles()
        {
            if (this.isPre)
            {
                this.generateSequenceFile();
            }
            if(Directory.Exists(Properties.Settings.Default.suppliedURL + @"\" + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID))
            {
                if (Directory.Exists(this.devProdFolderPath))
                {
                    throw new Exception("COL folder already in devprod");
                }
                else
                {
                    //build folder structure
                    this.buildCOLFolderStructure();

                    //get the files and copy over to supplied
                    string[] files = Directory.GetFiles(Properties.Settings.Default.suppliedURL + @"\" + this.currentPRF.ClientID + @"\" + this.currentPRF.JobID);
                    foreach (string s in files)
                    {
                        string name = Path.GetFileName(s);
                        File.Copy(s, this.devProdFolderPath + @"\SUPPLIED\" + name, true);
                    }
                }
            }
            else
            {
                this.buildCOLFolderStructure();
                throw new Exception("No files were uploaded for this PRF");
            }
        }

        private void generateSequenceFile()
        {
            string filePath = this.devProdFolderPath + "\\DATA\\" + currentPRF.JobID + ".csv";
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath);
                writer.WriteLine("sequence");
                for (int i = 1; i <= currentPRF.QuantityFinishedPieces; i++)
                {
                    writer.WriteLine(i);
                }
                writer.Close();
            }
            catch
            {
                throw new Exception("Could not create sequence file");
            }
        }

        private void buildCOLFolderStructure()
        {
            Directory.CreateDirectory(this.devProdFolderPath);
            Directory.CreateDirectory(this.devProdFolderPath + @"\SUPPLIED");
            Directory.CreateDirectory(this.devProdFolderPath + @"\DATA");
            Directory.CreateDirectory(this.devProdFolderPath + @"\PROOF");

            if (this.currentPRF.IGEN || this.currentPRF.NUVERA)
            {
                Directory.CreateDirectory(this.devProdFolderPath + @"\XMPIE\ART");
                Directory.CreateDirectory(this.devProdFolderPath + @"\XMPIE\INDD");
            }
            if (this.currentPRF.InkJet)
            {
                Directory.CreateDirectory(this.devProdFolderPath + @"\INKJET\");
            }
        }
        #endregion

    }
}
