   private:
      void SetCursor()
      {
         // Display an OpenFileDialog so the user can select a cursor.
         OpenFileDialog^ openFileDialog1 = gcnew OpenFileDialog;
         openFileDialog1->Filter = "Cursor Files|*.cur";
         openFileDialog1->Title = "Select a Cursor File";
         openFileDialog1->ShowDialog();

         // If a .cur file was selected, open it.
         if (  !openFileDialog1->FileName->Equals( "" ) )
         {
            // Assign the cursor in the stream to the form's Cursor property.
            this->Cursor = gcnew System::Windows::Forms::Cursor( openFileDialog1->OpenFile() );
         }
      }