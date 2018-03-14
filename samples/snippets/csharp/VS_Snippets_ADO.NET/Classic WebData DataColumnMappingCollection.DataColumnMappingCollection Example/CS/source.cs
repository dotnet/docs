using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    public void CreateColumnMappings() 
    {
        DataColumnMappingCollection mappings =
            new DataColumnMappingCollection();
        mappings.Add("Category Name","DataCategory");
        mappings.Add("Description","DataDescription");
        mappings.Add("Picture","DataPicture");
        string myMessage = "ColumnMappings:\n";
        for(int i=0;i < mappings.Count;i++)
        {
            myMessage += i.ToString() + " " 
                + mappings[i].ToString() + "\n";
        }
        Console.WriteLine(myMessage);
    }
    // </Snippet1>

}
