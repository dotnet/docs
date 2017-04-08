//<Snippet1>
using System;
using System.Data;
using System.Globalization;

namespace GlobalLibrary
{
    public class MakeDataTables
    {
        // Violates rule: SetLocaleForDataTypes.
        public DataTable MakeBadTable()
        {
            DataTable badTable = new DataTable("Customers");
            DataColumn keyColumn = badTable.Columns.Add("ID", typeof(Int32));
            keyColumn.AllowDBNull = false;
            keyColumn.Unique = true;
            badTable.Columns.Add("LastName", typeof(String));
            badTable.Columns.Add("FirstName", typeof(String));
            return badTable;
        }

        public DataTable MakeGoodTable()
        {
            DataTable goodTable = new DataTable("Customers");
            // Satisfies rule: SetLocaleForDataTypes.
            goodTable.Locale = CultureInfo.InvariantCulture;
            DataColumn keyColumn = goodTable.Columns.Add("ID", typeof(Int32));
            
            keyColumn.AllowDBNull = false;
            keyColumn.Unique = true;
            goodTable.Columns.Add("LastName", typeof(String));
            goodTable.Columns.Add("FirstName", typeof(String));
            return goodTable;
        }
    }
}
//</Snippet1>
