using System;
using System.Data;


class Program
{
    static void Main()
    {
        DemonstrateDataView();
    }
    // <Snippet1>
    private static void DemonstrateDataView()
    {
        // Create a DataTable with three columns.
        DataTable table = new DataTable("NewTable");
        Console.WriteLine("Original table name: " + table.TableName);
        DataColumn column = new DataColumn("ID", typeof(System.Int32));
        table.Columns.Add(column);

        column = new DataColumn("Category", typeof(System.String));
        table.Columns.Add(column);

        column = new DataColumn("Product", typeof(System.String));
        table.Columns.Add(column);

        column = new DataColumn("QuantityInStock", typeof(System.Int32));
        table.Columns.Add(column);


        // Add some items.
        DataRow row = table.NewRow();
        row.ItemArray = new object[] { 1, "Fruit", "Apple", 14 };
        table.Rows.Add(row);

        row = table.NewRow();
        row.ItemArray = new object[] { 2, "Fruit", "Orange", 27 };
        table.Rows.Add(row);

        row = table.NewRow();
        row.ItemArray = new object[] { 3, "Bread", "Muffin", 23 };
        table.Rows.Add(row);

        row = table.NewRow();
        row.ItemArray = new object[] { 4, "Fish", "Salmon", 12 };
        table.Rows.Add(row);

        // Mark all rows as "accepted". Not really required
        // for this particular example.
        table.AcceptChanges();

        // Print current table values.
        PrintTableOrView(table, "Current Values in Table");

        DataView view = new DataView(table);
        view.RowFilter = "QuantityInStock > 15";
        PrintTableOrView(view, "Current Values in View");

        DataTable newTable = view.ToTable("FilteredTable");
        PrintTableOrView(newTable, "Table created from filtered DataView");
        Console.WriteLine("New table name: " + newTable.TableName);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static void PrintTableOrView(DataView dv, string label)
    {
        System.IO.StringWriter sw;
        string output;
        DataTable table = dv.Table;

        Console.WriteLine(label);

        // Loop through each row in the view.
        foreach (DataRowView rowView in dv)
        {
            sw = new System.IO.StringWriter();

            // Loop through each column.
            foreach (DataColumn col in table.Columns)
            {
                // Output the value of each column's data.
                sw.Write(rowView[col.ColumnName].ToString() + ", ");
            }
            output = sw.ToString();
            // Trim off the trailing ", ", so the output looks correct.
            if (output.Length > 2)
            {
                output = output.Substring(0, output.Length - 2);
            }
            // Display the row in the console window.
            Console.WriteLine(output);
        }
        Console.WriteLine();
    }

    private static void PrintTableOrView(DataTable table, string label)
    {
        System.IO.StringWriter sw;
        string output;

        Console.WriteLine(label);

        // Loop through each row in the table.
        foreach (DataRow row in table.Rows)
        {
            sw = new System.IO.StringWriter();
            // Loop through each column.
            foreach (DataColumn col in table.Columns)
            {
                // Output the value of each column's data.
                sw.Write(row[col].ToString() + ", ");
            }
            output = sw.ToString();
            // Trim off the trailing ", ", so the output looks correct.
            if (output.Length > 2)
            {
                output = output.Substring(0, output.Length - 2);
            }
            // Display the row in the console window.
            Console.WriteLine(output);
        } //
        Console.WriteLine();
    }
    // </Snippet1>
}

