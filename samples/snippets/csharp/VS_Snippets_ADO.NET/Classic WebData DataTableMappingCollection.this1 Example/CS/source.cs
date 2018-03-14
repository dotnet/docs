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
    public void FindDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        if (!mappings.Contains("Categories"))
            Console.WriteLine("Error: no such table in collection");
        else
            Console.WriteLine
                ("Name: " + mappings["Categories"].ToString() + "\n"
                + "Index: " + mappings.IndexOf("Categories").ToString());
    }
    // </Snippet1>

}
