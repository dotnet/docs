using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void SetRowErrors(DataTable table)
    {
        // Set error text for ten rows. 
        for(int i = 0; i < 10; i++)
        {
            // Insert column 1 value into each error.
            table.Rows[i].RowError = "ERROR: " 
                + table.Rows[i][1];
        }
        // Get the DataSet for the table, and test it for errors.
        DataSet dataSet = table.DataSet;
        TestForErrors(dataSet);
    }
 
    private void TestForErrors(DataSet dataSet)
    {
        // Test for errors. If DataSet has errors, test each table.
        if(dataSet.HasErrors)
        {
            foreach(DataTable tempDataTable in dataSet.Tables)
            {
                // If the table has errors, then print them.
                if(tempDataTable.HasErrors) 
                    PrintRowErrs(tempDataTable);
            }
            // Refresh the DataGrid to see the error-marked rows.
            dataGrid1.Refresh();
        }
    }
 
    private void PrintRowErrs(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            if(row.HasErrors) 
            {
                Console.WriteLine(row.RowError);
            }
        }
    }
    // </Snippet1>

}
