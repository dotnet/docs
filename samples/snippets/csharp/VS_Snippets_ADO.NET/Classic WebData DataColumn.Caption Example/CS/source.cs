using System;
using System.Data;

public class Sample
{
  protected DataSet DataSet1;


// <Snippet1>
private void CreateDataTable()
{
   DataTable table;
   DataColumn column;

   table = new DataTable("Customers");

   //CustomerID column
   column = table.Columns.Add("CustomerID", 
       System.Type.GetType("System.Int32"));
   column.Unique = true;
	
   //CustomerName column
   column = table.Columns.Add("CustomerName", 
       System.Type.GetType("System.String"));
   column.Caption = "Name";

   //CreditLimit
   column = table.Columns.Add("CreditLimit", 
       System.Type.GetType("System.Double"));
   column.DefaultValue = 0;
   column.Caption = "Limit";

   table.Rows.Add(new object[] {1, "Jonathan", 23.44});
   table.Rows.Add(new object[] {2, "Bill", 56.87});
}
// </Snippet1>

}
