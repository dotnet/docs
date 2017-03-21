   // Override 'Rollback' method of Installer class.
public:
   virtual void Rollback( IDictionary^ mySavedState ) override
   {
      Installer::Rollback( mySavedState );
      Console::WriteLine( "The Rollback method of 'MyInstallerSample'" +
                         " has been called" );
   }