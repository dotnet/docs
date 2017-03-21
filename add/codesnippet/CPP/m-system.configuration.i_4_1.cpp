   // Override the 'Commit' method of the Installer class.
   virtual void Commit( IDictionary^ mySavedState ) override
   {
      Installer::Commit( mySavedState );
      Console::WriteLine( "The Commit method of 'MyInstallerSample' "
         "has been called" );
   }