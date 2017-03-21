   // Override the 'OnCommitted' method.
protected:
   virtual void OnCommitted( IDictionary^ savedState ) override
   {
      Installer::OnCommitted( savedState );
      
      // Add steps to be done after committing an application.
      Console::WriteLine( "The OnCommitted method of MyInstaller called" );
   }