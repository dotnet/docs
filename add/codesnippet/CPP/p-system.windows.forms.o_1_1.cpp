   private:
      FileStream^ OpenFile()
      {
         // Displays an OpenFileDialog and shows the read/only files.
         OpenFileDialog^ dlgOpenFile = gcnew OpenFileDialog;
         dlgOpenFile->ShowReadOnly = true;
         if ( dlgOpenFile->ShowDialog() == ::DialogResult::OK )
         {
            // If ReadOnlyChecked is true, uses the OpenFile method to
            // open the file with read/only access.
            if ( dlgOpenFile->ReadOnlyChecked == true )
            {
               return dynamic_cast<FileStream^>(dlgOpenFile->OpenFile());
            }
            // Otherwise, opens the file with read/write access.
            else
            {
               String^ path = dlgOpenFile->FileName;
               return gcnew FileStream( path,System::IO::FileMode::Open,System::IO::FileAccess::ReadWrite );
            }
         }

         return nullptr;
      }