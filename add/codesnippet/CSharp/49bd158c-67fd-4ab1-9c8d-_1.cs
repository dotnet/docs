private void CreateDataSet()
{
   myDataSet = new DataSet("myDataSet");
   /* Populates the DataSet with tables, relations, and 
      constraints. */
}

private void BindTextBoxToDataSet()
{
   /* Binds a TextBox control to a DataColumn named
   CompanyName in the DataTable named Suppliers. */
   textBox1.DataBindings.Add
   ("Text", myDataSet, "Suppliers.CompanyName");
}
   