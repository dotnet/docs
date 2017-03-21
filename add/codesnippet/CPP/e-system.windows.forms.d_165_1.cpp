   void dataGridView1_CancelRowEdit( Object^ /*sender*/,
       System::Windows::Forms::QuestionEventArgs^ /*e*/ )
   {
      if ( this->rowInEdit == this->dataGridView1->Rows->Count - 2 &&
           this->rowInEdit == this->customers->Count )
      {
         
         // If the user has canceled the edit of a newly created row, 
         // replace the corresponding Customer object with a new, empty one.
         this->customerInEdit = gcnew Customer;
      }
      else
      {
         
         // If the user has canceled the edit of an existing row, 
         // release the corresponding Customer object.
         this->customerInEdit = nullptr;
         this->rowInEdit = -1;
      }
   }

