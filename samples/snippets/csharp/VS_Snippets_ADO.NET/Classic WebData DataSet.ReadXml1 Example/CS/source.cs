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
    private void DemonstrateReadWriteXMLDocumentWithFileStream()
    {
        // Create a DataSet with one table and two columns.
        DataSet originalDataSet = new DataSet("dataSet");
        DataTable table = new DataTable("table");
        DataColumn idColumn = new DataColumn("id", 
            Type.GetType("System.Int32"));
        idColumn.AutoIncrement= true;

        DataColumn itemColumn = new DataColumn("item");
        table.Columns.Add(idColumn);
        table.Columns.Add(itemColumn);
        originalDataSet.Tables.Add(table);
        // Add ten rows.

        DataRow newRow;
        for(int i = 0; i < 10; i++)
        {
            newRow = table.NewRow();
            newRow["item"]= "item " + i;
            table.Rows.Add(newRow);
        }
        originalDataSet.AcceptChanges();

        // Print out values of each table in the DataSet  
        // using the function defined below.
        PrintValues(originalDataSet, "Original DataSet");

        // Write the schema and data to XML file with FileStream.
        string xmlFilename = "XmlDocument.xml";
        System.IO.FileStream streamWrite = new System.IO.FileStream
            (xmlFilename, System.IO.FileMode.Create);

        // Use WriteXml to write the XML document.
        originalDataSet.WriteXml(streamWrite);

        // Close the FileStream.
        streamWrite.Close();
       
        // Dispose of the original DataSet.
        originalDataSet.Dispose();
        // Create a new DataSet.
        DataSet newDataSet = new DataSet("New DataSet");
       
        // Read the XML document back in. 
        // Create new FileStream to read schema with.
        System.IO.FileStream streamRead = new System.IO.FileStream
            (xmlFilename,System.IO.FileMode.Open);
        newDataSet.ReadXml(streamRead);

        // Print out values of each table in the DataSet 
        // using the function defined below.
        PrintValues(newDataSet,"New DataSet");
    }
 
    private void PrintValues(DataSet dataSet, string label)
    {
        Console.WriteLine("\n" + label);
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine("TableName: " + table.TableName);
            foreach(DataRow row in table.Rows)
            {
                foreach(DataColumn column in table.Columns)
                {
                    Console.Write("\table " + row[column] );
                }
                Console.WriteLine();
            }
        }
    }
    // </Snippet1>

}
