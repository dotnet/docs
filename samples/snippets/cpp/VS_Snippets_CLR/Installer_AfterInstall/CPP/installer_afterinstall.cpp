/*
   System::Configuration::Install::Installer.AfterInstall

   The following example demonstrates the event 'AfterInstall' of the
   'Installer' class. The event 'AfterInstall' is raised by the method
   'OnAfterInstall'.

   Use the installer process 'InstallUtil' to run the assembly
   'Installer_AfterInstall.exe'.

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
   // </Snippet1>

   // Override the 'Install' method.
public:
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

   // Override the 'OnBeforeInstall' method.
   virtual void OnBeforeInstall( IDictionary^ savedState ) override
   {
      Installer::OnBeforeInstall( savedState );
      Console::WriteLine( "" );
      Console::WriteLine( "OnBeforeInstall method of MyInstaller called" );
      Console::WriteLine( "" );
   }

protected:
   // Override the 'OnAfterInstall' method.
   virtual void OnAfterInstall( IDictionary^ savedState ) override
   {
      Installer::OnAfterInstall( savedState );
   }
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly Installer_AfterInstall.exe" );
}
