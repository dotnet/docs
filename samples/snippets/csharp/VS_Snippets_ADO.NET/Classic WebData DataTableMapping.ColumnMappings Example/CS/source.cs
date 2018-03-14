using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    protected DataColumnMappingCollection mappings;

    // <Snippet1>
    public void CreateDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        DataColumnMapping[] columns = {};
        // Copy mappings to array    
        mappings.CopyTo(columns, 0);
        DataTableMapping mapping =
            new DataTableMapping("Categories", "DataCategories", columns);    
    }
    // </Snippet1>

}
