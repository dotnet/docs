/*
   System.Configuration.Install.Installer.BeforeInstall

   The following example demonstrates the event 'BeforeInstall' of the 
   'Installer' class. The event 'BeforeInstall' is raised by the method
   'OnBeforeInstall'.
   
   Use the installer process 'InstallUtil' to run the assembly 
   Installer_BeforeInstall.exe.
   
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
      BeforeInstall += new InstallEventHandler(BeforeInstallEventHandler);
   }
   private void BeforeInstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions before the install process.
      Console.WriteLine("Code for BeforeInstallEventHandler"); 
   }
// </Snippet1>
   
   // Override the 'Install' method.
   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      Console.WriteLine("");
      Console.WriteLine("Install method of MyInstaller called");
      Console.WriteLine("");
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
   }

   // Override the 'OnBeforeInstall' method.
   protected override void OnBeforeInstall(IDictionary savedState)
   {
      base.OnBeforeInstall(savedState);
      Console.WriteLine("");
      Console.WriteLine("OnBeforeInstall method of MyInstaller called");
      Console.WriteLine("");
   }

   // Override the 'OnAfterInstall' method.
   protected override void OnAfterInstall(IDictionary savedState)
   {
      base.OnAfterInstall(savedState);
      Console.WriteLine("");
      Console.WriteLine("OnAfterInstall method of MyInstaller called");
      Console.WriteLine("");
   }
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use installutil.exe to run the assembly Installer_BeforeInstall.exe");
   }
}
