   // Override the 'OnAfterInstall' method.
protected:
   virtual void OnAfterInstall( IDictionary^ savedState ) override
   {
      Installer::OnAfterInstall( savedState );
      // Add steps to be done after the installation is over.
      Console::WriteLine( "OnAfterInstall method of MyInstaller called" );
   }