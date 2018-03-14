using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void DemonstrateRowBeginEdit()
    {
        DataTable table = new DataTable("table1");
        DataColumn column = new 
            DataColumn("col1",Type.GetType("System.Int32"));
        table.RowChanged+=new 
            DataRowChangeEventHandler(Row_Changed);
        table.Columns.Add(column);

        // Add a UniqueConstraint to the table.
        table.Constraints.Add(new UniqueConstraint(column));

        // Add five rows.
        DataRow newRow;
       
        for(int i = 0;i<5; i++)
        {
            // RowChanged event will occur for every addition.
            newRow= table.NewRow();
            newRow[0]= i;
            table.Rows.Add(newRow);
        }
        // AcceptChanges.
        table.AcceptChanges();

        // Invoke BeginEdit on each.
        Console.WriteLine(
            "\n Begin Edit and print original and proposed values \n");
        foreach(DataRow row in table.Rows)
        {
       
            row.BeginEdit();
            row[0]=(int) row[0]+10;
            Console.Write("\table Original \table" + 
                row[0, DataRowVersion.Original]);
            Console.Write("\table Proposed \table" + 
                row[0,DataRowVersion.Proposed] + "\n");
        }
        Console.WriteLine("\n");
        // Accept changes
        table.AcceptChanges();
        // Change two rows to identical values after invoking BeginEdit.
        table.Rows[0].BeginEdit();
        table.Rows[1].BeginEdit();
        table.Rows[0][0]= 100;
        table.Rows[1][0]=100;
        try
        {
            /* Now invoke EndEdit. This will cause the UniqueConstraint
               to be enforced.*/
            table.Rows[0].EndEdit();
            table.Rows[1].EndEdit();
        }
        catch(Exception e)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                e.GetType());
        }
    }
 
    private void Row_Changed(object sender, 
        System.Data.DataRowChangeEventArgs e)
    {
        DataTable table = (DataTable)  sender;
        Console.WriteLine("RowChanged " + e.Action.ToString() 
            + "\table" + e.Row.ItemArray[0]);
    }
    // </Snippet1>

}
