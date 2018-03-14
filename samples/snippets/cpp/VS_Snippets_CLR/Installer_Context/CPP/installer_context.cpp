/*
System::Configuration::Install::Installer.Context

The following example demonstrates the 'Context' property of
the 'Installer' class. The contents of the 'Context' property
like information about the location of the log file for the
installation, the location of the file to save information
required by the Uninstall method, and the command line that
was entered when the installation executable was run is
displayed on the console.

Use 'installutil' to run the assembly Installer_Context.exe
*/

#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;
using namespace System::Collections::Specialized;

[RunInstaller(true)]
ref class MyInstaller: public Installer
{
public:

   // Override the 'Install' method.
   virtual void Install( IDictionary^ mySavedState ) override
   {
      Installer::Install( mySavedState );
      Console::WriteLine( "" );
      
      // <Snippet1>
      StringDictionary^ myStringDictionary = Context->Parameters;
      if ( Context->Parameters->Count > 0 )
      {
         Console::WriteLine( "Context Property : " );
         IEnumerator^ myEnum = Context->Parameters->Keys->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ myString = safe_cast<String^>(myEnum->Current);
            Console::WriteLine( Context->Parameters[ myString ] );
         }
      }
      // </Snippet1>
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
};

void main()
{
   Console::WriteLine( "Run the assembly Installer_Context.exe using the  installer process 'installutil'" );
}
