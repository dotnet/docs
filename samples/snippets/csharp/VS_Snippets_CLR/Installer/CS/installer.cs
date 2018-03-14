// System.Configuration.Install.Installer

/* The following program demonstrates the use of the 'Installer'
   class. It creates a class which inherits from 'Installer'.
   When the 'Commit' is about to complete, 'Committing' event
   occurs and a message is displayed when the event occurs.
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
      // Attach the 'Committed' event.
      this.Committed += new InstallEventHandler(MyInstaller_Committed);
      // Attach the 'Committing' event.
      this.Committing += new InstallEventHandler(MyInstaller_Committing);

   }
   // Event handler for 'Committing' event.
   private void MyInstaller_Committing(object sender, InstallEventArgs e)
   {
      Console.WriteLine("");
      Console.WriteLine("Committing Event occured.");
      Console.WriteLine("");
   }
   // Event handler for 'Committed' event.
   private void MyInstaller_Committed(object sender, InstallEventArgs e)
   {
      Console.WriteLine("");
      Console.WriteLine("Committed Event occured.");
      Console.WriteLine("");
   }
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
      Console.WriteLine("Usage : installutil.exe Installer.exe ");
   }
}
// </Snippet1>