' System.Configuration.Install.Installer.AfterUninstall

' The following example demonstrates the event 'AfterUninstall' of the
' 'Installer' class. This event is raised by the method 'OnAfterUninstall'.

' Use the installer process 'InstallUtil -u' to run the assembly
' 'Installer_AfterUninstall.exe'.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)>  _
Public Class MyInstaller
   Inherits Installer

' <Snippet1>
   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler AfterUninstall, AddressOf AfterUninstallEventHandler
   End Sub 'New

   Private Sub AfterUninstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for AfterUninstallEventHandler")
   End Sub 'AfterUninstallEventHandler
' </Snippet1>

   ' Override the 'Install' method.
   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
   End Sub 'Install

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub 'Commit

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub 'Rollback

   ' Override the 'Uninstall' method.
   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("Uninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'Uninstall

   ' Override the 'OnBeforeUninstall' method.
   Protected Overrides Sub OnBeforeUninstall(savedState As IDictionary)
      MyBase.OnBeforeUninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnBeforeUninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'OnBeforeUninstall

   ' Override the 'OnAfterUninstall' method.
   Protected Overrides Sub OnAfterUninstall(savedState As IDictionary)
      MyBase.OnAfterUninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnAfterUninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'OnAfterUninstall
End Class 'MyInstaller

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use 'installutil.exe -u' to run the assembly " & _
                                            "Installer_AfterUninstall.exe")
   End Sub 'Main
End Class 'MyAssembly
