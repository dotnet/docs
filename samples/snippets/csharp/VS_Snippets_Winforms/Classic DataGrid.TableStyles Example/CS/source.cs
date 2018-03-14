using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{ 
 static void Main(){}
// <Snippet1>
   private void AddTables(DataGrid myDataGrid, DataSet myDataSet){
      foreach(DataTable t in myDataSet.Tables){
         DataGridTableStyle myGridTableStyle = new 
         DataGridTableStyle();
         myGridTableStyle.MappingName = t.TableName;
         myDataGrid.TableStyles.Add(myGridTableStyle);

         /* Note that DataGridColumnStyle objects will
         be created automatically for the first DataGridTableStyle
         when you add it to the GridTableStylesCollection.*/
      }
   }
   private void PrintGridStyleInfo(DataGrid myDataGrid){
      /* Print the MappingName of each DataGridTableStyle,
      and the MappingName of each DataGridColumnStyle. */
      foreach(DataGridTableStyle myGridStyle in 
      myDataGrid.TableStyles){
      Console.WriteLine(myGridStyle.MappingName);
      foreach(DataGridColumnStyle myColumnStyle in 
         myGridStyle.GridColumnStyles){
   	 Console.WriteLine(myColumnStyle.MappingName);
         }
      }
   }
    
// </Snippet1>
}
