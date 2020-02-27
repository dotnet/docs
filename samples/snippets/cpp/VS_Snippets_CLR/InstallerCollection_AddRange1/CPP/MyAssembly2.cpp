

/*
This program is supposed to be used with the IntallerCollection_***.cs
examples. Provide the exe of this program as input to the
InstallerCollection_***.exe programs.
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
   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
      Console::WriteLine( "Install ...\n" );
   }

   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
      Console::WriteLine( "Committing ...\n" );
   }

   virtual void Rollback( IDictionary^ savedState ) override
   {
      Installer::Rollback( savedState );
      Console::WriteLine( "RollBack ...\n" );
   }

   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Installer::Uninstall( savedState );
      Console::WriteLine( "UnInstall ...\n" );
   }
};

// An Assembly that has its own installer.
void main()
{
   Console::WriteLine( "This assembly is just an example for the Installer\n" );
}
