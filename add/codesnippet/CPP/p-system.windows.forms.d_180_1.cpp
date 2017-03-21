   void PostRowCreation()
   {
      SetBandColor( dataGridView->Columns[ 0 ], Color::CadetBlue );
      SetBandColor( dataGridView->Rows[ 1 ], Color::Coral );
      SetBandColor( dataGridView->Columns[ 2 ], Color::DodgerBlue );
   }

   void SetBandColor( DataGridViewBand^ band, Color color )
   {
      band->Tag = color;
   }


   // Color the bands by the value stored in their tag.
   void Button9_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      IEnumerator^ myEnum1 = dataGridView->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewBand^ band = static_cast<DataGridViewBand^>(myEnum1->Current);
         if ( band->Tag != nullptr )
         {
            band->DefaultCellStyle->BackColor =  *dynamic_cast<Color^>(band->Tag);
         }
      }

      IEnumerator^ myEnum2 = safe_cast<IEnumerable^>(dataGridView->Rows)->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewBand^ band = safe_cast<DataGridViewBand^>(myEnum2->Current);
         if ( band->Tag != nullptr )
         {
            band->DefaultCellStyle->BackColor =  *dynamic_cast<Color^>(band->Tag);
         }
      }
   }

