using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection columnMappings;


    // <Snippet1>

    public void RemoveDataColumnMapping() 
    {
        // ...
        // create columnMappings
        // ...
        if (columnMappings.Contains("Picture"))
            columnMappings.RemoveAt("Picture");
    }
    // </Snippet1>

}
