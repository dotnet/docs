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
    private void DemonstrateEnforceConstraints()
    {
        // Create a DataSet with one table, one column and 
        // a UniqueConstraint.
        DataSet dataSet= new DataSet("dataSet");
        DataTable table = new DataTable("table");
        DataColumn column = new DataColumn("col1");

        // A UniqueConstraint is added when the Unique 
        // property is true.
        column.Unique=true;
        table.Columns.Add(column);
        dataSet.Tables.Add(table);
        Console.WriteLine("constraints.count: " + 
            table.Constraints.Count);

        // add five rows.
        DataRow row ;
        for(int i=0;i<5;i++)
        {
            row = table.NewRow();
            row["col1"] = i;
            table.Rows.Add(row);
        }
        table.AcceptChanges();
    
        dataSet.EnforceConstraints=false;
        // Change the values of all rows to 1.
        foreach(DataRow thisRow in table.Rows)
        {
            thisRow["col1"]=1;
            //Console.WriteLine("\table" + thisRow[0]);
        }
        try
        {
            dataSet.EnforceConstraints=true;
        }
        catch(System.Data.ConstraintException e)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                e.GetType());
        }
    }
    // </Snippet1>

}
