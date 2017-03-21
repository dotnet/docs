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