// System::Configuration::Install::InstallerCollection.AddRange(Installer->Item[])

/*
   The following example demonstrates the 'AddRange(Installer->Item[])'
   method of the 'InstallerCollection' class. It Creates 'AssemblyInstaller'
   instances for 'MyAssembly1.exe' and for 'MyAssembly2.exe'. These
   instances are added to an instance of 'TransactedInstaller'. The installation
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
      ArrayList^ myInstallers = gcnew ArrayList;
      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller;
      InstallContext^ myInstallContext;

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller =
         gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );

      // Add the instance of 'AssemblyInstaller' to the list of installers.
      myInstallers->Add( myAssemblyInstaller );

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller =
         gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );

      // Add the instance of 'AssemblyInstaller' to the list of installers.
      myInstallers->Add( myAssemblyInstaller );

      // Add the installers to the 'TransactedInstaller' instance.
      myTransactedInstaller->Installers->AddRange( safe_cast<array<Installer^>^>(myInstallers->ToArray( Installer::typeid )) );
// </Snippet1>

      // Create a instance of 'InstallContext' with log file named 'Install::log'.
      myInstallContext =
         gcnew InstallContext( "Install.log",nullptr );
      myTransactedInstaller->Context = myInstallContext;

      // Install an assembly.
      myTransactedInstaller->Install( gcnew Hashtable );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised : {0}", e->Message );
   }
}
