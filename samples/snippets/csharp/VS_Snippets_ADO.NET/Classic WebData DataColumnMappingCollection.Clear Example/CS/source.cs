using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection mappings;

    // <Snippet1>
    public bool PushIntoArray() 
    {
        // ...
        // create mappings
        // ...
        DataColumnMapping[] columns = new DataColumnMapping[0];
        mappings.CopyTo(columns, 0);
        mappings.Clear();
        return true;
    }
    // </Snippet1>

}
