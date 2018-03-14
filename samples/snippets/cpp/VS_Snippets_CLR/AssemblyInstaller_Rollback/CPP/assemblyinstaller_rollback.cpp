// System::Configuration::Install::AssemblyInstaller.Rollback
// System::Configuration::Install::AssemblyInstaller.Path
// System::Configuration::Install::AssemblyInstaller.CommandLine
/* The following example demonstrates the 'Rollback' method and the
'Path' and 'CommandLine' properties of the 'AssemblyInstaller' class.
An object of the AssemblyInstaller class is created by invoking the constructor.
The properties of this object are set and the install method is invoked on the
'MyAssembly.exe' assembly. The 'Rollback' method is called to undo the
install process on the specified assembly.
*/
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Configuration::Install;
using namespace System::Collections;
using namespace System::Collections::Specialized;
void main()
{
   IDictionary^ mySavedState = gcnew Hashtable;
   Console::WriteLine( "" );
   try
   {
      // <Snippet2>
      // Create an object of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;
      
      // Set the path property of the AssemblyInstaller object.
      myAssemblyInstaller->Path = "MyAssembly_Rollback.exe";
      
      // </Snippet2>
      // <Snippet3>
      // Set the logfile name in the commandline argument array.
      array<String^>^commandLineOptions = {"/LogFile=example.log"};
      myAssemblyInstaller->CommandLine = commandLineOptions;
      
      // </Snippet3>
      // Set the 'UseNewContext' property to true.
      myAssemblyInstaller->UseNewContext = true;
      
      // Install the 'MyAssembly_Rollback' assembly.
      myAssemblyInstaller->Install( mySavedState );
      
      // <Snippet1>
      // 'Rollback' the installation process.
      myAssemblyInstaller->Rollback( mySavedState );
      
      // </Snippet1>
   }
   catch ( ArgumentException^ ) 
   {
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
