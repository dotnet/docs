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
    private void ReadSchemaFromFileStream(DataSet thisDataSet)
    {
        // Set the file path and name.
        // Modify this for your purposes.
        string filename="Schema.xml";

        // Create the FileStream object with the file name, 
        // and set to open the file.
        System.IO.FileStream stream = 
            new System.IO.FileStream(filename,System.IO.FileMode.Open);

        // Read the schema into the DataSet.
        thisDataSet.ReadXmlSchema(stream);

        // Close the FileStream.
        stream.Close();
    }
    // </Snippet1>

}
