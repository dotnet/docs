// System.Configuration.Install.ComponentInstaller.CopyFromComponent
// System.Configuration.Install.ComponentInstaller.IsEquivalentInstaller

/* The following example demonstrates the 'CopyFromComponent' and
   the 'IsEquivalentInstaller' methods of the 'ComponentInstaller' class.
   It defines a class MyInstallClass, which creates the event log and copies
   the properties of the event log component to the 'EventLogInstaller' object.
   It also checks whether 'ServiceInstaller' object can handle the same kind of 
   installation as 'EventLogInstaller' object. 
*/

using System;
using System.Diagnostics;
using System.ServiceProcess;

   public class ComponentInstaller_Example
   {
      static void Main()
      {
// <Snippet1>
         EventLogInstaller myEventLogInstaller = new EventLogInstaller();
         // Create a source for the specified event log, on local computer.
         EventLog.CreateEventSource("MyEventSource","MyEventLog", ".");
         // Create an event log instance and associate it with the log .
         EventLog myEventLog = new EventLog("MyEventLog", ".", "MyEventSource");
         // Copy the properties that are required at install time from
         // the event log component to the installer.
         myEventLogInstaller.CopyFromComponent(myEventLog);
// </Snippet1>
         Console.WriteLine("The properties of the event log component : ");
         Console.WriteLine(myEventLogInstaller.Log);
         Console.WriteLine(myEventLogInstaller.Source);
// <Snippet2>
         ServiceInstaller myServiceInstaller = new  ServiceInstaller();
         // Check whether 'ServiceInstaller' object can handle the same 
         // kind of installation as 'EventLogInstaller' object.
         if(myEventLogInstaller.IsEquivalentInstaller(myServiceInstaller))
         {
            Console.WriteLine("'ServiceInstaller' can handle the same kind" 
                              +" of installation as EventLogInstaller");
         }
         else
         {
             Console.WriteLine("'ServiceInstaller' can't handle the same" 
                          +" kind of installation as 'EventLogInstaller'");
         }
// </Snippet2>
          EventLog.Delete("MyEventLog",".");
      }
   }
