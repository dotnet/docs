// System.Configuration.Install.Installer.BeforeRollback

/* The following program demonstrates the 'BeforeRollback' event of the 
   'Installer' class. It overrides the Install method, explicitly throws
   arguement exception so that 'Rollback' method is called. When the 
   'RollBack' is about to complete, 'BeforeRollback' event occurs and
   a message is displayed when the event occurs.   
*/

// <Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

// Set 'RunInstaller' attribute to true.
[RunInstaller(true)]
public class MyInstallerClass: Installer
{
   public MyInstallerClass() :base()
   {
      // Attach the 'BeforeRollback' event.
      this.BeforeRollback += new InstallEventHandler(MyInstaller_BeforeRollBack);
      // Attach the 'AfterRollback' event.
      this.AfterRollback += new InstallEventHandler(MyInstaller_AfterRollback);
   }
   // Event handler for 'BeforeRollback' event.
   private void MyInstaller_BeforeRollBack(object sender, InstallEventArgs e)
   {
      Console.WriteLine("");
      Console.WriteLine("BeforeRollback Event occured.");
      Console.WriteLine("");        
   }
   // Event handler for 'AfterRollback' event.
   private void MyInstaller_AfterRollback(object sender, InstallEventArgs e)
   {
      Console.WriteLine("");
      Console.WriteLine("AfterRollback Event occured.");
      Console.WriteLine("");        
   }
   // Override the 'Install' method.
   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      // Explicitly throw an exception so that roll back is called.
      throw new ArgumentException("Arg Exception");
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
   public static void Main()
   {
      Console.WriteLine("Usage : installutil.exe Installer_BeforeRollback.exe ");      
   }
}
// </Snippet1>
