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