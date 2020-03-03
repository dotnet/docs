' System.Configuration.Install.Installer.Committed

' The following program demonstrates the 'Committed' event of the
' 'Installer' class.  When the 'Commit' is complete, 'Committed' event
' occurs and  a message is displayed.

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
      ' Attach the 'Committed' event.
      AddHandler Me.Committed, AddressOf MyInstaller_Committed
   End Sub

   ' Event handler for 'Committed' event.
   Private Sub MyInstaller_Committed(ByVal sender As Object, ByVal e As InstallEventArgs)
      Console.WriteLine("")
      Console.WriteLine("Committed Event occurred.")
      Console.WriteLine("")
   End Sub
' </Snippet1>
   ' Override the 'Install' method.
   Public Overrides Sub Install(ByVal savedState As IDictionary)
      MyBase.Install(savedState)
   End Sub

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(ByVal savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(ByVal savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub

   Public Shared Sub Main()
      Console.WriteLine("Usage : installutil.exe Installer_Committed.exe ")
   End Sub

End Class
