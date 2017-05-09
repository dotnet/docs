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
 private void GetAndSetExtendedProperties(DataTable myTable){
    // Add an item to the collection.
    myTable.ExtendedProperties.Add("TimeStamp", DateTime.Now);
    // Print the item.
    Console.WriteLine(myTable.ExtendedProperties["TimeStamp"]);
 }
// </Snippet1>

}
