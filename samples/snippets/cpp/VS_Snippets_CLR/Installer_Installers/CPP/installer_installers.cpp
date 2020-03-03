/*
System::Configuration::Install::Installer.Installers
System::Configuration::Install::Installer.Parent

The following example demonstrates the properties 'Installers' and
'Parent'. The Installers property shows the InstallerCollection
associated with an Installer and the Parent property gets the
installer containing the collection that this installer belongs to.
*/

#using <System.dll>
#using <System.Configuration.Install.dll>
#using <System.Serviceprocess.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ServiceProcess;
using namespace System::Diagnostics;
using namespace System::Configuration::Install;

void main()
{
// <Snippet1>
   AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;
   ServiceInstaller^ myServiceInstaller = gcnew ServiceInstaller;
   EventLogInstaller^ myEventLogInstaller = gcnew EventLogInstaller;

   InstallerCollection^ myInstallerCollection = myAssemblyInstaller->Installers;
   
   // Add Installers to the InstallerCollection of 'myAssemblyInstaller'.
   myInstallerCollection->Add( myServiceInstaller );
   myInstallerCollection->Add( myEventLogInstaller );

   array<Installer^>^ myInstaller = gcnew array<Installer^>(2);
   myInstallerCollection->CopyTo( myInstaller, 0 );
   // Show the contents of the InstallerCollection of 'myAssemblyInstaller'.
   Console::WriteLine( "Installers in the InstallerCollection : " );
   for ( int iIndex = 0; iIndex < myInstaller->Length; iIndex++ )
      Console::WriteLine( myInstaller[ iIndex ]->ToString() );
// </Snippet1>
   Console::WriteLine( "" );
// <Snippet2>
   AssemblyInstaller^ myAssemblyInstaller1 = gcnew AssemblyInstaller;
   InstallerCollection^ myInstallerCollection1 = myAssemblyInstaller1->Installers;
   // 'myAssemblyInstaller' is an installer of type 'AssemblyInstaller'.
   myInstallerCollection1->Add( myAssemblyInstaller );

   Installer^ myInstaller1 = myAssemblyInstaller->Parent;
   Console::WriteLine( "Parent of myAssembly : {0}", myInstaller1 );
// </Snippet2>
}
