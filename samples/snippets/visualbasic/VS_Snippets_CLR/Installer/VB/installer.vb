' System.Configuration.Install.Installer

' The following program demonstrates the use of the 'Installer'
' class. It creates a class which inherits from 'Installer'.
' When the 'Commit' is about to complete, 'Committing' event
' occurs and a message is displayed when the event occurs.

' <Snippet1>
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

' Set 'RunInstaller' attribute to true.
<RunInstaller(True)> _
Public Class MyInstallerClass
   Inherits Installer

   Public Sub New()
       MyBase.New()
      ' Attach the 'Committed' event.
      AddHandler Me.Committed, AddressOf MyInstaller_Committed
      ' Attach the 'Committing' event.
      AddHandler Me.Committing, AddressOf MyInstaller_Committing
   End Sub

   ' Event handler for 'Committing' event.
   Private Sub MyInstaller_Committing(ByVal sender As Object, _
                                      ByVal e As InstallEventArgs)
      Console.WriteLine("")
      Console.WriteLine("Committing Event occurred.")
      Console.WriteLine("")
   End Sub

   ' Event handler for 'Committed' event.
   Private Sub MyInstaller_Committed(ByVal sender As Object, _
                                     ByVal e As InstallEventArgs)
      Console.WriteLine("")
      Console.WriteLine("Committed Event occurred.")
      Console.WriteLine("")
   End Sub

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
      Console.WriteLine("Usage : installutil.exe Installer.exe ")
   End Sub
End Class
' </Snippet1>


