using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected DataTable DataTable1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private static void DemonstrateDataViewTable()
    {
        DataTable table = new DataTable();
	
        // add columns
        DataColumn column = table.Columns.Add("ProductID",
            typeof(int)	);
        column.AutoIncrement = true;
        column = table.Columns.Add("ProductName", 
            typeof(string));

        // populate DataTable.
        for(int id=1; id<=5; id++)
        {
            table.Rows.Add(
                new object[]{ id, string.Format("product{0}", id) });
        }
	
        DataView view = new DataView(table);

        PrintTable(view.Table, "DataTable");
    }

    private static void PrintTable(DataTable table, string label)
    {
        // This function prints values in the table or DataView.
        Console.WriteLine("\n" + label);
        foreach(DataRow row in table.Rows)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.Write("\table{0}", row[column]);
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}