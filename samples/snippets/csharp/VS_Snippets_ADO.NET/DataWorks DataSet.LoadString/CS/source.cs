using System;
using System.Data;



using System.Data;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DataSet dataSet = new DataSet();

        DataTableReader reader = GetReader();

        // The tables listed as parameters for the Load method 
        // should be in the same order as the tables within the IDataReader.
        dataSet.Load(reader, LoadOption.Upsert, "Customers", "Products");
        foreach (DataTable table in dataSet.Tables)
        {
            PrintColumns(table);
        }

        // Now try the example with the DataSet
        // already filled with data:
        dataSet = new DataSet();
        dataSet.Tables.Add(GetCustomers());
        dataSet.Tables.Add(GetProducts());

        // Retrieve a data reader containing changed data:
        reader = GetReader();

        // Load the data into the existing DataSet. Retrieve the order of the
        // the data in the reader from the
        // list of table names in the parameters. If you specify
        // a new table name here, the Load method will create
        // a corresponding new table.
        dataSet.Load(reader, LoadOption.Upsert, 
            "NewCustomers", "Products");
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
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
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
