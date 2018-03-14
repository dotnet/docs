using System;
using System.Data;

class Class1
{
    [STAThread]
    static void Main()
    {
        TestGetTypeName();
    }
    // <Snippet1>
    private static void TestGetTypeName()
    {
        DataTable table = GetCustomers();
        using (DataTableReader reader = new DataTableReader(table))
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine("{0}: {1}", reader.GetName(i), 
                    reader.GetDataTypeName(i));
            }
        }
        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();
        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string ));
        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        table.Rows.Add(new object[] { 2, "Andy" });
        table.Rows.Add(new object[] { 3, "Peter" });
        table.Rows.Add(new object[] { 4, "Russ" });
        return table;
    }
    // </Snippet1>
}

