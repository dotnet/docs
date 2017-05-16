// System::Configuration::Install::InstallerCollection.Item(Int32)

/*
The following example demonstrates the 'Item(Int32)' method of the
'InstallerCollection' class. It creates 'AssemblyInstaller' instances
for 'MyAssembly1.exe' and 'MyAssembly2.exe'. These instances are added
to an instance of 'TransactedInstaller'. The names of all the assemblies
that are to be installed are displayed to the console.The installation
process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
*/

#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Configuration::Install;
using namespace System::IO;

void main()
{
   try
   {
      // <Snippet1>
      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller;
      InstallContext^ myInstallContext;
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Add( myAssemblyInstaller );
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Add( myAssemblyInstaller );
      
      //Print the assemblies to be installed.
      InstallerCollection^ myInstallers = myTransactedInstaller->Installers;
      Console::WriteLine( "\nPrinting all assemblies to be installed" );
      for ( int i = 0; i < myInstallers->Count; i++ )
      {
         if ( dynamic_cast<AssemblyInstaller^>(myInstallers[ i ]) )
         {
            Console::WriteLine( "{0} {1}", i + 1, safe_cast<AssemblyInstaller^>(myInstallers[ i ])->Path );
         }
      }
      // </Snippet1>

      // Create a instance of 'InstallContext' with log file named 'Install.log'.
      myInstallContext = gcnew InstallContext( "Install.log",nullptr );
      myTransactedInstaller->Context = myInstallContext;
      
      // Install an assembly .
      myTransactedInstaller->Install( gcnew Hashtable );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised : {0}", e->Message );
   }
}
