   void dataGridView1_CellMouseEnter( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      Bitmap^ markingUnderMouse = dynamic_cast<Bitmap^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]->Value);
      if ( markingUnderMouse == blank )
      {
         dataGridView1->Cursor = Cursors::Default;
      }
      else
      if ( markingUnderMouse == o || markingUnderMouse == x )
      {
         dataGridView1->Cursor = Cursors::No;
         ToolTip(e,true);
      }
   }

   void ToolTip( DataGridViewCellEventArgs^ e, bool showTip )
   {
      DataGridViewImageCell^ cell = dynamic_cast<DataGridViewImageCell^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]);
      DataGridViewImageColumn^ imageColumn = dynamic_cast<DataGridViewImageColumn^>(dataGridView1->Columns[ cell->ColumnIndex ]);
      if ( showTip )
            cell->ToolTipText = imageColumn->Description;
      else
      {
         cell->ToolTipText = String::Empty;
      }
   }

   void dataGridView1_CellMouseLeave( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      ToolTip( e, false );
      dataGridView1->Cursor = Cursors::Default;
   }

