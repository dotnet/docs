/*
System::Configuration::Install::Installer.OnBeforeInstall(IDictionary* savedState)
System::Configuration::Install::Installer.OnAfterInstall(IDictionary* savedState)

The following example demonstrates the methods 'OnBeforeInstall' and
'OnAfterInstall' of the 'Installer' class. The methods 'OnBeforeInstall'
and 'OnAfterInstall' are overridden in the derived class. Space is provided
to add steps to be done before the installation in 'OnBeforeInstall' method
and after the installation in 'OnAfterInstall' method.

Use the installer process 'InstallUtil' to run the assembly
Installer_OnInstall.exe.

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
   }

// <Snippet1>
   // Override the 'OnBeforeInstall' method.
protected:
   virtual void OnBeforeInstall( IDictionary^ savedState ) override
   {
      Installer::OnBeforeInstall( savedState );
      
      // Add steps to be done before the installation starts.
      Console::WriteLine( "OnBeforeInstall method of MyInstaller called" );
   }
// </Snippet1>

// <Snippet2>
   // Override the 'OnAfterInstall' method.
protected:
   virtual void OnAfterInstall( IDictionary^ savedState ) override
   {
      Installer::OnAfterInstall( savedState );
      // Add steps to be done after the installation is over.
      Console::WriteLine( "OnAfterInstall method of MyInstaller called" );
   }
// </Snippet2>
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly Installer_OnInstall.exe" );
}
