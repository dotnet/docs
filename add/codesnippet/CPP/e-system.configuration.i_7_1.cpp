   // MyInstaller is derived from the class 'Installer'.
private:
   MyInstaller()
   {
      AfterUninstall += gcnew InstallEventHandler( this, &MyInstaller::AfterUninstallEventHandler );
   }

   void AfterUninstallEventHandler( Object^ sender, InstallEventArgs^ e )
   {
      // Add steps to perform any actions before the Uninstall process.
      Console::WriteLine( "Code for AfterUninstallEventHandler" );
   }