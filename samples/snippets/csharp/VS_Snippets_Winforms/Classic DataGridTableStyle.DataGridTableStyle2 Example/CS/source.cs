using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
public class Form1: Form
{
protected DataGrid myDataGrid;
protected DataSet myDataSet;

// <Snippet1>
private void CreateDataGridGridTableStyle(){
   CurrencyManager myCurrencyManager;
   DataGridTableStyle myGridTableStyle;
   /* Get the CurrencyManager for a DataTable named "Customers"
   found in a DataSet named "myDataSet". */
   myCurrencyManager = 
   (CurrencyManager) BindingContext[myDataSet, "Customers"];
   myGridTableStyle = new DataGridTableStyle(myCurrencyManager);
   // Add the table style to the collection of a DataGrid.
   myDataGrid.TableStyles.Add(myGridTableStyle);
}
 
// </Snippet1>
}

