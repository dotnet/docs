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
    private void WriteXmlToFile(DataSet thisDataSet) 
    {
        if (thisDataSet == null) { return; }

        // Create a file name to write to.
        string filename = "XmlDoc.xml";

        // Write to the file with the WriteXml method.
        thisDataSet.WriteXml(filename);
    }
    // </Snippet1>

}
