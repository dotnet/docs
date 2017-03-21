   // MyInstaller is derived from the class 'Installer'.
public:
   MyInstaller()
   {
      AfterInstall += gcnew InstallEventHandler( this, &MyInstaller::AfterInstallEventHandler );
   }

private:
   void AfterInstallEventHandler( Object^ sender, InstallEventArgs^ e )
   {
      // Add steps to perform any actions after the install process.
      Console::WriteLine( "Code for AfterInstallEventHandler" );
   }