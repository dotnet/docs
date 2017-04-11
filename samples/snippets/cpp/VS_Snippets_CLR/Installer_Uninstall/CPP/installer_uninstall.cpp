/*
System::Configuration::Install::Installer.Uninstall

The following example demonstrates the Uninstall method
of the class 'installer'. The method Uninstall is overridden
in the derived class of 'installer'.
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
   // Override 'Uninstall' method of Installer class.
public:
   virtual void Uninstall( IDictionary^ mySavedState ) override
   {
      if ( mySavedState == nullptr )
      {
         Console::WriteLine( "Uninstallation Error !" );
      }
      else
      {
         Installer::Uninstall( mySavedState );
         Console::WriteLine( "The Uninstall method of 'MyInstallerSample' has been called" );
      }
   }
// </Snippet1>
};

void main()
{
   Console::WriteLine( "Use 'installutil.exe -u' to run the assembly  Installer_Uninstall.exe" );
}
