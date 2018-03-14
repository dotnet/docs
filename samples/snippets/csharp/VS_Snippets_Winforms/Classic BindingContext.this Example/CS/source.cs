using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;


public class Form1: Form
{
 protected TextBox textBox1;
 protected DataView myDataView;
 protected ArrayList myArrayList;
// <Snippet1>
private void ReturnBindingManagerBase()
{
   // Get the BindingManagerBase for a DataView. 
   BindingManagerBase bmCustomers = 
   this.BindingContext [myDataView];

   /* Get the BindingManagerBase for an ArrayList. */ 
   BindingManagerBase bmOrders = 
   this.BindingContext[myArrayList];

   // Get the BindingManagerBase for a TextBox control.
   BindingManagerBase baseArray = 
   this.BindingContext[textBox1.DataBindings[0].DataSource];
}

// </Snippet1>
}
