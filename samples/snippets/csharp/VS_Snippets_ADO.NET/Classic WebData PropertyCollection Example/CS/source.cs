using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void AddTimeStamp()
    {
        //Create a new DataTable.
        DataTable table = new DataTable("NewTable");

        //Get its PropertyCollection.
        PropertyCollection properties = table.ExtendedProperties;

        //Add a timestamp value to the PropertyCollection.
        properties.Add("TimeStamp", DateTime.Now);

        // Print the timestamp.
        Console.WriteLine(properties["TimeStamp"]);
    }
    // </Snippet1>

}
