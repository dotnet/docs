/*
   System.Configuration.Install.Installer.OnBeforeInstall(IDictionary savedState)
   System.Configuration.Install.Installer.OnAfterInstall(IDictionary savedState)

   The following example demonstrates the methods 'OnBeforeInstall' and
   'OnAfterInstall' of the 'Installer' class. The methods 'OnBeforeInstall'
   and 'OnAfterInstall' are overridden in the derived class. Space is provided
   to add steps to be done before the installation in 'OnBeforeInstall' method 
   and after the installation in 'OnAfterInstall' method.
   
   Use the installer process 'InstallUtil' to run the assembly 
   Installer_OnInstall.exe.
   
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)]
public class MyInstaller: Installer
{
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
   }
// <Snippet1>
   // Override the 'OnBeforeInstall' method.
   protected override void OnBeforeInstall(IDictionary savedState)
   {
      base.OnBeforeInstall(savedState);
      // Add steps to be done before the installation starts.
      Console.WriteLine("OnBeforeInstall method of MyInstaller called");
   }
// </Snippet1>
// <Snippet2>
   // Override the 'OnAfterInstall' method.
   protected override void OnAfterInstall(IDictionary savedState)
   {
      base.OnAfterInstall(savedState);
      // Add steps to be done after the installation is over.
      Console.WriteLine("OnAfterInstall method of MyInstaller called");
   }
// </Snippet2>
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use installutil.exe to run the assembly Installer_OnInstall.exe");
   }
}
