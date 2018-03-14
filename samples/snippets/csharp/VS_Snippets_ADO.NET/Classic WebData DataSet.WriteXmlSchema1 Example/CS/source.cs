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
    private void WriteSchemaWithStringWriter(DataSet thisDataSet)
    {
        // Create a new StringBuilder object.
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        // Create the StringWriter object with the StringBuilder object.
        System.IO.StringWriter writer = new System.IO.StringWriter(builder);

        // Write the schema into the StringWriter.
        thisDataSet.WriteXmlSchema(writer);

        // Print the string to the console window.
        Console.WriteLine(writer.ToString());
    }
    // </Snippet1>

}
