// System::Configuration::Install::Installer.Committed
/* The following program demonstrates the 'Committed' event of the
'Installer' class.  When the 'Commit' is complete, 'Committed' event
is fired and a message is displayed.
*/

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
   // <Snippet1>
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
   // </Snippet1>

public:
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

void main()
{
   Console::WriteLine( "Usage : installutil.exe Installer_Committed.exe " );
}
