using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected DataSet DataSet1;
 protected BindingManagerBase myBindingManagerBase;
// <Snippet1>
private void GetBindingManagerBase()
{
   /* CustomersToOrders is the RelationName of a DataRelation. 
   Therefore, the list maintained by the BindingManagerBase is the
   list of orders that belong to a specific customer in the 
   DataTable named Customers, found in DataSet1. */
   myBindingManagerBase = 
   this.BindingContext[DataSet1, "Customers.CustomersToOrders"];

   // Adds delegates to the CurrentChanged and PositionChanged events.
   myBindingManagerBase.PositionChanged += 
   new EventHandler(BindingManagerBase_PositionChanged);
   myBindingManagerBase.CurrentChanged +=
   new EventHandler(BindingManagerBase_CurrentChanged);
}

private void BindingManagerBase_PositionChanged
(object sender, EventArgs e)
{
   // Prints the new Position of the BindingManagerBase.
   Console.Write("Position Changed: ");
   Console.WriteLine(((BindingManagerBase)sender).Position);
}

private void BindingManagerBase_CurrentChanged
(object sender, EventArgs e)
{
   // Prints the new value of the current object.
   Console.Write("Current Changed: ");
   Console.WriteLine(((BindingManagerBase)sender).Current);
}

private void MoveNext()
{
   // Increments the Position property value by one.
   myBindingManagerBase.Position += 1;
}

private void MovePrevious()
{
   // Decrements the Position property value by one.
   myBindingManagerBase.Position -= 1;
}

private void MoveFirst()
{
   // Goes to the first row in the list.
   myBindingManagerBase.Position = 0;
}

private void MoveLast()
{
   // Goes to the last row in the list.
   myBindingManagerBase.Position = 
   myBindingManagerBase.Count - 1;
}

// </Snippet1>
}
