using System;
using System.Data;




class Program
{
// <Snippet1>
    static DataTable customerTable;
    static DataTable productTable;
    static DataTable emptyTable;

    static void Main()
    {
        DataSet dataSet = new DataSet();

        // Add some DataTables to the DataSet, including
        // an empty DataTable:
        emptyTable = new DataTable();
        productTable = GetProducts();
        customerTable = GetCustomers();

        dataSet.Tables.Add(customerTable);
        dataSet.Tables.Add(emptyTable);
        dataSet.Tables.Add(productTable);
        TestCreateDataReader(dataSet);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static void TestCreateDataReader(DataSet dataSet)
    {
        // Given a DataSet, retrieve a DataTableReader
        // allowing access to all the DataSet's data.
        // Even though the dataset contains three DataTables,
        // this code will only display the contents of two of them,
        // because the code has limited the results to the 
        // DataTables stored in the tables array. Because this
        // parameter is declared using the ParamArray keyword, 
        // you could also include a list of DataTable instances 
        // individually, as opposed to supplying an array of 
        // DataTables, as in this example:
        using (DataTableReader reader = 
           dataSet.CreateDataReader(productTable, emptyTable))
        {
            do
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("Empty DataTableReader");
                }
                else
                {
                    PrintColumns(reader);
                }
                Console.WriteLine("========================");
            } while (reader.NextResult());
        }
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        table.Rows.Add(new object[] { 2, "Andy" });
        table.Rows.Add(new object[] { 3, "Peter" });
        table.Rows.Add(new object[] { 4, "Russ" });
        return table;
    }

    private static DataTable GetProducts()
    {
        // Create sample Products table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Wireless Network Card" });
        table.Rows.Add(new object[] { 2, "Hard Drive" });
        table.Rows.Add(new object[] { 3, "Monitor" });
        table.Rows.Add(new object[] { 4, "CPU" });
        return table;
    }

    private static void PrintColumns(DataTableReader reader)
    {
        // Loop through all the rows in the DataTableReader
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader[i] + " ");
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}
