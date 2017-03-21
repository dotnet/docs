   void Stretch( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum = dataGridView1->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Stretch;
         column->Description = L"Stretched";
      }
   }

   void ZoomToImage( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum1 = dataGridView1->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum1->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Zoom;
         column->Description = L"Zoomed";
      }
   }

   void NormalImage( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum2 = dataGridView1->Columns->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum2->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Normal;
         column->Description = L"Normal";
      }
   }

