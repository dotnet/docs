/*
System::Configuration::Install::Installer.Install
System::Configuration::Install::Installer.Commit

The following example demonstrates the 'Install' and 'Commit' methods
of the 'Installer' class.
A class is derived from the 'Installer' base class and the Install
and Commit methods are overridden.
*/

#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;
using namespace System::Collections;

[RunInstaller(true)]
ref class MyInstallerSample: public Installer
{
// <Snippet1>
   // Override the 'Install' method of the Installer class.
public:
   virtual void Install( IDictionary^ mySavedState ) override
   {
      Installer::Install( mySavedState );
      // Code maybe written for installation of an application.
      Console::WriteLine( "The Install method of 'MyInstallerSample' has been called" );
   }
// </Snippet1>

// <Snippet2>
   // Override the 'Commit' method of the Installer class.
   virtual void Commit( IDictionary^ mySavedState ) override
   {
      Installer::Commit( mySavedState );
      Console::WriteLine( "The Commit method of 'MyInstallerSample' "
         "has been called" );
   }
// </Snippet2>
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly"
      + " Installer_Install.exe" );
}
