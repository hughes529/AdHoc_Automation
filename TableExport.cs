using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace AdHOC_Automation_APP
{
    class TableExport
    {
        public static void exportTableToCSV(DataTable table, string path)
        {
            exportTableToWeirdAssDelimitedCSV(table, path, ",");
        }

        public static void exportTableToWeirdAssDelimitedCSV(DataTable table, string path, string delimiter)
        {
            //remove primary key column
            if (table.Columns.Contains("PrimaryKey"))
            {
                table.PrimaryKey = null;
                table.Columns.Remove("PrimaryKey");
            }

            //make string builder and get header names as array, transfer array to string joined by delimiter
            StringBuilder builder = new StringBuilder();
            string[] columns = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            string columnString = "";
            for (int i = 0; i < columns.Length; i++)
            {
                string s = columns[i];
                if (i == columns.Length - 1)
                {
                    columnString += "\"" + s + "\"";//don't add comma to last one
                }
                else
                {
                    columnString += "\"" + s + "\"" + delimiter;
                }
            }
            builder.AppendLine(columnString);

            //same thing for each row
            foreach (DataRow row in table.Rows)
            {
                string rowString = "";
                string[] rowData = row.ItemArray.Select(field => field.ToString()).ToArray();
                for (int i = 0; i < rowData.Length; i++)
                {
                    string s = rowData[i];
                    if (i == rowData.Length - 1)
                    {
                        rowString += "\"" + s + "\"";//don't add comma to last one
                    }
                    else
                    {
                        rowString += "\"" + s + "\"" + delimiter;
                    }
                }
                builder.AppendLine(rowString);
            }

            File.WriteAllText(path, builder.ToString());
        }
    }
}
