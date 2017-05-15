// System::Configuration::Install::Installer.Committing
/* The following program demonstrates the 'Committing' event of the
'Installer' class.  When the 'Commit' is ab->Item[Out] to* complete,
'Committing' event is fired and a message is displayed.
*/

#using <System.Configuration.Install.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;

// Set 'RunInstaller' attribute to true.
[RunInstaller(true)]
public ref class MyInstallerClass: public Installer
{
   // <Snippet1>
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
   // </Snippet1>

public:
   // Override the 'Install' method.
   virtual void Install( IDictionary^ savedState ) override
   {
      __super::Install( savedState );
   }

   // Override the 'Commit' method.
   virtual void Commit( IDictionary^ savedState ) override
   {
      __super::Commit( savedState );
   }

   // Override the 'Rollback' method.
   virtual void Rollback( IDictionary^ savedState ) override
   {
      __super::Rollback( savedState );
   }
};

int main()
{
   Console::WriteLine( "Usage : installutil.exe Installer_Committing.exe " );
}
