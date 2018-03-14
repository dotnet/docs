using System;
using System.Data;

class Program
{
    static void Main()
    {
        DemonstrateReadWriteXMLSchemaWithReader();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    // <Snippet1>
    private static void DemonstrateReadWriteXMLSchemaWithReader()
    {
        DataTable table = CreateTestTable("XmlDemo");
        PrintSchema(table, "Original table");

        // Write the schema to XML in a memory stream.
        System.IO.MemoryStream xmlStream = 
            new System.IO.MemoryStream();
        table.WriteXmlSchema(xmlStream);

        // Rewind the memory stream.
        xmlStream.Position = 0;

        DataTable newTable = new DataTable();
        System.Xml.XmlTextReader reader = 
            new System.Xml.XmlTextReader(xmlStream);
        newTable.ReadXmlSchema(reader);

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

