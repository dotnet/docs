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
    public void AddDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        DataTableMapping mapping =
            new DataTableMapping("Categories","DataCategories");
        mappings.Add((Object) mapping);
        Console.WriteLine("Table " + mapping.ToString() + " added to " +
            "table mapping collection " + mappings.ToString());
    }
    // </Snippet1>

}
