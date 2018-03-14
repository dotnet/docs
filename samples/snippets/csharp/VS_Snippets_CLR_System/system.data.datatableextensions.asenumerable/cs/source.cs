//<snippet1>
using System;
using System.Data;

class Program {
   public void DisplayProducts(DataTable table) {
      var productNames = from products in table.AsEnumerable() select products.Field<string>("ProductName");
      Console.WriteLine("Product Names: ");
      foreach (string productName in productNames) {
         Console.WriteLine(productName);
      }
   }

   static void Main(string[] args) {
      DataTable table = new DataTable();
      table.Columns.Add("ID");
      table.Columns.Add("ProductName");

      table.Rows.Add("1", "Chai");
      table.Rows.Add("2", "Queso Cabrales");
      table.Rows.Add("3", "Tofu");

      Program inst = new Program();
      inst.DisplayProducts(table);
   }
}
//</snippet1>