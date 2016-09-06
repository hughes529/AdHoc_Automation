using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace AdHOC_Automation_APP
{
    class dataImport
    {
         public static DataTable importCSVData(string filePath)
        {
            return importCSVData(filePath, ",");
        }

        public static DataTable importCSVData(string filePath, string delimeter)
        {
            DataTable importedData = new DataTable();
            //try opening filePath into a textfiledparser
            try
            {
                //setup parser, delimeter and qualifier
                TextFieldParser parser = new TextFieldParser(filePath, Encoding.UTF7);
                parser.SetDelimiters(new string[] { delimeter});
                parser.HasFieldsEnclosedInQuotes = true;
                
                //grab the first row as columns
                string[] columns = parser.ReadFields();

                //add in columns
                for (int i = 0; i<columns.Length; i++)
                {
                    string column = columns[i];
                    if (column.Length == 0)
                    {
                        column = "Unnamed Column";
                    }
                    //make sure the table doesnt already have the column
                    if (importedData.Columns.Contains(column))
                    {
                        column = getNewColumnName(column, importedData, 1);
                        DataColumn dataColumn = new DataColumn(column);
                        dataColumn.AllowDBNull = true;
                        importedData.Columns.Add(dataColumn);
                    }
                    else
                    {
                        DataColumn dataColumn = new DataColumn(column);
                        dataColumn.AllowDBNull = true;
                        importedData.Columns.Add(dataColumn);
                    }
                }

                //add in primary key 
                DataColumn idColumn = new DataColumn("PrimaryKey");
                idColumn.AutoIncrement = true;
                idColumn.AutoIncrementSeed = 1;
                idColumn.DataType = System.Type.GetType("System.Int32");
                importedData.Columns.Add(idColumn);
                importedData.PrimaryKey = new DataColumn[] { idColumn };

                //grab each line, add nulls as necessary and add row into table
                while (!parser.EndOfData)
                {
                    string[] rowData = parser.ReadFields();
                    DataRow newRow = importedData.NewRow();
                    for (int i = 0; i<rowData.Length; i++)
                    {
                        newRow.SetField(i, rowData[i]);
                    }
                    importedData.Rows.Add(newRow);
                }
                parser.Close();
            }
            catch 
            {
                throw;
            }
            return importedData;
        }

        //private static void checkHeaders(string[] headers)
        //{
        //    bool isUnique = headers.Distinct().Count() == headers.Count();
        //    while (!isUnique)
        //    {
        //        //iterate over each column name and compare to the other names, if there is a match add _# until the name is unique
        //        string[] headerCopy = new string[headers.Count()];
        //        headers.CopyTo(headerCopy, 0);
        //        foreach (string s in headerCopy)
        //        {
        //            int i = 0;
        //            int currentIndex = Array.IndexOf(headers, s);
        //            while (i < headerCopy.Count())
        //            {
        //                if (i != currentIndex)//skip over the current column or your going to have a bad time
        //                {
        //                    string header = (string)headerCopy.GetValue(i);
        //                    if (s.Equals(headers))
        //                    {
        //                        string newName = getNewColumnName(s, headerCopy, 1);
        //                        headers.SetValue(newName, currentIndex);
        //                    }
        //                    else
        //                    {
        //                        i++;
        //                    }
        //                }
        //                else
        //                {
        //                    i++;
        //                }
        //            }                    
        //        }
        //        isUnique = headers.Distinct().Count() == headers.Count();
        //    }
        //}

        private static string getNewColumnName(string name, DataTable table, int id)
        {
            string newName = name + "_" + id;;
            if (table.Columns.Contains(newName))
            {
                newName = getNewColumnName(name, table, id + 1);
            }
            return newName;
        }
    }
}
