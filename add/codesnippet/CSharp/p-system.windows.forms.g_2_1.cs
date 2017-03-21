   private void GetGridTableByName()
   {
      DataGridTableStyle myGridStyle = 
      myDataGrid.TableStyles["customers"] ;
      Console.WriteLine(myGridStyle.MappingName);
   }