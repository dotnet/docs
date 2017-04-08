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
    
        DataColumnMapping[] columns1 = {};
        mappings.CopyTo(columns1, 0);
        DataTableMapping mapping =
            new DataTableMapping("Categories", "DataCategories", columns1);
    
        DataColumnMapping[] columns2 = {};
        mapping.ColumnMappings.CopyTo(columns2, 0);
    }
    // </Snippet1>

}
