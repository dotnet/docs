   void dataGridView1_CellValidating( Object^ /*sender*/, DataGridViewCellValidatingEventArgs^ newValue )
   {
      DataGridViewColumn^ column = dataGridView1->Columns[ newValue->ColumnIndex ];
      if ( column->Name->Equals( "Track" ) )
      {
         CheckTrack( newValue );
      }
      else
      if ( column->Name->Equals( "Release Date" ) )
      {
         CheckDate( newValue );
      }
   }

   void CheckTrack( DataGridViewCellValidatingEventArgs^ newValue )
   {
      Int32 ignored;
      if ( newValue->FormattedValue->ToString() == String::Empty )
      {
         NotifyUserAndForceRedo( "Please enter a track", newValue );
      }
      else
      if (  !Int32::TryParse( newValue->FormattedValue->ToString(), ignored ) )
      {
         NotifyUserAndForceRedo( "A Track must be a number", newValue );
      }
      else
      if ( Int32::Parse( newValue->FormattedValue->ToString() ) < 1 )
      {
         NotifyUserAndForceRedo( "Not a valid track", newValue );
         editedLastColumn = true;
      }
   }

   void NotifyUserAndForceRedo( String^ errorMessage, DataGridViewCellValidatingEventArgs^ newValue )
   {
      MessageBox::Show( errorMessage );
      newValue->Cancel = true;
   }

   void CheckDate( DataGridViewCellValidatingEventArgs^ newValue )
   {
      try
      {
         DateTime::Parse( newValue->FormattedValue->ToString() ).ToLongDateString();
         AnnotateCell( String::Empty, newValue );
      }
      catch ( FormatException^ /*ex*/ ) 
      {
         AnnotateCell( "You did not enter a valid date.", newValue );
      }
   }

   void AnnotateCell( String^ errorMessage, DataGridViewCellValidatingEventArgs^ editEvent )
   {
      DataGridViewCell^ cell = dataGridView1->Rows[ editEvent->RowIndex ]->Cells[ editEvent->ColumnIndex ];
      cell->ErrorText = errorMessage;
   }