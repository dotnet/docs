using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form{

public static void Main(){
   Form1 f = new Form1();
}

private DataGrid DataGrid1;
private DataSet DataSet1;

private void Setup(){
   DataGrid1 = new DataGrid();
   DataSet1 = new DataSet("myDataSet");
}

// <Snippet1>
private void PrintColumnInformation(DataGrid grid){
   Console.WriteLine("Count: " + grid.TableStyles.Count);
   GridColumnStylesCollection myColumns;   
   foreach(DataGridTableStyle myTableStyle in grid.TableStyles){

      myColumns = myTableStyle.GridColumnStyles;

      /* Iterate through the collection and print each 
      object's type and width. */
      foreach (DataGridColumnStyle dgCol in myColumns){
         Console.WriteLine(dgCol.MappingName);
         Console.WriteLine(dgCol.GetType().ToString());
         Console.WriteLine(dgCol.Width);
      }
   }
}
// </Snippet1>

}
