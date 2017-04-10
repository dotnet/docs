// System::Configuration::Install::InstallerCollection.Insert(Int32, Installer)
// System::Configuration::Install::InstallerCollection.AddRange(InstallerCollection)

/*
The following example demonstrates the 'Insert(Int32, Installer)' and
'AddRange(InstallerCollection)' methods of the 'InstallerCollection'
class. It Creates 'AssemblyInstaller' instances for 'MyAssembly1.exe'
and 'MyAssembly2.exe'. These instances of 'AssemblyInstaller' are
added to an instance of 'TransactedInstaller' named 'myTransactedInstaller1'.
The installers in the 'myTransactedInstaller1' are copied to another
instance of 'TransactedInstaller' named 'myTransactedInstaller2'.The
installation process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
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
// <Snippet1>
// <Snippet2>
   TransactedInstaller^ myTransactedInstaller1 = gcnew TransactedInstaller;
   TransactedInstaller^ myTransactedInstaller2 = gcnew TransactedInstaller;
   AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;
   InstallContext^ myInstallContext;
   
   // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller1->Installers->Insert( 0, myAssemblyInstaller );
   
   // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller1->Installers->Insert( 1, myAssemblyInstaller );
   
   // Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
   myTransactedInstaller2->Installers->AddRange( myTransactedInstaller1->Installers );
// </Snippet2>
// </Snippet1>

   // Create a instance of 'InstallContext' with log file named 'Install.log'.
   myInstallContext =
      gcnew InstallContext( "Install.log",nullptr );
   myTransactedInstaller2->Context = myInstallContext;
   
   // Install an assembly.
   myTransactedInstaller2->Install( gcnew Hashtable );
}
