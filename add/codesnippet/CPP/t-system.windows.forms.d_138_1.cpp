   void dataGridView1_CellClick( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      if ( turn->Equals( gameOverString ) )
      {
         return;
      }

      DataGridViewImageCell^ cell = dynamic_cast<DataGridViewImageCell^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]);
      if ( cell->Value == blank )
      {
         if ( IsOsTurn() )
         {
            cell->Value = o;
         }
         else
         {
            cell->Value = x;
         }

         ToggleTurn();
      }

      if ( IsAWin( cell ) )
      {
         turn->Text = gameOverString;
      }
   }

