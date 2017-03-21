      try
      {
         
         // Assign the selected file's path to 
         // the SoundPlayer object.  
         player->SoundLocation = this->filepathTextbox->Text;
         
         // Load the .wav file.
         player->LoadAsync();
      }
      catch ( Exception^ ex ) 
      {
         ReportStatus( ex->Message );
      }

      