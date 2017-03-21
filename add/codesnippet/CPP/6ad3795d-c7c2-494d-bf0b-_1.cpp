   // Override 'Uninstall' method of Installer class.
public:
   virtual void Uninstall( IDictionary^ mySavedState ) override
   {
      if ( mySavedState == nullptr )
      {
         Console::WriteLine( "Uninstallation Error !" );
      }
      else
      {
         Installer::Uninstall( mySavedState );
         Console::WriteLine( "The Uninstall method of 'MyInstallerSample' has been called" );
      }
   }