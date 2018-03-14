#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

#endregion

namespace MappingTypeCS
{
    class Program
    {
        static void Main()
        {
            DataTable dataTable = MakeTable();
            GetColumnMapping(dataTable);
            Console.ReadLine();

        }
        // <Snippet1>
        static private void GetColumnMapping(DataTable dataTable)
        {
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                Console.WriteLine(dataColumn.ColumnMapping.ToString());
            }
        }
        // </Snippet1>

        static private DataTable MakeTable()
        {
            // Make a simple table with one column.
            DataTable dt = new DataTable("dataTable");
            DataColumn firstName = new DataColumn("FirstName", Type.GetType("System.String"));
            dt.Columns.Add(firstName);
            return dt;
        }


    }
}
