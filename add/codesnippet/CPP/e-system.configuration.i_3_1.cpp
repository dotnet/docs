public:
   MyInstallerClass()
   {
      // Attach the 'Committed' event.
      this->Committed += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_Committed );
   }

private:
   // Event handler for 'Committed' event.
   void MyInstaller_Committed( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "Committed Event occured." );
   }