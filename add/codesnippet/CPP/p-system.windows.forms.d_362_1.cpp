   void dataGridView1_CellFormatting( Object^ /*sender*/, DataGridViewCellFormattingEventArgs^ e )
   {
      // If the column is the Artist column, check the
      // value.
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Artist" ) )
      {
         if ( e->Value != nullptr )
         {
            // Check for the string "pink" in the cell.
            String^ stringValue = dynamic_cast<String^>(e->Value);
            stringValue = stringValue->ToLower();
            if ( (stringValue->IndexOf( "pink" ) > -1) )
            {
               DataGridViewCellStyle^ pinkStyle = gcnew DataGridViewCellStyle;

               //Change the style of the cell.
               pinkStyle->BackColor = Color::Pink;
               pinkStyle->ForeColor = Color::Black;
               pinkStyle->Font = gcnew System::Drawing::Font( "Times New Roman",8,FontStyle::Bold );
               e->CellStyle = pinkStyle;
            }
            
         }
      }
      else
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Release Date" ) )
      {
         ShortFormDateFormat( e );
      }
   }


   //Even though the date internaly stores the year as YYYY, using formatting, the
   //UI can have the format in YY.  
   void ShortFormDateFormat( DataGridViewCellFormattingEventArgs^ formatting )
   {
      if ( formatting->Value != nullptr )
      {
         try
         {
            System::Text::StringBuilder^ dateString = gcnew System::Text::StringBuilder;
            DateTime theDate = DateTime::Parse( formatting->Value->ToString() );
            dateString->Append( theDate.Month );
            dateString->Append( "/" );
            dateString->Append( theDate.Day );
            dateString->Append( "/" );
            dateString->Append( theDate.Year.ToString()->Substring( 2 ) );
            formatting->Value = dateString->ToString();
            formatting->FormattingApplied = true;
         }
         catch ( Exception^ /*notInDateFormat*/ ) 
         {
            // Set to false in case there are other handlers interested trying to
            // format this DataGridViewCellFormattingEventArgs instance.
            formatting->FormattingApplied = false;
         }

      }
   }