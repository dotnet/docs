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
    private void ReadSchemaFromStreamReader()
    {
        // Create the DataSet to read the schema into.
        DataSet thisDataSet = new DataSet();

        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Create a StreamReader object with the file path and name.
        System.IO.StreamReader readStream = 
            new System.IO.StreamReader(filename);

        // Invoke the ReadXmlSchema method with the StreamReader object.
        thisDataSet.ReadXmlSchema(readStream);

        // Close the StreamReader
        readStream.Close();
    }
    // </Snippet1>

}
