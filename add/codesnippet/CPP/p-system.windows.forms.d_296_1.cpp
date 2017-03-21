private:
   void WriteMappingNames()
   {
      for each ( DataGridTableStyle^ dgt in myDataGrid->TableStyles )
      {
         Console::WriteLine( dgt->MappingName );
         for each ( DataGridColumnStyle^ dgc in dgt->GridColumnStyles )
         {
            Console::WriteLine( dgc->MappingName );
         }
      }
   }