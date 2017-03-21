   void PrintColumnInformation( DataGrid^ grid )
   {
      Console::WriteLine( "Count: {0}", grid->TableStyles->Count );
      GridColumnStylesCollection^ myColumns;
      DataGridTableStyle^ myTableStyle;
      for ( __int32 i = 0; i < grid->TableStyles->Count; i++ )
      {
         myTableStyle = grid->TableStyles[ i ];
         myColumns = myTableStyle->GridColumnStyles;
         
         /* Iterate through the collection and print each 
                  object's type and width. */
         DataGridColumnStyle^ dgCol;
         for ( __int32 j = 0; j < myColumns->Count; j++ )
         {
            dgCol = myColumns[ j ];
            Console::WriteLine( dgCol->MappingName );
            Console::WriteLine( dgCol->GetType()->ToString() );
            Console::WriteLine( dgCol->Width );

         }

      }
   }
