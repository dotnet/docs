/*
   System.Configuration.Install.Installer.AfterInstall

   The following example demonstrates the event 'AfterInstall' of the 
   'Installer' class. The event 'AfterInstall' is raised by the method
   'OnAfterInstall'.
   
   Use the installer process 'InstallUtil' to run the assembly 
   'Installer_AfterInstall.exe'.
   
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
      AfterInstall += new InstallEventHandler(AfterInstallEventHandler);
   }
   private void AfterInstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions after the install process.
      Console.WriteLine("Code for AfterInstallEventHandler"); 
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
   }
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use installutil.exe to run the assembly Installer_AfterInstall.exe");
   }
}
