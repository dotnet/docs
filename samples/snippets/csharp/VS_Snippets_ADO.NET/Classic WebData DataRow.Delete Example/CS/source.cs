using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void DemonstrateDeleteRow()
    {
        // Create a simple DataTable with two columns and ten rows.
        DataTable table = new DataTable("table");
        DataColumn idColumn = new DataColumn("id",
            Type.GetType("System.Int32"));
        idColumn.AutoIncrement=true;
        DataColumn itemColumn = new DataColumn("item", 
            Type.GetType("System.String"));
        table.Columns.Add(idColumn);
        table.Columns.Add(itemColumn);

        // Add ten rows.
        DataRow newRow;
         
        for(int i = 0; i <10; i++)
        {
            newRow = table.NewRow();
            newRow["item"] = "Item " + i;
            table.Rows.Add(newRow);
        }
        table.AcceptChanges();

        DataRowCollection itemColumns = table.Rows;
        itemColumns[0].Delete();
        itemColumns[2].Delete();
        itemColumns[3].Delete();
        itemColumns[5].Delete();
        Console.WriteLine(itemColumns[3].RowState.ToString());

        // Reject changes on one deletion.
        itemColumns[3].RejectChanges();

        // Change the value of the column so it stands out.
        itemColumns[3]["item"] = "Deleted, Undeleted, Edited";

        // Accept changes on others.
        table.AcceptChanges();

        // Print the remaining row values.
        foreach(DataRow row in table.Rows)
        {
            Console.WriteLine(row[0] + "\table" + row[1]);
        }
    }
    // </Snippet1>

}
