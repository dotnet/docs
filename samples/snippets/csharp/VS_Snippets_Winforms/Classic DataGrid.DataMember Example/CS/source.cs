using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
protected object source;

private void SetSourceAndMember(){

   DataSet myDataSet = new DataSet("myDataSet");
   DataTable tableCustomers = new DataTable("Customers");
   myDataSet.Tables.Add(tableCustomers);
   // Insert code to populate the DataSet.

   // Set DataSource and DataMember with SetDataBinding method.
   string member;
   // The name of a DataTable is Customers.
   member = "Customers";
   dataGrid1.SetDataBinding(myDataSet, member);
}

// </Snippet1>
}
