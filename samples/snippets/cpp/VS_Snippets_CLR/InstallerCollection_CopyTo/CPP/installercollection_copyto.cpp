// System::Configuration::Install::InstallerCollection.CopyTo(Installer->Item[], Int32)

/*
   The following example demonstrates the 'CopyTo(Installer->Item[], Int32)' method
   of the 'InstallerCollection' class. It Creates 'AssemblyInstaller' instances
   for 'MyAssembly1.exe' and 'MyAssembly2.exe'. These instances of
   'AssemblyInstaller' are added to an instance of 'TransactedInstaller'
   instance. The names of the assemblies to be installed
   are displayed on the console. The installation process then installs
   both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
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
   // <Snippet1>
   TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
   AssemblyInstaller^ myAssemblyInstaller;
   InstallContext^ myInstallContext;
   
   // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller->Installers->Add( myAssemblyInstaller );
   
   // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller->Installers->Add( myAssemblyInstaller );

   array<Installer^>^ myInstallers =
      gcnew array<Installer^>(myTransactedInstaller->Installers->Count);

   myTransactedInstaller->Installers->CopyTo( myInstallers, 0 );
   // Print the assemblies to be installed.
   Console::WriteLine( "Printing all assemblies to be installed -" );
   for ( int i = 0; i < myInstallers->Length; i++ )
   {
      if ( dynamic_cast<AssemblyInstaller^>( myInstallers[ i ] ) )
      {
         Console::WriteLine( "{0} {1}", i + 1, ( (AssemblyInstaller^)( myInstallers[ i ]) )->Path );
      }
   }
// </Snippet1>
   
   // Create a instance of 'InstallContext' with log file named 'Install.log'.
   myInstallContext =
      gcnew InstallContext( "Install.log",nullptr );
   myTransactedInstaller->Context = myInstallContext;
   
   // Install an assembly.
   myTransactedInstaller->Install( gcnew Hashtable );
}
