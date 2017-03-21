#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;
using namespace System::Collections;
using namespace System::Collections::Specialized;

[RunInstallerAttribute(true)]
ref class InstallContext_Example: public Installer
{
public:
   InstallContext^ myInstallContext;
   virtual void Install( IDictionary^ mySavedState ) override
   {
      StringDictionary^ myStringDictionary = myInstallContext->Parameters;
      if ( myStringDictionary->Count == 0 )
      {
         Console::Write( "No parameters have been entered in the command line " );
         Console::WriteLine( "hence, the install will take place in the silent mode" );
      }
      else
      {
         // Check whether the "LogtoConsole" parameter has been set.
         if ( myInstallContext->IsParameterTrue( "LogtoConsole" ) )
         {
            // Display the message to the console and add it to the logfile.
            myInstallContext->LogMessage( "The 'Install' method has been called" );
         }
      }
      // The 'Install procedure should be added here.
   }

   virtual void Uninstall( IDictionary^ mySavedState ) override
   {
      // The 'Uninstall' procedure should be added here.
   }

   virtual void Rollback( IDictionary^ mySavedState ) override
   {
      if ( myInstallContext->IsParameterTrue( "LogtoConsole" ) )
      {
         myInstallContext->LogMessage( "The 'Rollback' method has been called" );
      }

      // The 'Rollback' procedure should be added here.
   }

   virtual void Commit( IDictionary^ mySavedState ) override
   {
      if ( myInstallContext->IsParameterTrue( "LogtoConsole" ) )
      {
         myInstallContext->LogMessage( "The 'Commit' method has been called" );
      }

      // The 'Commit' procedure should be added here.
   }
};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   InstallContext_Example^ myInstallObject = gcnew InstallContext_Example;
   IDictionary^ mySavedState = gcnew Hashtable;
   if ( args->Length < 2 )
   {
      // There are no command line arguments, create an empty 'InstallContext'.
      myInstallObject->myInstallContext = gcnew InstallContext;
   }
   else
   if ( (args->Length == 2) && (args[ 1 ]->Equals( "/?" )) )
   {
      // Display the 'Help' for this utility.
      Console::WriteLine( "Specify the '/Logfile' and '/LogtoConsole' parameters" );
      Console::WriteLine( "Example: " );
      Console::WriteLine( "InstallContext_InstallContext.exe /LogFile=example.log  /LogtoConsole=true" );
      return 0;
   }
   else
   {
      // Create an InstallContext object with the given parameters.
      array<String^>^commandLine = gcnew array<String^>(args->Length - 1);
      for ( int i = 0; i < args->Length - 1; i++ )
      {
         commandLine[ i ] = args[ i + 1 ];
      }
      myInstallObject->myInstallContext = gcnew InstallContext( args[ 1 ],commandLine );
   }

   try
   {
      // Call the 'Install' method.
      myInstallObject->Install( mySavedState );
      
      // Call the 'Commit' method.
      myInstallObject->Commit( mySavedState );
   }
   catch ( Exception^ ) 
   {
      // Call the 'Rollback' method.
      myInstallObject->Rollback( mySavedState );
   }
}