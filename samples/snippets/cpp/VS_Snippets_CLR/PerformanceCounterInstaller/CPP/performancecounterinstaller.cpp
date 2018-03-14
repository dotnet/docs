// cpp.cpp : main project file.
// System::Diagnostics.PerformanceCounterInstaller
/*
The following example demonstrates 'PerformanceCounterInstaller' class.
A class is inherited from 'Installer' having 'RunInstallerAttribute' set to true.
A new instance of 'PerformanceCounterInstaller' is created and its 'CategoryName'
is set. Then this instance is added to 'InstallerCollection'.
Note: 
1)To run this example use the following command:
InstallUtil::exe PerformanceCounterInstaller::exe
2)To uninstall the perfomance counter use the following command:
InstallUtil::exe /u PerformanceCounterInstaller::exe
*/
// <Snippet1>
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
// </Snippet1>
