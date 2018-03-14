' System.Configuration.Install.Installer.Committing

' The following program demonstrates the 'Committing' event of the
' 'Installer' class.  When the 'Commit' is about to complete,
' 'Committing' event is fired and a message is displayed.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

' Set 'RunInstaller' attribute to true.
<RunInstaller(True)> _
Public Class MyInstallerClass
   Inherits Installer
' <Snippet1>
   Public Sub New()
      MyBase.New()
      ' Attach the 'Committing' event.
      AddHandler Me.Committing, AddressOf MyInstaller_Committing
   End Sub 'New

   ' Event handler for 'Committing' event.
   Private Sub MyInstaller_Committing(ByVal sender As Object, _
                                      ByVal e As InstallEventArgs)
      Console.WriteLine("Committing Event occured.")
   End Sub 'MyInstaller_Committing
' </Snippet1>

   ' Override the 'Install' method.
   Public Overrides Sub Install(ByVal savedState As IDictionary)
      MyBase.Install(savedState)
   End Sub 'Install

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(ByVal savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub 'Commit

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(ByVal savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub 'Rollback

   Public Shared Sub Main()
      Console.WriteLine("Usage : installutil.exe Installer_Committing.exe ")
   End Sub 'Main

End Class 'MyInstallerClass

