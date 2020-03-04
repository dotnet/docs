/*
System::Configuration::Install::Installer.BeforeUninstall

The following example demonstrates the event 'BeforeUninstall' of the
'Installer' class. This event is raised by the method 'OnBeforeUninstall'.

Use the installer process 'InstallUtil -u' to run the assembly
'Installer_BeforeUninstall.exe'.

*/

#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;

[RunInstaller(true)]
ref class MyInstaller: public Installer
{
   // <Snippet1>
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

   // Override the 'Uninstall' method.
   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Installer::Uninstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "Uninstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }

protected:
   // Override the 'OnBeforeUninstall' method.
   virtual void OnBeforeUninstall( IDictionary^ savedState ) override
   {
      Installer::OnBeforeUninstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "OnBeforeUninstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }

   // Override the 'OnAfterUninstall' method.
   virtual void OnAfterUninstall( IDictionary^ savedState ) override
   {
      Installer::OnAfterUninstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "OnAfterUninstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }
};

void main()
{
   Console::WriteLine( "Use 'installutil.exe -u' to run the assembly Installer_BeforeUninstall.exe" );
}
