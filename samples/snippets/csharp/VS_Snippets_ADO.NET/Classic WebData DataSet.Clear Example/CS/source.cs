using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void ClearDataSet(DataSet dataSet)
    {
        // To test, print the number rows in each table.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName + "Rows.Count = " 
                + table.Rows.Count.ToString());
        }
        // Clear all rows of each table.
        dataSet.Clear();

        // Print the number of rows again.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName + "Rows.Count = "  
                + table.Rows.Count.ToString());
        }
    }
    // </Snippet1>

}
