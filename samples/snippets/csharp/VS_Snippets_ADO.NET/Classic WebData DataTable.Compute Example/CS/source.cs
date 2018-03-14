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
    private void ComputeBySalesSalesID(DataSet dataSet)
    {
        // Presumes a DataTable named "Orders" that has a column named "Total."
        DataTable table;
        table = dataSet.Tables["Orders"];

        // Declare an object variable.
        object sumObject;
        sumObject = table.Compute("Sum(Total)", "EmpID = 5");
    }
    // </Snippet1>

}
