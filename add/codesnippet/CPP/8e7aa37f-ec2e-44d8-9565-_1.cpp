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
      
      // Create an Object* of the 'AssemblyInstaller' class.
      AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;

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