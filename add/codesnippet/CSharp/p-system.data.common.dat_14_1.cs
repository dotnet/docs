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