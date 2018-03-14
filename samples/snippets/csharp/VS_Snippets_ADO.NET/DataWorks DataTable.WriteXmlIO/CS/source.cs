using System;
using System.Data;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DataSet ds = new DataSet();
        DataTable customerTable = GetCustomers();
        DataTable orderTable = GetOrders();

        ds.Tables.Add(customerTable);
        ds.Tables.Add(orderTable);
        ds.Relations.Add("CustomerOrder",
            new DataColumn[] { customerTable.Columns[0] },
            new DataColumn[] { orderTable.Columns[1] }, true);

        System.IO.StringWriter writer = new System.IO.StringWriter();
        customerTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
        PrintOutput(writer, "Customer table, without hierarchy");

        writer = new System.IO.StringWriter();
        customerTable.WriteXml(writer, XmlWriteMode.WriteSchema, true);
        PrintOutput(writer, "Customer table, with hierarchy");

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(System.Int32));
        table.Columns.Add("Name", typeof(System.String));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        table.Rows.Add(new object[] { 2, "Andy" });
        table.Rows.Add(new object[] { 3, "Peter" });
        table.Rows.Add(new object[] { 4, "Russ" });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetOrders()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create three columns; OrderID, CustomerID, and OrderDate.
        table.Columns.Add(new DataColumn("OrderID", typeof(System.Int32)));
        table.Columns.Add(new DataColumn("CustomerID", typeof(System.Int32)));
        table.Columns.Add(new DataColumn("OrderDate", typeof(System.DateTime)));

        // Set the OrderID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { table.Columns[0] };

        table.Rows.Add(new object[] { 1, 1, "12/2/2003" });
        table.Rows.Add(new object[] { 2, 1, "1/3/2004" });
        table.Rows.Add(new object[] { 3, 2, "11/13/2004" });
        table.Rows.Add(new object[] { 4, 3, "5/16/2004" });
        table.Rows.Add(new object[] { 5, 3, "5/22/2004" });
        table.Rows.Add(new object[] { 6, 4, "6/15/2004" });
        table.AcceptChanges();
        return table;
    }

    private static void PrintOutput(System.IO.TextWriter writer, 
        string caption)
    {
        Console.WriteLine("==============================");
        Console.WriteLine(caption);
        Console.WriteLine("==============================");
        Console.WriteLine(writer.ToString());
    }
    // </Snippet1>
}

