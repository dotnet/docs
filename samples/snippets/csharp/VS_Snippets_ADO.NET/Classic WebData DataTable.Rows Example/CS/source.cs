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
    private void PrintRows(DataSet dataSet)
    {
        // For each table in the DataSet, print the values of each row.
        foreach(DataTable thisTable in dataSet.Tables)
        {
            // For each row, print the values of each column.
            foreach(DataRow row in thisTable.Rows)
            {
                foreach(DataColumn column in thisTable.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
        }
    }
 
 
    private void AddARow(DataSet dataSet)
    {
        DataTable table;
        table = dataSet.Tables["Suppliers"];
        // Use the NewRow method to create a DataRow with 
        // the table's schema.
        DataRow newRow = table.NewRow();

        // Set values in the columns:
        newRow["CompanyID"] = "NewCompanyID";
        newRow["CompanyName"] = "NewCompanyName";

        // Add the row to the rows collection.
        table.Rows.Add(newRow);
    }
    // </Snippet1>

}
