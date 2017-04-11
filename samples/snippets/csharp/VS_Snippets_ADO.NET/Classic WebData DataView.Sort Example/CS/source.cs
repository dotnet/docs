// <Snippet1>
using System.Data;
using System;
public class A {
   static void Main(string[] args) {
      DataTable locationTable = new DataTable("Location");
      // Add two columns
      locationTable.Columns.Add("State");
      locationTable.Columns.Add("ZipCode");

      // Add data 
      locationTable.Rows.Add("Washington", "98052");
      locationTable.Rows.Add("California", "90001");
      locationTable.Rows.Add("Hawaii", "96807");
      locationTable.Rows.Add("Hawaii", "96801");
      locationTable.AcceptChanges();

      Console.WriteLine("Rows in original order\n State \t\t ZipCode");
      foreach (DataRow row in locationTable.Rows) {
         Console.WriteLine(" {0} \t {1}", row["State"], row["ZipCode"]);
      }

      // Create DataView
      DataView view = new DataView(locationTable);

      // Sort by State and ZipCode column in descending order
      view.Sort = "State ASC, ZipCode ASC";

      Console.WriteLine("\nRows in sorted order\n State \t\t ZipCode");
      foreach (DataRowView row in view) {
         Console.WriteLine(" {0} \t {1}", row["State"], row["ZipCode"]);
      }
   }
}
// </Snippet1>