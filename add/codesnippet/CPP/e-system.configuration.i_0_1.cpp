   // MyInstaller is derived from the class 'Installer'.
private:
   MyInstaller()
   {
      BeforeInstall += gcnew InstallEventHandler( this, &MyInstaller::BeforeInstallEventHandler );
   }

   void BeforeInstallEventHandler( Object^ sender, InstallEventArgs^ e )
   {
      // Add steps to perform any actions before the install process.
      Console::WriteLine( "Code for BeforeInstallEventHandler" );
   }