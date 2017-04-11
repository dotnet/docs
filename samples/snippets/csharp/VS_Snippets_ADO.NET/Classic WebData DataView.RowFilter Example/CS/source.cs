// <Snippet1>
using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form {
   protected TextBox Text1;
   protected DataSet DataSet1;

   public static void Main() {
      DemostrateDataView();
   }

   private static void DemostrateDataView() {
      // Create a DataTable with one column
      DataTable dt = new DataTable("MyTable");
      DataColumn column = new DataColumn("Col", typeof(int));
      dt.Columns.Add(column); 

      // Add 5 rows on Added state
      for (int i = 0; i < 5; i++) {
         DataRow row = dt.NewRow();
         row["Col"] = i;
         dt.Rows.Add(row);
      }

      // Add 5 rows on Unchanged state
      for (int i = 5; i < 10; i++) {
         DataRow row = dt.NewRow();
         row["Col"] = i;
         dt.Rows.Add(row);
         // Calling AcceptChanges will make the DataRowVersion change from Added to Unchanged in this case
         row.AcceptChanges();
      }

      // Create a DataView
      DataView dv = new DataView(dt);

      Console.WriteLine("Print unsorted, unfiltered DataView");
      PrintDataView(dv);

      // Changing the Sort order to descending
      dv.Sort = "Col DESC";

      Console.WriteLine("Print sorted DataView. Sort = 'Col DESC'");
      PrintDataView(dv);

      // Filter by an expression. Filter all rows where column 'Col' have values greater or equal than 3
      dv.RowFilter = "Col < 3";

      Console.WriteLine("Print sorted and Filtered DataView by RowFilter. RowFilter = 'Col > 3'");
      PrintDataView(dv);

      // Removing Sort and RpwFilter to ilustrate RowStateFilter. DataView should contain all 10 rows back in the original order
      dv.Sort = String.Empty;
      dv.RowFilter = String.Empty;

      // Show only Unchanged rows or last 5 rows
      dv.RowStateFilter = DataViewRowState.Unchanged;

      Console.WriteLine("Print Filtered DataView by RowState. RowStateFilter =  DataViewRowState.Unchanged");
      PrintDataView(dv);
   }

   private static void PrintDataView(DataView dv) {
      // Printing first DataRowView to demo that the row in the first index of the DataView changes depending on sort and filters
      Console.WriteLine("First DataRowView value is '{0}'", dv[0]["Col"]);

      // Printing all DataRowViews
      foreach (DataRowView drv in dv) {
         Console.WriteLine("\t {0}", drv["Col"]);
      }
   }
}
// </Snippet1>