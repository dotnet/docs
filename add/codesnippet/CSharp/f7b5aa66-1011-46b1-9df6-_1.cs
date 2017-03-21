      // Override 'Rollback' method of Installer class.
      public override void Rollback( IDictionary mySavedState )
      {
         base.Rollback( mySavedState );
         Console.WriteLine( "The Rollback method of 'MyInstallerSample'" +
                           " has been called" );
      }