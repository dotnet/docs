   void dataGridView1_RowDirtyStateNeeded( Object^ /*sender*/,
       System::Windows::Forms::QuestionEventArgs^ e )
   {
      if (  !rowScopeCommit )
      {
         
         // In cell-level commit scope, indicate whether the value
         // of the current cell has been modified.
         e->Response = this->dataGridView1->IsCurrentCellDirty;
      }
   }

