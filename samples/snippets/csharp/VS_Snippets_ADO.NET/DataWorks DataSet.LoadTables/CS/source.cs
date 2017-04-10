using System;
using System.Data;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DataSet dataSet = new DataSet();

        DataTable customerTable = new DataTable();
        DataTable productTable = new DataTable();

        // This information is cosmetic, only.
        customerTable.TableName = "Customers";
        productTable.TableName = "Products";

        // Add the tables to the DataSet:
        dataSet.Tables.Add(customerTable);
        dataSet.Tables.Add(productTable);

        // Load the data into the existing DataSet. 
        DataTableReader reader = GetReader();
        dataSet.Load(reader, LoadOption.OverwriteChanges,
            customerTable, productTable);

        // Print out the contents of each table:
        foreach (DataTable table in dataSet.Tables)
        {
            PrintColumns(table);
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table.
        DataTable table = new DataTable();
        table.TableName = "Customers";

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 0, "Mary" });
        table.Rows.Add(new object[] { 1, "Andy" });
        table.Rows.Add(new object[] { 2, "Peter" });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetProducts()
    {
        // Create sample Products table.
        DataTable table = new DataTable();
        table.TableName = "Products";

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID",
            typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 0, "Wireless Network Card" });
        table.Rows.Add(new object[] { 1, "Hard Drive" });
        table.Rows.Add(new object[] { 2, "Monitor" });
        table.Rows.Add(new object[] { 3, "CPU" });
        table.AcceptChanges();
        return table;
    }

    private static void PrintColumns(DataTable table)
    {
        Console.WriteLine();
        Console.WriteLine(table.TableName);
        Console.WriteLine("=========================");
        // Loop through all the rows in the table:
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Console.Write(row[i] + " ");
            }
            Console.WriteLine();
        }
    }

    private static DataTableReader GetReader()
    {
        // Return a DataTableReader containing multiple
        // result sets, just for the sake of this demo.
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(GetCustomers());
        dataSet.Tables.Add(GetProducts());
        return dataSet.CreateDataReader();
    }
    // </Snippet1>
}
