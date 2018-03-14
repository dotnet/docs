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
    private void GetClone(DataSet dataSet)
    {
        // Get a clone of the original DataSet.
        DataSet cloneSet = dataSet.Clone();

        // Insert code to work with clone of the DataSet.
    }
    // </Snippet1>

}
