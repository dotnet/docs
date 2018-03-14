/*
System::Configuration::Install::Installer.OnCommitting(Idictionary savedState)
System::Configuration::Install::Installer.OnCommitted(Idictionary savedState)

The following example demonstrates the methods 'OnCommitting' and
'OnCommitted' of the 'Installer' class. The methods 'OnCommitting' and
'OnCommitted' are overridden in the derived class. Space is provided
for the user to add the steps to be performed before committing and
after committing.

'Installer_Committed.exe' needs to be run using the installer process
'installutil'.
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

   // <Snippet1>
   // Override the 'OnCommitting' method.
protected:
   virtual void OnCommitting( IDictionary^ savedState ) override
   {
      Installer::OnCommitting( savedState );
      
      // Add steps to be done before committing an application.
      Console::WriteLine( "The OnCommitting method of MyInstaller called" );
   }
   // </Snippet1>

   // <Snippet2>
   // Override the 'OnCommitted' method.
protected:
   virtual void OnCommitted( IDictionary^ savedState ) override
   {
      Installer::OnCommitted( savedState );
      
      // Add steps to be done after committing an application.
      Console::WriteLine( "The OnCommitted method of MyInstaller called" );
   }
   // </Snippet2>
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly Installer_Committed.exe" );
}
