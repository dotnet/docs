   // Override the 'Install' method of the Installer class.
public:
   virtual void Install( IDictionary^ mySavedState ) override
   {
      Installer::Install( mySavedState );
      // Code maybe written for installation of an application.
      Console::WriteLine( "The Install method of 'MyInstallerSample' has been called" );
   }