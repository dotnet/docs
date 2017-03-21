   // MyInstaller is derived from the class 'Installer'.
private:
   MyInstaller()
   {
      BeforeUninstall += gcnew InstallEventHandler( this, &MyInstaller::BeforeUninstallEventHandler );
   }

   void BeforeUninstallEventHandler( Object^ sender, InstallEventArgs^ e )
   {
      // Add steps to perform any actions before the Uninstall process.
      Console::WriteLine( "Code for BeforeUninstallEventHandler" );
   }