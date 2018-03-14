using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form {

    protected DataGrid dataGrid1;

// <Snippet1>
private void AddHandler()
{
   dataGrid1.TableStyles.CollectionChanged += 
   new CollectionChangeEventHandler(Collection_Changed);
}

private void Collection_Changed
(object sender, CollectionChangeEventArgs e)
{
   GridTableStylesCollection gts = (GridTableStylesCollection)
   sender;
   Console.WriteLine(gts.Count);
}
// </Snippet1>

}
