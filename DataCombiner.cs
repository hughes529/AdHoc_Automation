using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdHOC_Automation_APP
{
    class DataCombiner
    {
        public static DataTable combineDataTables(DataTable[] tables)
        {
            //make sure the headers are the same
            bool headersMatch = true;
            DataTable mainTable = tables[0];
            for (int i = 1; i < tables.Length; i++)
            {
                DataTable nextTable = tables[i];
                foreach (DataColumn c in mainTable.Columns)
                {
                    if (!nextTable.Columns.Contains(c.ColumnName))
                    {
                        headersMatch = false;
                    }
                }
            }

            if (headersMatch)
            {
                DataTable combineTable = mainTable.Clone();
                foreach(DataTable t in tables)
                {
                    foreach (DataRow row in t.Rows)
                    {
                        DataRow newRow = combineTable.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        combineTable.Rows.Add(newRow);
                    }
                }
                return combineTable;
            }
            else
            {
                throw new Exception("Headers do not match");
            }
        }
    }
}
