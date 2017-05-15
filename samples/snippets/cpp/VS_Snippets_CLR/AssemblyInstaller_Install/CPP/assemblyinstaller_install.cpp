// System::Configuration::Install::AssemblyInstaller.AssemblyInstaller()
// System::Configuration::Install::AssemblyInstaller.Install
// System::Configuration::Install::AssemblyInstaller.Commit
/* The following example demonstrates the 'AssemblyInstaller()' constructor and
the 'Install' and 'Commit' methods of the 'AssemblyInstaller' class.
An object of the AssemblyInstaller class is created by invoking the constructor.
The properties of this object are set and the install and commit methods are
called to install the 'MyAssembly_Install.exe' assembly.
*/
// <Snippet2>
// <Snippet3>
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
      // Set the commandline argument array for 'logfile'.
      array<String^>^myString = {"/logFile=example.log"};
      
      // <Snippet1>
      // Create an Object* of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;
      // </Snippet1>

      // Set the properties to install the required assembly.
      myAssemblyInstaller->Path = "MyAssembly_Install.exe";
      myAssemblyInstaller->CommandLine = myString;
      myAssemblyInstaller->UseNewContext = true;
      
      // Clear the 'IDictionary' Object*.
      mySavedState->Clear();
      
      // Install the 'MyAssembly_Install' assembly.
      myAssemblyInstaller->Install( mySavedState );
      
      // Commit the 'MyAssembly_Install' assembly.
      myAssemblyInstaller->Commit( mySavedState );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }
}
// </Snippet2>
// </Snippet3>
