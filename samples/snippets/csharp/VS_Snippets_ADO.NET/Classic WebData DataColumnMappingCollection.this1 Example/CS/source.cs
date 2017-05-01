using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection columnMappings;


    // <Snippet1>
    public void FindDataColumnMapping() 
    {
        // ...
        // create columnMappings
        // ...
        if (!columnMappings.Contains("Description"))
            Console.WriteLine("Error: no such table in collection.");
        else
        {
            Console.WriteLine("Name {0}", 
                columnMappings["Description"].ToString());
            Console.WriteLine("Index: {0}", 
                columnMappings.IndexOf("Description").ToString());
        }
    }
    // </Snippet1>

}
