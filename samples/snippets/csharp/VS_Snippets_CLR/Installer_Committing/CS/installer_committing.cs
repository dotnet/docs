// System.Configuration.Install.Installer.Committing

/* The following program demonstrates the 'Committing' event of the 
   'Installer' class.  When the 'Commit' is about to complete, 
   'Committing' event is fired and a message is displayed.
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
      // Attach the 'Committing' event.
      this.Committing += new InstallEventHandler(MyInstaller_Committing);
   }
   // Event handler for 'Committing' event.
   private void MyInstaller_Committing(object sender, InstallEventArgs e)
   {
      Console.WriteLine("Committing Event occured.");
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
      Console.WriteLine("Usage : installutil.exe Installer_Committing.exe ");            
   }
}
