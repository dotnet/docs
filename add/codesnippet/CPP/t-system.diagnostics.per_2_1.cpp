#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Configuration::Install;
using namespace System::Diagnostics;
using namespace System::ComponentModel;

[RunInstaller(true)]
ref class MyPerformanceCounterInstaller: public Installer
{
public:
   MyPerformanceCounterInstaller()
   {
      try
      {
         // Create an instance of 'PerformanceCounterInstaller'.
         PerformanceCounterInstaller^ myPerformanceCounterInstaller =
            gcnew PerformanceCounterInstaller;
         // Set the 'CategoryName' for performance counter.
         myPerformanceCounterInstaller->CategoryName =
            "MyPerformanceCounter";
         CounterCreationData^ myCounterCreation = gcnew CounterCreationData;
         myCounterCreation->CounterName = "MyCounter";
         myCounterCreation->CounterHelp = "Counter Help";
         // Add a counter to collection of  myPerformanceCounterInstaller.
         myPerformanceCounterInstaller->Counters->Add( myCounterCreation );
         Installers->Add( myPerformanceCounterInstaller );
      }
      catch ( Exception^ e ) 
      {
		  this->Context->LogMessage( "Error occured : " + e->Message );
      }
   }
};