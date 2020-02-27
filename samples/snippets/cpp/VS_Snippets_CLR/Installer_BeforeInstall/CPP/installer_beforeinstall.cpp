/*
System::Configuration::Install::Installer.BeforeInstall

The following example demonstrates the event 'BeforeInstall' of the
'Installer' class. The event 'BeforeInstall' is raised by the method
'OnBeforeInstall'.

Use the installer process 'InstallUtil' to run the assembly
Installer_BeforeInstall.exe.

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
      BeforeInstall += gcnew InstallEventHandler( this, &MyInstaller::BeforeInstallEventHandler );
   }

   void BeforeInstallEventHandler( Object^ sender, InstallEventArgs^ e )
   {
      // Add steps to perform any actions before the install process.
      Console::WriteLine( "Code for BeforeInstallEventHandler" );
   }
   // </Snippet1>

public:
   // Override the 'Install' method.
   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "Install method of MyInstaller called" );
      Console::WriteLine( "" );
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
   }

protected:
   // Override the 'OnBeforeInstall' method.
   virtual void OnBeforeInstall( IDictionary^ savedState ) override
   {
      Installer::OnBeforeInstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "OnBeforeInstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }

   // Override the 'OnAfterInstall' method.
   virtual void OnAfterInstall( IDictionary^ savedState ) override
   {
      Installer::OnAfterInstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "OnAfterInstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly Installer_BeforeInstall.exe" );
}
