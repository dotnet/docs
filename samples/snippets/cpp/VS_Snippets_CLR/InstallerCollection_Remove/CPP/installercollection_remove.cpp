// System::Configuration::Install::InstallerCollection.Remove(Installer)
// System::Configuration::Install::InstallerCollection.Contains(Installer)
// System::Configuration::Install::InstallerCollection.IndexOf(Installer)

/*
The following example demonstrates the 'Remove(Installer)',
'Contains(Installer)' and 'IndexOf(Installer)' methods of the
'InstallerCollection' class. Create's 'AssemblyInstaller' instances
for 'MyAssembly1.exe' and for 'MyAssembly2.exe'. These instances
of 'AssemblyInstaller' are added to an instance of 'TransactedInstaller'.
The 'AssemblyIntaller' instance for 'MyAssembly2.exe' is removed
from the installers collection of the 'TransactedInstaller' instance.
The installation process is started which installs only 'MyAssembly1.exe'.
*/

#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Configuration::Install;
using namespace System::IO;
void main()
{
   try
   {
      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller1;
      AssemblyInstaller^ myAssemblyInstaller2;
      InstallContext^ myInstallContext;
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller1 = gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Insert( 0, myAssemblyInstaller1 );
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller2 = gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Insert( 1, myAssemblyInstaller2 );
      
      // Remove the 'myAssemblyInstaller2' from the 'Installers' collection.
      if ( myTransactedInstaller->Installers->Contains( myAssemblyInstaller2 ) )
      {
         Console::WriteLine( "\nInstaller at index : {0} is being removed", myTransactedInstaller->Installers->IndexOf( myAssemblyInstaller2 ) );
         myTransactedInstaller->Installers->Remove( myAssemblyInstaller2 );
      }
      // </Snippet3>
      // </Snippet2>
      // </Snippet1>

      //Print the installers to be installed.
      InstallerCollection^ myInstallers = myTransactedInstaller->Installers;
      Console::WriteLine( "\nPrinting all installers to be installed\n" );
      for ( int i = 0; i < myInstallers->Count; i++ )
      {
         if ( dynamic_cast<AssemblyInstaller^>(myInstallers[ i ]) )
         {
            Console::WriteLine( "{0} {1}", i + 1, safe_cast<AssemblyInstaller^>(myInstallers[ i ])->Path );
         }
      }
      
      // Create a instance of 'InstallContext' with log file named 'Install.log'.
      myInstallContext = gcnew InstallContext( "Install.log",nullptr );
      myTransactedInstaller->Context = myInstallContext;
      
      // Install an assembly.
      myTransactedInstaller->Install( gcnew Hashtable );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised : {0}", e->Message );
   }
}
