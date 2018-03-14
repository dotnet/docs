using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    protected DataAdapter adapter;

    // <Snippet1>
    public void ShowTableMappings() 
    {
        // ...
        // create adapter
        // ...
        adapter.TableMappings.Add("Categories","DataCategories");
        adapter.TableMappings.Add("Orders","DataOrders");
        adapter.TableMappings.Add("Products","DataProducts");
        string message = "Table Mappings:\n";
        for(int i=0;i < adapter.TableMappings.Count;i++) 
        {
            message += i.ToString() + " "
                + adapter.TableMappings[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }
    // </Snippet1>

}
