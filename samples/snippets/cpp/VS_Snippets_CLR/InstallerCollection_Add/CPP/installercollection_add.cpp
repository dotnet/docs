// System::Configuration::Install::InstallerCollection
// System::Configuration::Install::InstallerCollection.Add(Installer)

/*
The following example demonstrates the Add(Installer)
method of the 'InstallerCollection' class. This example provides
an implementation similar to that of 'InstallUtil.exe'. It installs
assemblies with the options preceding that particular assembly.
If an option is not specified for an assembly the previous assemblies
options are taken if there is a previous assembly in the list. If the
'/u' or '/uninstall' option is specified then the assemblies are uninstalled.
If the '/?' or '/help' option is provided then the help information is
displayed to the console.
*/

// <Snippet1>
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Configuration::Install;
using namespace System::IO;

void PrintHelpMessage()
{
   Console::WriteLine( "Usage : InstallerCollection_Add [/u | /uninstall] [option [...]] assembly " +
      "[[option [...]] assembly] [...]]" );
   Console::WriteLine( "InstallerCollection_Add executes the installers in each of" +
      "the given assembly. If /u or /uninstall option" + 
      "option is given it uninstalls the assemblies." );
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   ArrayList^ options = gcnew ArrayList;
   String^ myOption;
   bool toUnInstall = false;
   bool toPrintHelp = false;
   TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
   AssemblyInstaller^ myAssemblyInstaller;
   InstallContext^ myInstallContext;

   try
   {
      for ( int i = 0; i < args->Length; i++ )
      {
         // Process the arguments.
         if ( args[ i ]->StartsWith( "/" ) || args[ i ]->StartsWith( "-" ) )
         {
            myOption = args[ i ]->Substring( 1 );
            // Determine whether the option is to 'uninstall' a assembly.
            if ( String::Compare( myOption, "u", true ) == 0 ||
               String::Compare( myOption, "uninstall", true ) == 0 )
            {
               toUnInstall = true;
               continue;
            }
            // Determine whether the option is for printing help information.
            if ( String::Compare( myOption, "?", true ) == 0 ||
               String::Compare( myOption, "help", true ) == 0 )
            {
               toPrintHelp = true;
               continue;
            }
            // Add the option encountered to the list of all options
            // encountered for the current assembly.
            options->Add( myOption );
         }
         else
         {
            // Determine whether the assembly file exists.
            if (  !File::Exists( args[ i ] ) )
            {
               // If assembly file doesn't exist then print error.
               Console::WriteLine( " Error : {0} - Assembly file doesn't exist.", args[ i ] );
               return 0;
            }
// <Snippet2>
            // Create an instance of 'AssemblyInstaller' that installs the given assembly.
            myAssemblyInstaller = gcnew AssemblyInstaller( args[ i ],
              (array<String^>^)(options->ToArray( String::typeid )) );
            // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
            myTransactedInstaller->Installers->Add( myAssemblyInstaller );
// </Snippet2>
         }
      }
      // then print help message.
      if ( toPrintHelp || myTransactedInstaller->Installers->Count == 0 )
      {
         PrintHelpMessage();
         return 0;
      }

      // Create an instance of 'InstallContext' with the options specified.
      myInstallContext =
         gcnew InstallContext( "Install.log",
              (array<String^>^)(options->ToArray( String::typeid )) );
      myTransactedInstaller->Context = myInstallContext;

      // Install or Uninstall an assembly depending on the option provided.
      if (  !toUnInstall )
         myTransactedInstaller->Install( gcnew Hashtable );
      else
         myTransactedInstaller->Uninstall( nullptr );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( " Exception raised : {0}", e->Message );
   }
}
// </Snippet1>
