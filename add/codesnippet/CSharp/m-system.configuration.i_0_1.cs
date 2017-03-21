      // Override the 'Install' method of the Installer class.
      public override void Install( IDictionary mySavedState )
      {
         base.Install( mySavedState );
         // Code maybe written for installation of an application.
         Console.WriteLine( "The Install method of 'MyInstallerSample' has been called" );
      }