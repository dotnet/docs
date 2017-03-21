private void PrintValue()
{
   ControlBindingsCollection myControlBindings;
   myControlBindings = textBox1.DataBindings;

   // Get the Binding for the Text property.
   Binding myBinding = myControlBindings["Text"];

   // Assuming the data source is a DataTable.
   DataRowView drv;
   drv = (DataRowView) myBinding.BindingManagerBase.Current;

   // Assuming a column named "custName" exists, print the value.
   Console.WriteLine(drv["custName"]);
}