private:
   void EditTable()
   {
      DataGridTableStyle^ dgt = myDataGrid->TableStyles[ 0 ];
      DataGridColumnStyle^ myCol = dgt->GridColumnStyles[ 0 ];
      dgt->BeginEdit( myCol, 1 );
      dgt->EndEdit( myCol, 1, true );
   }
