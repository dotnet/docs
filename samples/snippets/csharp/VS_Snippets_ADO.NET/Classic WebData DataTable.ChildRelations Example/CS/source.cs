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
    private static void GetChildRowsFromDataRelation()
    {
        /* For each row in the table, get the child rows using the
        ChildRelations. For each item in the array, print the value
        of each column. */
        DataTable table = CreateDataSet().Tables["Customers"];
        DataRow[] childRows;
        foreach(DataRelation relation in table.ChildRelations)
        {
            foreach(DataRow row in table.Rows)
            {
                PrintRowValues(new DataRow[] {row}, "Parent Row");
                childRows = row.GetChildRows(relation);
                // Print values of rows.
                PrintRowValues(childRows, "child rows");
            }
        }
    }

    public static DataSet CreateDataSet()
    {
        // create a DataSet with one table, two columns
        DataSet dataSet = new DataSet();

        // create Customer table
        DataTable table = new DataTable("Customers");
        dataSet.Tables.Add(table);
        table.Columns.Add("customerId", typeof(int)).AutoIncrement = true;
        table.Columns.Add("name", typeof(string));
        table.PrimaryKey = new DataColumn[] { table.Columns["customerId"] };

        // create Orders table
        table = new DataTable("Orders");
        dataSet.Tables.Add(table);
        table.Columns.Add("orderId", typeof(int)).AutoIncrement = true;
        table.Columns.Add("customerId", typeof(int));
        table.Columns.Add("amount", typeof(double));
        table.PrimaryKey = new DataColumn[] { table.Columns["orderId"] };

        // create relation
        dataSet.Relations.Add(dataSet.Tables["Customers"].Columns["customerId"],
            dataSet.Tables["Orders"].Columns["customerId"]);
	
        // populate the tables
        int orderId = 1;
        for(int customerId=1; customerId<=10; customerId++)
        {
            // add customer record
            dataSet.Tables["Customers"].Rows.Add(
                new object[] { customerId, 
                string.Format("customer{0}", customerId) });
		
            // add 5 order records for each customer
            for(int i=1; i<=5; i++)
            {
                dataSet.Tables["Orders"].Rows.Add(
                    new object[] { orderId++, customerId, orderId * 10 });
            }
        }

        return dataSet;
    }

    private static void PrintRowValues(DataRow[] rows, string label)
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
