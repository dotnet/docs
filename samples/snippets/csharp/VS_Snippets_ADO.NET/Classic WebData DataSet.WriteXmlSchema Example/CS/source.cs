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
    private void WriteSchemaWithFileStream(DataSet thisDataSet)
    {
        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Create the FileStream object with the file name. 
        // Use FileMode.Create.
        System.IO.FileStream stream = 
            new System.IO.FileStream(filename,System.IO.FileMode.Create);

        // Write the schema to the file.
        thisDataSet.WriteXmlSchema(stream);

        // Close the FileStream.
        stream.Close();
    }
    // </Snippet1>

}
