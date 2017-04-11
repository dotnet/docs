using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataTableMapping tableMapping;


    // <Snippet1>

    public void ShowColumnMappings() 
    {
        // ...
        // create tableMapping
        // ...
        tableMapping.ColumnMappings.Add("Category Name","DataCategory");
        tableMapping.ColumnMappings.Add("Description","DataDescription");
        tableMapping.ColumnMappings.Add("Picture","DataPicture");
        Console.WriteLine("Column Mappings");
        for(int i=0;i < tableMapping.ColumnMappings.Count;i++) 
        {
            Console.WriteLine("  {0} {1}", i,
                tableMapping.ColumnMappings[i].ToString());
        }
    }
    // </Snippet1>

}
