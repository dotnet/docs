public:
   MyInstallerClass()
      : Installer()
   {
      // Attach the 'Committing' event.
      this->Committing += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_Committing );
   }

private:
   // Event handler for 'Committing' event.
   void MyInstaller_Committing( Object^ /*sender*/, InstallEventArgs^ /*e*/ )
   {
      Console::WriteLine( "Committing Event occured." );
   }