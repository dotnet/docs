
using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;

[RunInstaller(true)]
public class MyInstaller : Installer
{
   // Simple events to handle before and after commit handlers.
   public event InstallEventHandler BeforeCommit;
   public event InstallEventHandler AfterCommit;
   
   public MyInstaller()
   {
      // Add handlers to the events.
      BeforeCommit += new InstallEventHandler(BeforeCommitHandler);
      AfterCommit += new InstallEventHandler(AfterCommitHandler);
   }

   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      Console.WriteLine("Install ...\n");
   }

   public override void Commit(IDictionary savedState)
   {
      Console.WriteLine("Before Committing ...\n");
      // Call the 'OnBeforeCommit' protected method.
      OnBeforeCommit(savedState);
      base.Commit(savedState);
      Console.WriteLine("Committing ...\n");
      // Call the 'OnAfterCommit' protected method.
      OnAfterCommit(savedState);
      Console.WriteLine("After Committing ...\n");
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
   
   // Protected method that invoke the handlers associated with the 'BeforeCommit' event.
   protected virtual void OnBeforeCommit(IDictionary savedState)
   {
      if(BeforeCommit != null)
         BeforeCommit(this, new InstallEventArgs(savedState)); 
   }

   // Protected method that invoke the handlers associated with the 'AfterCommit' event.
   protected virtual void OnAfterCommit(IDictionary savedState)
   {
      if(AfterCommit != null)
         AfterCommit(this, new InstallEventArgs());
   }

   // A simple event handler to exemplify the example.
   private void BeforeCommitHandler(Object sender, InstallEventArgs e)
   {
      Console.WriteLine("BeforeCommitHandler event handler has been called\n");
      Console.WriteLine("The count of saved state objects are : {0}\n",
         e.SavedState.Count);
   }

   // A simple event handler to exemplify the example.
   private void AfterCommitHandler(Object sender, InstallEventArgs e)
   {
      Console.WriteLine("AfterCommitHandler event handler has been called\n");
   }
}