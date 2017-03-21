 private Hashtable myHashTable = new Hashtable();
 
 private void Grid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
 {
    DataGrid dg = (DataGrid)sender;
    DataGridCell myCell = dg.CurrentCell;
    string tempkey = myCell.ToString();
    Console.WriteLine("Temp " + tempkey);
    if(myHashTable.Contains(tempkey)){return;}
    myHashTable.Add(tempkey, myCell.GetHashCode());
    Console.WriteLine("Hashcode: " + myCell.GetHashCode().ToString());
 }
       