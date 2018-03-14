using System;
using System.Data;



class Program
{
    static void Main()
    {
        TestCreateDataReader(GetCustomers());
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    // <Snippet1>
    private static void TestCreateDataReader(DataTable dt)
    {
        // Given a DataTable, retrieve a DataTableReader
        // allowing access to all the tables' data:
        using (DataTableReader reader = dt.CreateDataReader())
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
