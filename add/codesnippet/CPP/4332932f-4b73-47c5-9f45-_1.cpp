   // Override the 'OnCommitting' method.
protected:
   virtual void OnCommitting( IDictionary^ savedState ) override
   {
      Installer::OnCommitting( savedState );
      
      // Add steps to be done before committing an application.
      Console::WriteLine( "The OnCommitting method of MyInstaller called" );
   }