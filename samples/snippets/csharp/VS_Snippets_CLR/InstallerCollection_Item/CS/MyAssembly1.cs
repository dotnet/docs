/*
   This program is supposed to be used with the IntallerCollection_***.cs
   examples. Provide the exe of this program as input to the 
   InstallerCollection_***.exe programs.
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)]
public class MyInstaller : Installer
{
   

   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      Console.WriteLine("Install ...\n");
   }

   public override void Commit(IDictionary savedState)
   {
      base.Commit(savedState);
      Console.WriteLine("Committing ...\n");
   }

   public override void Rollback(IDictionary savedState)
   {
      base.Rollback(savedState);
      Console.WriteLine("RollBack ...\n");
   }

   public override void Uninstall(IDictionary savedState)
   {
      base.Uninstall(savedState);
      Console.WriteLine("UnInstall ...\n");
   }
}

// An Assembly that has its own installer.
public class MyAssembly1
{
   public static void Main()
   {
      Console.WriteLine("This assembly is just an example for the Installer\n");
   }
}



