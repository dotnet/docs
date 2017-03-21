private void PrintBoundControls1()
{
   // Get the BindingManagerBase for the Customers table.
   BindingManagerBase myBindingBase = 
      this.BindingContext[ds, "Customers"];

   /* Print the information of each control managed by
      the BindingManagerBase. */
   foreach(Binding b in myBindingBase.Bindings)
   {
      Console.WriteLine(b.Control.ToString());
   }
}

private void PrintBoundControls2()
{
   /* Get the BindingManagerBase for a child table of
   the Customers table. The RelationName of a DataRelation
   is appended to the parent table's name. */
   BindingManagerBase myBindingBase = 
      this.BindingContext[ds, "Customers.CustToOrders"];

   /* Print the information of each control managed by
      the BindingManagerBase. */
   foreach(Binding b in myBindingBase.Bindings)
   {
      Console.WriteLine(b.Control.ToString());
   }
}