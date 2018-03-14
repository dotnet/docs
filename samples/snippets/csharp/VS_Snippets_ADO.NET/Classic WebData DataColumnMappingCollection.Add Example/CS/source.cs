using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection mappings;
    protected DataColumnMapping mapping;

    // <Snippet1>
    public void ChangedMyMind() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains((Object) mapping))
            mappings.Remove((Object) mapping);
        else 
        {
            mappings.Add((Object) mapping);
            Console.WriteLine("Index of new mapping: "
                + mappings.IndexOf((Object) mapping));
        }
    }
    // </Snippet1>

}
