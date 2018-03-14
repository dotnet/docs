' System.Configuration.Install.InstallEventArgs
' System.Configuration.Install.InstallEventArgs.InstallEventArgs()
' System.Configuration.Install.InstallEventArgs.InstallEventArgs(IDictionary)
' System.Configuration.Install.InstallEventArgs.SavedState

' The following example demonstrates the 'InstallEventArgs()' and 
' 'InstallEventArgs(IDictionary)' constructors and the 'SavedState'
' property of the 'InstallEventArgs' property. There are two new
' events called 'BeforeCommit' and 'AfterCommit'. The handlers of
' these events are invoked from the protected methods named 'OnBeforeCommit'
' and 'OnAfterCommit' respectively. These events are raised when the 
' 'Commit' method is called.

' Note : 
' a) The two events named 'BeforeCommit' and 'AfterCommit' are added 
' only for example purposes, since there are already
' events named 'Committing' and 'Committed' which perform the same
' function. This example can be made a basis for a new stage being
' added to the already existing four stages namely 'Install', 'Commit',
' 'Rollback' and 'Uninstall'.

' b) Run the example with the help of InstallUtil.exe
'    InstallUtil InstallEventArgs.exe

' <Snippet1>
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

' <Snippet3>
   ' Protected method that invoke the handlers associated with the 'BeforeCommit' event.
   Protected Overridable Sub OnBeforeCommit(savedState As IDictionary)
         RaiseEvent BeforeCommit(Me, New InstallEventArgs(savedState))
   End Sub
' </Snippet3>

' <Snippet2>
   ' Protected method that invoke the handlers associated with the 'AfterCommit' event.
   Protected Overridable Sub OnAfterCommit(savedState As IDictionary)
         RaiseEvent AfterCommit(Me, New InstallEventArgs())
   End Sub
' </Snippet2>

' <Snippet4>
   ' A simple event handler to exemplify the example.
   Private Sub BeforeCommitHandler(sender As Object, e As InstallEventArgs)
      Console.WriteLine("BeforeCommitHandler event handler has been called" + _
                                                      ControlChars.Newline)
      Console.WriteLine("The count of saved state objects are : {0}" + _
                                    ControlChars.Newline, e.SavedState.Count)
   End Sub
' </Snippet4>

   ' A simple event handler to exemplify the example.
   Private Sub AfterCommitHandler(sender As Object, e As InstallEventArgs)
      Console.WriteLine("AfterCommitHandler event handler has been called" + _
                                                      ControlChars.Newline)
   End Sub
End Class
' </Snippet1>

' An Assembly that has its own installer.
Public Class MyAssembly1
   Public Shared Sub Main()
      Console.WriteLine("This assembly is just an example for the Installer" + _
                                                   ControlChars.Newline)
   End Sub
End Class
