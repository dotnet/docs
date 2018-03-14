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
    private void WriteSchemaWithXmlTextWriter(DataSet thisDataSet)
    {
        // Set the file path and name. Modify this for your purposes.
        string filename="SchemaDoc.xml";

        // Create a FileStream object with the file path and name.
        System.IO.FileStream stream = new System.IO.FileStream
            (filename,System.IO.FileMode.Create);

        // Create a new XmlTextWriter object with the FileStream.
        System.Xml.XmlTextWriter writer = 
            new System.Xml.XmlTextWriter(stream, 
            System.Text.Encoding.Unicode);

        // Write the schema into the DataSet and close the reader.
        thisDataSet.WriteXmlSchema(writer );
        writer.Close();
    }
    // </Snippet1>

}
