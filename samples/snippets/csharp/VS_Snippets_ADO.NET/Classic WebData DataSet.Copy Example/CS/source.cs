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
    private void CopyDataSet(DataSet dataSet)
    {
        // Create an object variable for the copy.
        DataSet copyDataSet;
        copyDataSet = dataSet.Copy();

        // Insert code to work with the copy.
    }
    // </Snippet1>

}
