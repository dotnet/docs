// System.Configuration.Install.Installer.AfterRollback

/* The following program demonstrates the 'AfterRollback' event of the
   'Installer' class. It overrides the Install method, explicitly throws
   arguement exception so that 'Rollback' method is called. When the
   'RollBack' is complete, 'AfterRollback' event occurs and a message is
   displayed when the event occurs.
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
      // Attach the 'AfterRollback' event.
      this.AfterRollback += new InstallEventHandler(MyInstaller_AfterRollBack);
   }
   // Event handler for 'AfterRollback' event.
   private void MyInstaller_AfterRollBack(object sender, InstallEventArgs e)
   {
      Console.WriteLine("AfterRollBack Event occured.");
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
      Console.WriteLine("Usage : installutil.exe Installer_AfterRollback.exe ");
   }
}
// </Snippet1>
