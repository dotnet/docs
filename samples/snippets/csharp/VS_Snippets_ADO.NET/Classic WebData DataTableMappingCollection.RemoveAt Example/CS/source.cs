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
    public void RemoveDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        if (mappings.Contains(7))
            mappings.RemoveAt(7);
    }
    // </Snippet1>

}
