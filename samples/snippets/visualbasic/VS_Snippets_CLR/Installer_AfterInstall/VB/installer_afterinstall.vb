' System.Configuration.Install.Installer.AfterInstall

' The following example demonstrates the event 'AfterInstall' of the
' 'Installer' class. The event 'AfterInstall' is raised by the method
' 'OnAfterInstall'.

' Use the installer process 'InstallUtil' to run the assembly
' 'Installer_AfterInstall.exe'.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> _
Public Class MyInstaller
   Inherits Installer

' <Snippet1>
   ' MyInstaller is derived from the class 'Installer'.
   Sub New()
      MyBase.New()
      AddHandler AfterInstall, AddressOf AfterInstallEventHandler
   End Sub 'New

   Private Sub AfterInstallEventHandler(ByVal sender As Object, _
                                       ByVal e As InstallEventArgs)
      ' Add steps to perform any actions after the install process.
      Console.WriteLine("Code for AfterInstallEventHandler")
   End Sub 'AfterInstallEventHandler
' </Snippet1>

   ' Override the 'Install' method.
   Public Overrides Sub Install(ByVal savedState As IDictionary)
      MyBase.Install(savedState)
      Console.WriteLine("")
      Console.WriteLine("Install method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'Install

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(ByVal savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub 'Commit

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(ByVal savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub 'Rollback

   ' Override the 'Uninstall' method.
   Public Overrides Sub Uninstall(ByVal savedState As IDictionary)
      MyBase.Uninstall(savedState)
   End Sub 'Uninstall

   ' Override the 'OnBeforeInstall' method.
   Protected Overrides Sub OnBeforeInstall(ByVal savedState As IDictionary)
      MyBase.OnBeforeInstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnBeforeInstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'OnBeforeInstall

   ' Override the 'OnAfterInstall' method.
   Protected Overrides Sub OnAfterInstall(ByVal savedState As IDictionary)
      MyBase.OnAfterInstall(savedState)
   End Sub 'OnAfterInstall
End Class 'MyInstaller

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use installutil.exe to run the assembly" & _
                                             " Installer_AfterInstall.exe")
   End Sub 'Main
End Class 'MyAssembly
