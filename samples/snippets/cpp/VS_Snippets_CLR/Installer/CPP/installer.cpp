

// System::Configuration::Install::Installer
/* The following program demonstrates the use of the 'Installer'
class. It creates a class which inherits from 'Installer'.
When the 'Commit' is about to complete, 'Committing' event
occurs and a message is displayed when the event occurs.
*/
// <Snippet1>
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;

// Set 'RunInstaller' attribute to true.

[RunInstaller(true)]
ref class MyInstallerClass: public Installer
{
private:

   // Event handler for 'Committing' event.
   void MyInstaller_Committing( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "" );
      Console::WriteLine( "Committing Event occured." );
      Console::WriteLine( "" );
   }


   // Event handler for 'Committed' event.
   void MyInstaller_Committed( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "" );
      Console::WriteLine( "Committed Event occured." );
      Console::WriteLine( "" );
   }


public:
   MyInstallerClass()
   {
      
      // Attach the 'Committed' event.
      this->Committed += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_Committed );
      
      // Attach the 'Committing' event.
      this->Committing += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_Committing );
   }


   // Override the 'Install' method.
   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
   }


   // Override the 'Commit' method.
   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
   }


   // Override the 'Rollback' method.
   virtual void Rollback( IDictionary^ savedState ) override
   {
      Installer::Rollback( savedState );
   }

};

int main()
{
   Console::WriteLine( "Usage : installutil.exe Installer.exe " );
}

// </Snippet1>
