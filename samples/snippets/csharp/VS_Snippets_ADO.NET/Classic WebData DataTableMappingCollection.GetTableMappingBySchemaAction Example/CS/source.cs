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
    protected DataTableMapping mapping;

    // <Snippet1>
    public void FindDataTableMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains("Categories")) 
        {
            mapping = DataTableMappingCollection.GetTableMappingBySchemaAction
                (mappings, "Categories", "", MissingMappingAction.Ignore);
        }
    }
    // </Snippet1>

}
