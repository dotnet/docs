using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    protected DataSet dataSet;
    protected DataTableMapping mapping;

    // <Snippet1>
    public void CreateDataTable() 
    {
        // ...
        // create dataSet and mapping
        // ...
        DataTable table = mapping.GetDataTableBySchemaAction
            (dataSet, MissingSchemaAction.Ignore);
    }
    // </Snippet1>

}
