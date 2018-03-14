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
    private static void GetRowsByFilter()
    {
        DataTable customerTable = new DataTable("Customers");
        // Add columns
        customerTable.Columns.Add("id", typeof(int));
        customerTable.Columns.Add("name", typeof(string));

        // Set PrimaryKey
        customerTable.Columns[ "id" ].Unique = true;
        customerTable.PrimaryKey = new DataColumn[] 
            { customerTable.Columns["id"] };

        // Add ten rows
        for(int id=1; id<=10; id++)
        {
            customerTable.Rows.Add(
                new object[] { id, string.Format("customer{0}", id) });
        }
        customerTable.AcceptChanges();

        // Add another ten rows
        for(int id=11; id<=20; id++)
        {
            customerTable.Rows.Add(
                new object[] { id, string.Format("customer{0}", id) });
        }

        string expression;
        string sortOrder;
	
        expression = "id > 5";
        // Sort descending by column named CompanyName.
        sortOrder = "name DESC";
        // Use the Select method to find all rows matching the filter.
        DataRow[] foundRows = 
            customerTable.Select(expression, sortOrder, 
            DataViewRowState.Added);
	
        PrintRows(foundRows, "filtered rows");

        foundRows = customerTable.Select();
        PrintRows(foundRows, "all rows");
    }

    private static void PrintRows(DataRow[] rows, string label)
    {
        Console.WriteLine("\n{0}", label);
        if(rows.Length <= 0)
        {
            Console.WriteLine("no rows found");
            return;
        }
        foreach(DataRow row in rows)
        {
            foreach(DataColumn column in row.Table.Columns)
            {
                Console.Write("\table {0}", row[column]);
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>

}
