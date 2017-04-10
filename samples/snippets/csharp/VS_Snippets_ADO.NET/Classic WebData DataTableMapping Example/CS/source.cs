using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    protected DataTableMappingCollection tableMappings;

    // <Snippet1>
    public void AddDataTableMapping() 
    {
        // ...
        // create tableMappings
        // ...
        DataTableMapping mapping =
            new DataTableMapping("Categories","DataCategories");
        tableMappings.Add((Object) mapping);
        Console.WriteLine("Table {0} added to {1} table mapping collection.",
            mapping.ToString(), tableMappings.ToString());
    }
    // </Snippet1>

}
