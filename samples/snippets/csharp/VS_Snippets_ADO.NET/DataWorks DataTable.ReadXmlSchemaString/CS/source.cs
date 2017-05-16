using System;
using System.Data;

using System.Data;

class Program
{
    static void Main()
    {
        DemonstrateReadWriteXMLSchemaWithFile();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    // <Snippet1>
    private static void DemonstrateReadWriteXMLSchemaWithFile()
    {
        DataTable table = CreateTestTable("XmlDemo");
        PrintSchema(table, "Original table");

        // Write the schema to XML in a file.
        string xmlFile = "C:\\SchemaDemo.xml";
        table.WriteXmlSchema(xmlFile);

        DataTable newTable = new DataTable();
        newTable.ReadXmlSchema(xmlFile);

        // Print out values in the table.
        PrintSchema(newTable, "New table");
    }

    private static DataTable CreateTestTable(string tableName)
    {
        // Create a test DataTable with two columns and a few rows.
        DataTable table = new DataTable(tableName);
        DataColumn column = new DataColumn("id", typeof(System.Int32));
        column.AutoIncrement = true;
        table.Columns.Add(column);

        column = new DataColumn("item", typeof(System.String));
        table.Columns.Add(column);

        // Add ten rows.
        DataRow row;
        for (int i = 0; i <= 9; i++)
        {
            row = table.NewRow();
            row["item"] = "item " + i;
            table.Rows.Add(row);
        }

        table.AcceptChanges();
        return table;
    }

    private static void PrintSchema(DataTable table, string label)
    {
        // Display the schema of the supplied DataTable:
        Console.WriteLine(label);
        foreach (DataColumn column in table.Columns)
        {
            Console.WriteLine("\t{0}: {1}", column.ColumnName, 
                column.DataType.Name);
        }
        Console.WriteLine();
    }
    // </Snippet1>
}

