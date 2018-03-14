using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected DataSet ds;
// <Snippet1>
protected void BindControl()
{
   /* Create a Binding object for the TextBox control. 
   The data-bound property for the control is the Text 
   property. */
   Binding myBinding = 
   new Binding("Text", ds, "customers.custName");

   text1.DataBindings.Add(myBinding);

   // Get the BindingManagerBase for the Customers table. 
   BindingManagerBase bmCustomers = 
   this.BindingContext [ds, "Customers"];

   // Add the delegate for the PositionChanged event.
   bmCustomers.PositionChanged += 
   new EventHandler(Position_Changed);
}

private void Position_Changed(object sender, EventArgs e)
{
   // Print the Position property value when it changes.
   Console.WriteLine(((BindingManagerBase)sender).Position);
}

// </Snippet1>
}
