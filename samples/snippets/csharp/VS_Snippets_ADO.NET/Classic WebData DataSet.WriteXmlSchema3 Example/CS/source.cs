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
    private void WriteSchemaToFile(DataSet thisDataSet)
    {
        // Set the file path and name. Modify this for your purposes.
        string filename="Schema.xml";

        // Write the schema to the file.
        thisDataSet.WriteXmlSchema(filename);
    }
    // </Snippet1>

}
