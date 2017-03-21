   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
      Console::WriteLine( "Commit ..." );
      
      // Throw an error if a particular file doesn't exist.
      if (  !File::Exists( "FileDoesNotExist.txt" ) )
            throw gcnew InstallException;

      
      // Perform the final installation if the file exists.
   }

