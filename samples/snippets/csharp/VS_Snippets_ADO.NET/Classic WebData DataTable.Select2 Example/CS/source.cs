// <Snippet1>
using System;
using System.Data;

public class A {  

   public static void Main() {      
      DataTable table = new DataTable("Orders");
      table.Columns.Add("OrderID", typeof(Int32));
      table.Columns.Add("OrderQuantity", typeof(Int32));
      table.Columns.Add("CompanyName", typeof(string));      
      table.Columns.Add("Date", typeof(DateTime));

      DataRow newRow = table.NewRow();
      newRow["OrderID"] = 1;
      newRow["OrderQuantity"] = 3;
      newRow["CompanyName"] = "NewCompanyName";
      newRow["Date"] = "1979, 1, 31";

      // Add the row to the rows collection.
      table.Rows.Add(newRow);
      
      DataRow newRow2 = table.NewRow();
      newRow2["OrderID"] = 2;
      newRow2["OrderQuantity"] = 2;
      newRow2["CompanyName"] = "NewCompanyName1";
      table.Rows.Add(newRow2);

      DataRow newRow3 = table.NewRow();
      newRow3["OrderID"] = 3;
      newRow3["OrderQuantity"] = 2;
      newRow3["CompanyName"] = "NewCompanyName2";
      table.Rows.Add(newRow3);

      // Presuming the DataTable has a column named Date.
      string expression = "Date = '1/31/1979' or OrderID = 2";
      // string expression = "OrderQuantity = 2 and OrderID = 2";

      // Sort descending by column named CompanyName.
      string sortOrder = "CompanyName ASC";
      DataRow[] foundRows;

      // Use the Select method to find all rows matching the filter.
      foundRows = table.Select(expression, sortOrder);

      // Print column 0 of each returned row.
      for (int i = 0; i < foundRows.Length; i++)
         Console.WriteLine(foundRows[i][2]);
   }
}
// </Snippet1>