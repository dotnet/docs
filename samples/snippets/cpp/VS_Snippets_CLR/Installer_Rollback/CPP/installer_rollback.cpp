/*
System::Configuration::Install::Installer.Rollback

The following example demonstrates the Rollback method
of the class 'installer'. The Rollback method is overridden
in a derived class of 'installer'.An exception is generated to
force an installation rollback.
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
public:

   // Override 'Install' method of Installer class.
   virtual void Install( IDictionary^ mySavedState ) override
   {
      Installer::Install( mySavedState );
      Console::WriteLine( "" );
      
      // Include code to install an application.
      Console::WriteLine( "The Install method of 'MyInstallerSample'  has been called" );
      Console::WriteLine( "" );
      
      // Exception generated to call Rollback method.
      Exception^ myException = gcnew Exception;
      Console::WriteLine( "Exception thrown during Installation" );
      throw myException;
   }

// <Snippet1>
   // Override 'Rollback' method of Installer class.
public:
   virtual void Rollback( IDictionary^ mySavedState ) override
   {
      Installer::Rollback( mySavedState );
      Console::WriteLine( "The Rollback method of 'MyInstallerSample'" +
                         " has been called" );
   }
// </Snippet1>
};

void main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly  Installer_Rollback.exe" );
}
