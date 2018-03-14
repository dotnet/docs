// <Snippet1>
using System;
using System.Data;

class MyDataSet {
   public static void Main() {
      DataTable dt = new DataTable();

      DataColumn dc1 = new DataColumn("col1");
      DataColumn dc2 = new DataColumn("col2");
      DataColumn dc3 = new DataColumn("col3");

      dt.Columns.Add(dc1);
      dt.Columns.Add(dc2);
      dt.Columns.Add(dc3);

      // Create an array for the values.
      object[] newRow = new object[3];

      // Set the values of the array.
      newRow[0] = "Hello";
      newRow[1] = "World";
      newRow[2] = "two";
      DataRow row;

      dt.BeginLoadData();

      // Add the new row to the rows collection.
      row = dt.LoadDataRow(newRow, true);

      foreach (DataRow dr in dt.Rows) {
         Console.WriteLine(String.Format("Row: {0}, {1}, {2}", dr["col1"], dr["col2"], dr["col3"]));
      }

      dt.EndLoadData();
   }
}
// </Snippet1>