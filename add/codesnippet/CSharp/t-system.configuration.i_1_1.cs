using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;


[RunInstaller(true)]
public class MyInstaller : Installer
{
   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      Console.WriteLine("Install ...");

      // Commit is called when install goes through successfully.
      // Rollback is called if there is any error during Install.

      // Uncommenting the code below will lead to 'RollBack' being called,
      // currently 'Commit' shall be called.

      // throw new IOException();
   }

   public override void Commit(IDictionary savedState)
   {
      base.Commit(savedState);
      Console.WriteLine("Commit ...");
      // Throw an error if a particular file doesn't exist.
      if(!File.Exists("FileDoesNotExist.txt"))
         throw new InstallException();
      // Perform the final installation if the file exists.
   }

   public override void Rollback(IDictionary savedState)
   {
      base.Rollback(savedState);
      Console.WriteLine("RollBack ...");
      try
      {
         // Performing some activity during rollback that raises an 'IOException'.
         throw new IOException();
      }
      catch(Exception e)
      {
         throw new InstallException("IOException raised", e);
      }
      // Perform the remaining rollback activites if no exception raised.
   }

   public override void Uninstall(IDictionary savedState)
   {
      base.Uninstall(savedState);
      Console.WriteLine("UnInstall ...");
      // Throw an error if a particular file doesn't exist.
      if(!File.Exists("FileDoesNotExist.txt"))
         throw new InstallException("The file 'FileDoesNotExist'" +
            " does not exist");
      // Perform the uninstall activites if the file exists.
   }
}


// An Assembly that has its own installer.
public class MyAssembly1
{
   public static void Main()
   {
      Console.WriteLine("This assembly is just an example for the Installer");
   }
}