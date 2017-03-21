   // Override the 'OnBeforeInstall' method.
protected:
   virtual void OnBeforeInstall( IDictionary^ savedState ) override
   {
      Installer::OnBeforeInstall( savedState );
      
      // Add steps to be done before the installation starts.
      Console::WriteLine( "OnBeforeInstall method of MyInstaller called" );
   }