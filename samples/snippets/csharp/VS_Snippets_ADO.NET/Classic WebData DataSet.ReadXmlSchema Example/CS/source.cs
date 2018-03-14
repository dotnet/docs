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
    private void ReadSchemaFromXmlTextReader()
    {
        // Create the DataSet to read the schema into.
        DataSet thisDataSet = new DataSet();

        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Create a FileStream object with the file path and name.
        System.IO.FileStream stream = new System.IO.FileStream
            (filename,System.IO.FileMode.Open);

        // Create a new XmlTextReader object with the FileStream.
        System.Xml.XmlTextReader xmlReader= 
            new System.Xml.XmlTextReader(stream);

        // Read the schema into the DataSet and close the reader.
        thisDataSet.ReadXmlSchema(xmlReader);
        xmlReader.Close();
    }
    // </Snippet1>

}
