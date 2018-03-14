using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void BindControls(){
    // Creates a DataSet named SuppliersProducts.
    DataSet SuppliersProducts = new DataSet("SuppliersProducts");
    // Adds two DataTable objects, Suppliers and Products.
    SuppliersProducts.Tables.Add(new DataTable("Suppliers"));
    SuppliersProducts.Tables.Add(new DataTable("Products"));
    // Insert code to add DataColumn objects.
    // Insert code to fill tables with columns and data.
    // Binds the DataGrid to the DataSet, displaying the Suppliers table.
    dataGrid1.SetDataBinding(SuppliersProducts, "Suppliers");
 }
   
// </Snippet1>
}
