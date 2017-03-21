private void ShowGetItemProperties()
{
   // Create a new DataTable and add two columns.
   DataTable dt = new DataTable();
   dt.Columns.Add("Name", Type.GetType("System.String"));
   dt.Columns.Add("ID", Type.GetType("System.String"));
   // Add a row to the table.
   DataRow dr = dt.NewRow();
   dr["Name"] = "Ann";
   dr["ID"] = "AAA";
   dt.Rows.Add(dr);

   PropertyDescriptorCollection myPropertyDescriptors = 
   this.BindingContext[dt].GetItemProperties();
   PropertyDescriptor myPropertyDescriptor = 
   myPropertyDescriptors["Name"];
   Console.WriteLine(myPropertyDescriptor.Name);
   Console.WriteLine(myPropertyDescriptor.GetValue
   (dt.DefaultView[0]));
}
