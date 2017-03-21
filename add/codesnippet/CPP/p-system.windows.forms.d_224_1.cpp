private:
   void GetSelectedIndex( DataGridTableStyle^ myGridTable )
   {
      /* Get the name of the DataGrid of the DataGridTable 
         passed as an argument. */
      Console::WriteLine( myGridTable->DataGrid->CurrentCell.ToString() );
   }