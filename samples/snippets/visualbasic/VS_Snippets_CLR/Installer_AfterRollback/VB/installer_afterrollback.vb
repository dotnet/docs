' System.Configuration.Install.Installer.AfterRollback

' The following program demonstrates the 'AfterRollback' event of the
' 'Installer' class. It overrides the Install method, explicitly throws
' arguement exception so that 'Rollback' method is called. When the
' 'RollBack' is complete, 'AfterRollback' event occurs and a message is
' displayed when the event occurs.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

' Set 'RunInstaller' attribute to true.
<RunInstaller(True)>  _
Public Class MyInstallerClass
   Inherits Installer

   Public Sub New()
       MyBase.New() 
      ' Attach the 'AfterRollback' event.
      AddHandler Me.AfterRollback, AddressOf MyInstaller_AfterRollBack
   End Sub 'New

   ' Event handler for 'AfterRollback' event.
   Private Sub MyInstaller_AfterRollBack(sender As Object, e As InstallEventArgs)
      Console.WriteLine("")
      Console.WriteLine("AfterRollBack Event occured.")
      Console.WriteLine("")
   End Sub 'MyInstaller_AfterRollBack

   ' Override the 'Install' method.
   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
      ' Explicitly throw an exception so that roll back is called.
      Throw New ArgumentException("Arg Exception")
   End Sub 'Install

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub 'Commit

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub 'Rollback

   Public Shared Sub Main()
      Console.WriteLine("Usage : installutil.exe Installer_AfterRollback.exe ")
   End Sub 'Main

End Class 'MyInstallerClass
' </Snippet1>

