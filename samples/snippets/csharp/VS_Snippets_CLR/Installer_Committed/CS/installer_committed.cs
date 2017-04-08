/*
   System.Configuration.Install.Installer.OnCommitting(Idictionary savedState)
   System.Configuration.Install.Installer.OnCommitted(Idictionary savedState)

   The following example demonstrates the methods 'OnCommitting' and
   'OnCommitted' of the 'Installer' class. The methods 'OnCommitting' and
   'OnCommitted' are overridden in the derived class. Space is provided
   for the user to add the steps to be performed before committing and
   after committing.
  
   'Installer_Committed.exe' needs to be run using the installer process 
   'installutil'. 
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
// <Snippet1>
   // Override the 'OnCommitting' method.
   protected override void OnCommitting(IDictionary savedState)
   {
      base.OnCommitting(savedState);
      // Add steps to be done before committing an application.
      Console.WriteLine("The OnCommitting method of MyInstaller called");
   }
// </Snippet1>
// <Snippet2>
   // Override the 'OnCommitted' method.
   protected override void OnCommitted(IDictionary savedState)
   {
      base.OnCommitted(savedState);
      // Add steps to be done after committing an application.
      Console.WriteLine("The OnCommitted method of MyInstaller called");
   }
// </Snippet2>
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use installutil.exe to run the assembly Installer_Committed.exe");
   }
}

