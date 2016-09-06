using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Runtime.InteropServices;
using AdHoc.PRF;

namespace AdHOC_Automation_APP
{
    class ExcelProcessing
    {
        public static bool checkIfPasswordIsNeeded(string file)
        {
            Application ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;

            Workbooks workbooks = ExcelApp.Workbooks;
            bool retVal = false;
            try
            {
                workbooks.Open(file, Type.Missing, Type.Missing, Type.Missing, "thisisabadpasswordhopefully", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                retVal = true;
            }

            workbooks.Close();
            ExcelApp.Quit();
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(ExcelApp);

            return retVal;
        }

        public static string[] getWorksheets(string file, string password)
        {
            Application ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;

            Workbooks workbooks = ExcelApp.Workbooks;

            workbooks.Open(file, Type.Missing, Type.Missing, Type.Missing, password, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Workbook workbook = workbooks.get_Item(1);
            Sheets sheets = workbook.Sheets;

            string[] worksheets = new string[sheets.Count];

            for (int i = 0; i < worksheets.Length; i++)
            {
                Worksheet sheet = sheets[i+1];
                worksheets[i] = sheet.Name;
                Marshal.ReleaseComObject(sheet);
            }

            //close everything
            Marshal.ReleaseComObject(sheets);
            workbook.Close(false, Type.Missing, Type.Missing);
            workbooks.Close();
            ExcelApp.Quit();
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(ExcelApp);

            return worksheets;
        }

        //public static System.Data.DataTable saveExcelToCSV(string file, PRF prf, string password, int worksheetIndex)
        //{
        //    string saveAsPath = Properties.Settings.Default.devProdBase + prf.ClientID + @"\COL_" + prf.JobID.Substring(1) + @"\DATA\" + prf.JobID + ".csv";
        //    return saveExcelToCSV(file, prf, password, worksheetIndex, saveAsPath);
        //}

        //public static System.Data.DataTable saveExcelToCSV(string file, PRF prf, string password, int worksheetIndex, string path)
        //{
        //    //start app
        //    Application ExcelApp = new Application();
        //    ExcelApp.Visible = false;
        //    ExcelApp.DisplayAlerts = false;

        //    //load the file
        //    Workbooks workbooks = ExcelApp.Workbooks;
        //    workbooks.Open(file, Type.Missing, Type.Missing, Type.Missing, password, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //    Workbook workbook = workbooks.get_Item(1);
        //    Worksheet sheet = workbook.Sheets[worksheetIndex];
        //    //remove new lines from worksheet
        //    //Worksheet sheet = workbook.Sheets[worksheetIndex];
        //    //Microsoft.Office.Interop.Excel.Range cells = sheet.Cells;
        //    //foreach (var newline in new string[] { "\r\n", "\r", "\n" })
        //    //{
        //    //    cells.Replace(newline, " ", Microsoft.Office.Interop.Excel.XlLookAt.xlPart, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, false, false, true, false);
        //    //}

        //    //workbook.SaveAs(@"C:\Users\BHughes\Documents\TestData\test2.csv", XlFileFormat.xlCSV);

        //    sheet.SaveAs(path, XlFileFormat.xlCSV);

        //    workbook.Close(false, Type.Missing, Type.Missing);
        //    workbooks.Close();
        //    ExcelApp.Quit();
        //    Marshal.ReleaseComObject(sheet);
        //    Marshal.ReleaseComObject(workbook);
        //    Marshal.ReleaseComObject(workbooks);
        //    Marshal.ReleaseComObject(ExcelApp);

        //    return dataImport.importCSVData(path);         
        //}

        public static int[] getQuotesAndNewLineCount(string file, string password, int worksheetIndex)
        {
            //start app
            Application ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;

            //load the file
            Workbooks workbooks = ExcelApp.Workbooks;
            workbooks.Open(file, Type.Missing, Type.Missing, Type.Missing, password, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Workbook workbook = workbooks.get_Item(1);

            //check for new lines and quotes in worksheet
            Sheets sheets = workbook.Sheets;
            Worksheet sheet = sheets[worksheetIndex];
            Microsoft.Office.Interop.Excel.Range cells = sheet.UsedRange;
            int newLineCount = 0;
            int quoteCount = 0;
            object[,] values = (object[,])cells.Value2;
            int numRow = 1;
            while (numRow< values.GetLength(0))
            {
                for (int c = 1; c <= cells.Columns.Count; c++)
                {
                    string v = Convert.ToString(values[numRow, c]);
                }
                numRow++;
            }
            //foreach (Range c in cells)
            //{
            //    if (c.Value != null)
            //    {
            //        Console.WriteLine(c.Row.ToString() + "_" + c.Column.ToString());
            //        string s = c.Value.ToString();
            //        if (s.Contains("\r\n") || s.Contains("\r") || s.Contains("\n"))
            //        {
            //            newLineCount++;
            //        }
            //        else if (s.Contains("\""))
            //        {
            //            quoteCount++;
            //        }
            //    }
            //    Marshal.ReleaseComObject(c);
            //}

            workbook.Close(false, Type.Missing, Type.Missing);
            workbooks.Close();
            ExcelApp.Quit();
            Marshal.ReleaseComObject(cells);
            Marshal.ReleaseComObject(sheet);
            Marshal.ReleaseComObject(sheets);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(ExcelApp);

            return new int[] { quoteCount, newLineCount };
        }

        public static System.Data.DataTable saveExcelToCSV(string file, string saveAspath, string password, int worksheetIndex)
        {
            //start app
            Application ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;

            //load the file
            Workbooks workbooks = ExcelApp.Workbooks;
            workbooks.Open(file, Type.Missing, Type.Missing, Type.Missing, password, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Workbook workbook = workbooks.get_Item(1);

            //check for new lines and quotes in worksheet
            Sheets sheets = workbook.Sheets;
            Worksheet sheet = sheets[worksheetIndex];

            sheet.SaveAs(saveAspath, XlFileFormat.xlCSV);

            workbook.Close(false, Type.Missing, Type.Missing);
            workbooks.Close();
            ExcelApp.Quit();
            Marshal.ReleaseComObject(sheet);
            Marshal.ReleaseComObject(sheets);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(ExcelApp);

            return dataImport.importCSVData(saveAspath);
        }
    }
}
