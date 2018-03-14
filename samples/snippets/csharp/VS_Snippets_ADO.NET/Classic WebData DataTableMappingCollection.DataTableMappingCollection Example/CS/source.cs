using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateTableMappings() 
    {
        DataTableMappingCollection mappings = 
            new DataTableMappingCollection();
        mappings.Add("Categories","DataCategories");
        mappings.Add("Orders","DataOrders");
        mappings.Add("Products","DataProducts");
        string message = "TableMappings:\n";
        for(int i=0;i < mappings.Count;i++)
        {
            message += i.ToString() + " " 
                + mappings[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }
    // </Snippet1>

}
