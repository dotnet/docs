using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    protected DataTableMappingCollection mappings;

    // <Snippet1>
    public void PushIntoArray() 
    {
        // ...
        // create DataTableMappingCollection collection mappings
        // ...
        DataTableMapping[] tables = {};
        mappings.CopyTo(tables, 0);
        mappings.Clear();
    }
    // </Snippet1>

}
