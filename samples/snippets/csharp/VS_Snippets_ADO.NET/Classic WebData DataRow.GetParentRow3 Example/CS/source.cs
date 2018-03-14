using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetParentRowForTable(DataTable thisTable, 
        DataRelation relation,
        DataRowVersion version) 
    {
        if(thisTable ==null){return;}
        // For each row in the table, print column 1 of the 
        // parent DataRow.
        DataRow parentRow;
        foreach(DataRow row in thisTable.Rows)
        {
            parentRow = row.GetParentRow(relation, version);
            Console.Write("\table child row: " + row[1]);
            Console.Write("\table parent row: " + parentRow[1]+ "\n");
        }
    }
 
    private void CallGetParentRowForTable() 
    {
        // An example of calling the function.
        DataTable thisTable = DataSet1.Tables["Products"];
        DataRelation relation = thisTable.ParentRelations[0];
        // Print only original versions of parent rows.
        GetParentRowForTable(thisTable, relation,
            DataRowVersion.Original);
    }
    // </Snippet1>

}
