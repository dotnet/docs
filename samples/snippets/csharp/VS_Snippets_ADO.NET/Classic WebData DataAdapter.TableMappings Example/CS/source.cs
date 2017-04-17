using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

public class Form1: Form
{
    protected OleDbDataAdapter myDataAdapter;

// <Snippet1>
 public void ShowTableMappings() {
    // ...
    // create myDataAdapter
    // ...
    myDataAdapter.TableMappings.Add("Categories","DataCategories");
    myDataAdapter.TableMappings.Add("Orders","DataOrders");
    myDataAdapter.TableMappings.Add("Products","DataProducts");
    string myMessage = "Table Mappings:\n";
    for(int i=0;i < myDataAdapter.TableMappings.Count;i++) {
       myMessage += i.ToString() + " "
          + myDataAdapter.TableMappings[i].ToString() + "\n";
    }
    MessageBox.Show(myMessage);
 }
// </Snippet1>

}
