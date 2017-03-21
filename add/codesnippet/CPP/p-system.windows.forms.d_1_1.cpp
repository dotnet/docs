   // Handling CellParsing allows one to accept user input, then map it to a different
   // internal representation.
   void dataGridView1_CellParsing( Object^ /*sender*/, DataGridViewCellParsingEventArgs^ e )
   {
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Release Date" ) )
      {
         if ( e != nullptr )
         {
            if ( e->Value != nullptr )
            {
               try
               {
                  // Map what the user typed into UTC.
                  e->Value = DateTime::Parse( e->Value->ToString() ).ToUniversalTime();

                  // Set the ParsingApplied property to 
                  // Show the event is handled.
                  e->ParsingApplied = true;
               }
               catch ( FormatException^ /*ex*/ ) 
               {
                  // Set to false in case another CellParsing handler
                  // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                  e->ParsingApplied = false;
               }
            }
         }
      }
   }