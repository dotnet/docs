using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection mappings;
    protected DataColumnMapping mapping;


    // <Snippet1>
    public void FindDataColumnMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains("Description"))
            mapping = DataColumnMappingCollection.GetColumnMappingBySchemaAction
                (mappings, "Description", MissingMappingAction.Ignore);
    }
    // </Snippet1>

}
