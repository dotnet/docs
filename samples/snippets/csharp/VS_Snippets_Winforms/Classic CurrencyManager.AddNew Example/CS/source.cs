using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected DataTable DataTable1;
// <Snippet1>
private void AddListItem()
{
   // Get the CurrencyManager for a DataTable.
   CurrencyManager myCurrencyManager = 
   (CurrencyManager)this.BindingContext[DataTable1];
   myCurrencyManager.AddNew();
}
      
// </Snippet1>
}
