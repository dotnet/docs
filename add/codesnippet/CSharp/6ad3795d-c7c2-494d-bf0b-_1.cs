      // Override 'Uninstall' method of Installer class.
      public override void Uninstall( IDictionary mySavedState )
      {  
         if (mySavedState == null)
         {
            Console.WriteLine("Uninstallation Error !");
         }
         else
         {
            base.Uninstall( mySavedState );
            Console.WriteLine( "The Uninstall method of 'MyInstallerSample' has been called" );
         }
      }