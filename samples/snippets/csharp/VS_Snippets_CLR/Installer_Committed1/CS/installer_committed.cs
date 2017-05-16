// System.Configuration.Install.Installer.Committed

/* The following program demonstrates the 'Committed' event of the
   'Installer' class.  When the 'Commit' is complete, 'Committed' event
   is fired and a message is displayed.
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

// Set 'RunInstaller' attribute to true.
[RunInstaller(true)]
public class MyInstallerClass: Installer
{
// <Snippet1>
   public MyInstallerClass() :base()
   {
      // Attach the 'Committed' event.
      this.Committed += new InstallEventHandler(MyInstaller_Committed);
   }

   // Event handler for 'Committed' event.
   private void MyInstaller_Committed(object sender, InstallEventArgs e)
   {
      Console.WriteLine("Committed Event occured.");
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
   public static void Main()
   {
      Console.WriteLine("Usage : installutil.exe Installer_Committed.exe ");
   }
}
