' System.Configuration.Install.Installer.BeforeInstall

' The following example demonstrates the event 'BeforeInstall' of the
' 'Installer' class. The event 'BeforeInstall' is raised by the method
' 'OnBeforeInstall'.

' Use the installer process 'InstallUtil' to run the assembly
' Installer_BeforeInstall.exe.

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
      AddHandler BeforeInstall, AddressOf BeforeInstallEventHandler
   End Sub 'New

   Private Sub BeforeInstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the install process.
      Console.WriteLine("Code for BeforeInstallEventHandler")
   End Sub 'BeforeInstallEventHandler
' </Snippet1>

   ' Override the 'Install' method.
   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
      Console.WriteLine("")
      Console.WriteLine("Install method of MyInstaller called")
      Console.WriteLine("")
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
   End Sub 'Uninstall

   ' Override the 'OnBeforeInstall' method.
   Protected Overrides Sub OnBeforeInstall(savedState As IDictionary)
      MyBase.OnBeforeInstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnBeforeInstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'OnBeforeInstall

   ' Override the 'OnAfterInstall' method.
   Protected Overrides Sub OnAfterInstall(savedState As IDictionary)
      MyBase.OnAfterInstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnAfterInstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub 'OnAfterInstall
End Class 'MyInstaller

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use installutil.exe to run the assembly " &  _
                                                        "Installer_BeforeInstall.exe")
   End Sub 'Main
End Class 'MyAssembly
