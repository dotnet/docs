// System.Configuration.Install.InstallEventArgs
// System.Configuration.Install.InstallEventArgs.InstallEventArgs()
// System.Configuration.Install.InstallEventArgs.InstallEventArgs(IDictionary)
// System.Configuration.Install.InstallEventArgs.SavedState

/*
   The following example demonstrates the 'InstallEventArgs()' and 
   'InstallEventArgs(IDictionary)' constructors and the 'SavedState'
   property of the 'InstallEventArgs' property. There are two new
   events called 'BeforeCommit' and 'AfterCommit'. The handlers of
   these events are invoked from the protected methods named 'OnBeforeCommit'
   and 'OnAfterCommit' respectively. These events are raised when the 
   'Commit' method is called.
   
   Note : 
   a) The two events named 'BeforeCommit' and 'AfterCommit' are added 
   only for example purposes, since there are already
   events named 'Committing' and 'Committed' which perform the same
   function. This example can be made a basis for a new stage being
   added to the already existing four stages namely 'Install', 'Commit',
   'Rollback' and 'Uninstall'.
   
   b) Run the example with the help of InstallUtil.exe
      InstallUtil InstallEventArgs.exe
*/

// <Snippet1>

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
   
// <Snippet3>
   // Protected method that invoke the handlers associated with the 'BeforeCommit' event.
   protected virtual void OnBeforeCommit(IDictionary savedState)
   {
      if(BeforeCommit != null)
         BeforeCommit(this, new InstallEventArgs(savedState)); 
   }
// </Snippet3>

// <Snippet2>
   // Protected method that invoke the handlers associated with the 'AfterCommit' event.
   protected virtual void OnAfterCommit(IDictionary savedState)
   {
      if(AfterCommit != null)
         AfterCommit(this, new InstallEventArgs());
   }
// </Snippet2>

// <Snippet4>
   // A simple event handler to exemplify the example.
   private void BeforeCommitHandler(Object sender, InstallEventArgs e)
   {
      Console.WriteLine("BeforeCommitHandler event handler has been called\n");
      Console.WriteLine("The count of saved state objects are : {0}\n",
         e.SavedState.Count);
   }
// </Snippet4>

   // A simple event handler to exemplify the example.
   private void AfterCommitHandler(Object sender, InstallEventArgs e)
   {
      Console.WriteLine("AfterCommitHandler event handler has been called\n");
   }
}
// </Snippet1>

// An Assembly that has its own installer.
public class MyAssembly1
{
   public static void Main()
   {
      Console.WriteLine("This assembly is just an example for the Installer\n");
   }
}



