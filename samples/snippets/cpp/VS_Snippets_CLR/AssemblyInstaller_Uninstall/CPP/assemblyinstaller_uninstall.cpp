// System::Configuration::Install::AssemblyInstaller.AssemblyInstaller(String*, String*->Item[])
// System::Configuration::Install::AssemblyInstaller.Uninstall
/* The following example demonstrates the 'AssemblyInstaller(String*, String*->Item[])'
constructor and the 'Uninstall' method of the 'AssemblyInstaller' class.
An object of the AssemblyInstaller class is created by invoking the constructor
with the assembly to install and the commandline argument array as
parameters. The uninstall method is called after installing and committing
the assembly passed as the parameter to the constructor.
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
      // <Snippet1>
      array<String^>^myStringArray = {"/logFile=example.log"};
      String^ myString = "MyAssembly_Uninstall.exe";
      
      // Create an object of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller =
         gcnew AssemblyInstaller( myString,myStringArray );
      // </Snippet1>

      // Install and commit the 'MyAssembly_Uninstall' assembly.
      mySavedState->Clear();
      myAssemblyInstaller->Install( mySavedState );
      myAssemblyInstaller->Commit( mySavedState );
      
      // <Snippet2>
      // Uninstall the 'MyAssembly_Uninstall' assembly.
      myAssemblyInstaller->Uninstall( mySavedState );
      // </Snippet2>
   }
   catch ( ArgumentException^ ) 
   {
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( myException->Message );
   }
}
