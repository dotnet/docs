Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO
Imports Microsoft.VisualBasic

<RunInstaller(True)> Public Class MyInstaller
   Inherits Installer
   ' Simple events to handle before and after commit handlers.
   Public Event BeforeCommit As InstallEventHandler
   Public Event AfterCommit As InstallEventHandler

   Public Sub New()
      ' Add handlers to the events.
      AddHandler BeforeCommit, AddressOf BeforeCommitHandler
      AddHandler AfterCommit, AddressOf AfterCommitHandler
   End Sub

   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
      Console.WriteLine("Install ..." + ControlChars.Newline)
   End Sub

   Public Overrides Sub Commit(savedState As IDictionary)
      Console.WriteLine("Before Committing ..." + ControlChars.Newline)
      ' Call the 'OnBeforeCommit' protected method.
      OnBeforeCommit(savedState)
      MyBase.Commit(savedState)
      Console.WriteLine("Committing ..." + ControlChars.Newline)
      ' Call the 'OnAfterCommit' protected method.
      OnAfterCommit(savedState)
      Console.WriteLine("After Committing ..." + ControlChars.Newline)
   End Sub

   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
      Console.WriteLine("RollBack ..." + ControlChars.Newline)
   End Sub

   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("UnInstall ..." + ControlChars.Newline)
   End Sub

   ' Protected method that invoke the handlers associated with the 'BeforeCommit' event.
   Protected Overridable Sub OnBeforeCommit(savedState As IDictionary)
         RaiseEvent BeforeCommit(Me, New InstallEventArgs(savedState))
   End Sub

   ' Protected method that invoke the handlers associated with the 'AfterCommit' event.
   Protected Overridable Sub OnAfterCommit(savedState As IDictionary)
         RaiseEvent AfterCommit(Me, New InstallEventArgs())
   End Sub

   ' A simple event handler to exemplify the example.
   Private Sub BeforeCommitHandler(sender As Object, e As InstallEventArgs)
      Console.WriteLine("BeforeCommitHandler event handler has been called" + _
                                                      ControlChars.Newline)
      Console.WriteLine("The count of saved state objects are : {0}" + _
                                    ControlChars.Newline, e.SavedState.Count)
   End Sub

   ' A simple event handler to exemplify the example.
   Private Sub AfterCommitHandler(sender As Object, e As InstallEventArgs)
      Console.WriteLine("AfterCommitHandler event handler has been called" + _
                                                      ControlChars.Newline)
   End Sub
End Class