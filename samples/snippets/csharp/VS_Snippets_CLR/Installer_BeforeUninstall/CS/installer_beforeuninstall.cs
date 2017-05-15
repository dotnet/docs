/*
   System.Configuration.Install.Installer.BeforeUninstall

   The following example demonstrates the event 'BeforeUninstall' of the 
   'Installer' class. This event is raised by the method 'OnBeforeUninstall'.
   
   Use the installer process 'InstallUtil -u' to run the assembly 
   'Installer_BeforeUninstall.exe'.
   
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)]
public class MyInstaller: Installer
{
// <Snippet1>
   // MyInstaller is derived from the class 'Installer'.
   MyInstaller() : base()
   {
      BeforeUninstall += new InstallEventHandler(BeforeUninstallEventHandler);
   }
   private void BeforeUninstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for BeforeUninstallEventHandler"); 
   }
// </Snippet1>
   
   // Override the 'Install' method.
   public override void Install(IDictionary savedState)
   {
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

   // Override the 'Uninstall' method.
   public override void Uninstall(IDictionary savedState)
   {
      base.Uninstall(savedState);
      Console.WriteLine("");
      Console.WriteLine("Uninstall method of MyInstaller called");
      Console.WriteLine("");
   }

   // Override the 'OnBeforeUninstall' method.
   protected override void OnBeforeUninstall(IDictionary savedState)
   {
      base.OnBeforeUninstall(savedState);
      Console.WriteLine("");
      Console.WriteLine("OnBeforeUninstall method of MyInstaller called");
      Console.WriteLine("");
   }

   // Override the 'OnAfterUninstall' method.
   protected override void OnAfterUninstall(IDictionary savedState)
   {
      base.OnAfterUninstall(savedState);
      Console.WriteLine("");
      Console.WriteLine("OnAfterUninstall method of MyInstaller called");
      Console.WriteLine("");
   }
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use 'installutil.exe -u' to run the assembly Installer_BeforeUninstall.exe");
   }
}
