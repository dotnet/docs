// System::Configuration::Install::AssemblyInstaller
/*  The following example demonstrates the 'AssemblyInstaller' class.
An object of the AssemblyInstaller class is created by invoking the constructor.
The properties of this object are set and the install and commit methods are
called to install the 'MyAssembly.exe' assembly.
*/
// <Snippet1>
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Configuration::Install;
using namespace System::Collections;
using namespace System::Collections::Specialized;
int main()
{
   IDictionary^ mySavedState = gcnew Hashtable;
   Console::WriteLine( "" );
   try
   {
      
      // Set the commandline argument array for 'logfile'.
      array<String^>^commandLineOptions = {"/LogFile=example.log"};
      
      // Create an object of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller(
         "MyAssembly.exe", commandLineOptions );
      myAssemblyInstaller->UseNewContext = true;
      
      // Install the 'MyAssembly' assembly.
      myAssemblyInstaller->Install( mySavedState );
      
      // Commit the 'MyAssembly' assembly.
      myAssemblyInstaller->Commit( mySavedState );
   }
   catch ( ArgumentException^ ) 
   {
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
// </Snippet1>
