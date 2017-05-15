// System.Configuration.Install.UninstallAction
// System.Configuration.Install.UninstallAction.NoAction
// System.Configuration.Install.UninstallAction.Remove

/* The following program demonstrates "NoAction" and "Remove" 
   members of "UninstallAction" enumeration. A resource is 
   installed and uninstalled using 'installutil.exe' in an event 
   log depending on the user input.
*/

// <Snippet1>
using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)]
public class MyUninstallActionClass : Installer 
{
   EventLogInstaller myInstaller = new EventLogInstaller();
   
   // Override the 'Install' method.
   public override void Install(IDictionary savedState)
   {
      Console.Write("Enter a new log to create (eg: MyLog ): ");
      myInstaller.Log = Console.ReadLine();
      Console.Write("Enter a source for log (eg: MySource ): ");
      myInstaller.Source = Console.ReadLine();
      Installers.Add( myInstaller );
      base.Install(savedState);
   }

   // Override the 'Commit' method.
   public override void Commit(IDictionary savedState)
   {
      base.Commit(savedState);
   }

   // Override the 'Rollback' method.
   public override void Rollback(IDictionary savedState)
   {
      base.Rollback(savedState);
   }
// <Snippet3>
// <Snippet2>
   public override void Uninstall(IDictionary savedState)
   {
      Console.Write("Enter a source from log to uninstall(eg: MySource ): ");
      myInstaller.Source = Console.ReadLine();

      Console.Write("Do you want to uninstall, press 'y' for 'YES' and 'n' for 'NO':");
      string myUninstall = Console.ReadLine();
     
      if( myUninstall == "n" )
      {
         // No action to be taken on the resource in the event log.
         myInstaller.UninstallAction = System.Configuration.Install.UninstallAction.NoAction;
      }
      else
      {
         // Remove the resource from the event log.
         myInstaller.UninstallAction = System.Configuration.Install.UninstallAction.Remove;
      }
      Installers.Add( myInstaller );
      base.Uninstall(savedState);
   }
// </Snippet2>
// </Snippet3>
   public static void Main()
   {
      Console.WriteLine("Syntax for install: installutil.exe UninstallAction_NoAction_Remove_3.exe ");
      Console.WriteLine("Syntax for uninstall: installutil.exe /u "
         +"UninstallAction_NoAction_Remove_3.exe ");
   }

}
// </Snippet1>
