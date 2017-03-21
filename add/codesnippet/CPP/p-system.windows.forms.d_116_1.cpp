   void dataGridView1_CellValueNeeded( Object^ /*sender*/,
       System::Windows::Forms::DataGridViewCellValueEventArgs^ e )
   {
      Customer^ customerTmp = nullptr;
      
      // Store a reference to the Customer object for the row being painted.
      if ( e->RowIndex == rowInEdit )
      {
         customerTmp = this->customerInEdit;
      }
      else
      {
         customerTmp = dynamic_cast<Customer^>(this->customers[ e->RowIndex ]);
      }
      
      // Set the cell value to paint using the Customer object retrieved.
      int switchcase = 0;
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Company Name" ) )
            switchcase = 1;
      else
      if ( (this->dataGridView1->Columns[ e->ColumnIndex ]->Name)->Equals( L"Contact Name" ) )
            switchcase = 2;


      switch ( switchcase )
      {
         case 1:
            e->Value = customerTmp->CompanyName;
            break;

         case 2:
            e->Value = customerTmp->ContactName;
            break;
      }
   }

