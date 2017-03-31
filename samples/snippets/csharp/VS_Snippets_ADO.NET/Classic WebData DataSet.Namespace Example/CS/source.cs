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
    private void ReadData(DataSet thisDataSet)
    {
        thisDataSet.Namespace = "CorporationA";
        thisDataSet.Prefix = "DivisionA";

        // Read schema and data.
        string fileName = "CorporationA_Schema.xml";
        thisDataSet.ReadXmlSchema(fileName);
        fileName = "DivisionA_Report.xml";
        thisDataSet.ReadXml(fileName);
    }
    // </Snippet1>

}
