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
    private void CreateDataSet()
    {
        DataSet dataSet = new DataSet("SuppliersProducts");
        Console.WriteLine(dataSet.DataSetName);

        // Add a DataTable.
        dataSet.Tables.Add(new DataTable("Suppliers"));

        // Add a DataColumn to the DataTable.
        dataSet.Tables["Suppliers"].Columns.Add
            (new DataColumn("CompanyName", 
            System.Type.GetType("System.String")));
    }
    // </Snippet1>

}
