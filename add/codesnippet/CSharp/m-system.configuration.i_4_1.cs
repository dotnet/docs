      // Override the 'Commit' method of the Installer class.
      public override void Commit( IDictionary mySavedState )
      {
         base.Commit( mySavedState );
         Console.WriteLine( "The Commit method of 'MyInstallerSample'"
                           + "has been called" );
      }