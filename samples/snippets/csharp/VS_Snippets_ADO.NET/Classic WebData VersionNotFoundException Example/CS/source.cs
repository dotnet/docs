using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void DemonstrateVersionNotFoundException()
    {
        // Create a DataTable with one column.
        DataTable table = new DataTable("NewTable");
        DataColumn column = new DataColumn("NewColumn");
        table.Columns.Add(column);
        DataRow newRow;
      
        for(int i = 0;i <10;i++)
        {
            newRow = table.NewRow();
            newRow["NewColumn"] = i;
            table.Rows.Add(newRow);
        }
        table.AcceptChanges();

        try
        {
            Console.WriteLine("Trying...");
            DataRow removedRow = table.Rows[9];
            removedRow.Delete();
            removedRow.AcceptChanges();
            // Try to get the Current row version.
            Console.WriteLine(removedRow[0,DataRowVersion.Current]);
 
        }
        catch(System.Data.VersionNotFoundException)
        {
            Console.WriteLine("Current version of row not found.");
        }
    }
    // </Snippet1>

}
