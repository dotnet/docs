/*
System::Configuration::Install::Installer.HelpText

The following example demonstrates the property 'HelpText'. The
'HelpText' property is defined in the 'Installer', which when called
returns the description of the 'Installer' and the command line
options for the installation executable, such as the InstallUtil.exe utility,
that can be passed to and understood by the 'Installer'.

Use 'installutil' to run the assembly Installer_HelpText.exe.
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
      String^ myHelpText = HelpText;
      Console::WriteLine( "Help Text : " );
      Console::WriteLine( myHelpText );
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
      // Override the property 'HelpText'.
   property String^ HelpText 
   {
      virtual String^ get() override
      {
         return "Installer Description : This is a sample Installer\n"
              + "HelpText is used to provide useful information about the "
              + "installer.";
      }
   }
// </Snippet1>
};

int main()
{
   Console::WriteLine( "Use installutil.exe to run the assembly Installer_HelpText.exe" );
}
