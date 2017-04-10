// System.Diagnostics.EventLogInstaller

// The following example demonstrates the EventLogInstaller class.
// It defines the instance MyEventLogInstaller with the
// attribute RunInstallerAttribute.
//
// The Log and Source properties of the new instance are set,
// and the instance is added to the Installers collection.
//
// Note:
//     1) Run this program using the following command: 
//          InstallUtil.exe  <filename.exe>
//     2) Uninstall the event log created in step 1 using the
//        following command:
//          InstallUtil.exe /u <filename.exe>

// <Snippet1>
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Configuration::Install;
using namespace System::Diagnostics;
using namespace System::ComponentModel;

[RunInstaller(true)]
ref class MyEventLogInstaller: public Installer
{
private:
   EventLogInstaller^ myEventLogInstaller;

public:
   MyEventLogInstaller()
   {
      // Create an instance of an EventLogInstaller.
      myEventLogInstaller = gcnew EventLogInstaller;

      // Set the source name of the event log.
      myEventLogInstaller->Source = "NewLogSource";
         
      // Set the event log that the source writes entries to.
      myEventLogInstaller->Log = "MyNewLog";
         
      // Add myEventLogInstaller to the Installer collection.
      Installers->Add( myEventLogInstaller );
   }
};
// </Snippet1>

void main(){}
