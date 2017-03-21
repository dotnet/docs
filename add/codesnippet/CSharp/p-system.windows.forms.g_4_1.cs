   private void GetGridTableByIndex()
   {
      DataGridTableStyle myGridStyle = 
      myDataGrid.TableStyles[0] ;
      Console.WriteLine(myGridStyle.MappingName);
   }