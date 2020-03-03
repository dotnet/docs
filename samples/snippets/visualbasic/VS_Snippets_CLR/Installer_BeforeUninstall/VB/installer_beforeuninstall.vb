' System.Configuration.Install.Installer.BeforeUninstall

' The following example demonstrates the event 'BeforeUninstall' of the
' 'Installer' class. This event is raised by the method 'OnBeforeUninstall'.

' Use the installer process 'InstallUtil -u' to run the assembly
' 'Installer_BeforeUninstall.exe'.

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
      AddHandler BeforeUninstall, AddressOf BeforeUninstallEventHandler
   End Sub

   Private Sub BeforeUninstallEventHandler(sender As Object, e As InstallEventArgs)
      ' Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for BeforeUninstallEventHandler")
   End Sub
' </Snippet1>

   ' Override the 'Install' method.
   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
   End Sub

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub

   ' Override the 'Uninstall' method.
   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("Uninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub

   ' Override the 'OnBeforeUninstall' method.
   Protected Overrides Sub OnBeforeUninstall(savedState As IDictionary)
      MyBase.OnBeforeUninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnBeforeUninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub

   ' Override the 'OnAfterUninstall' method.
   Protected Overrides Sub OnAfterUninstall(savedState As IDictionary)
      MyBase.OnAfterUninstall(savedState)
      Console.WriteLine("")
      Console.WriteLine("OnAfterUninstall method of MyInstaller called")
      Console.WriteLine("")
   End Sub
End Class

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use 'installutil.exe -u' to run the assembly "& _
                                          " Installer_BeforeUninstall.exe")
   End Sub
End Class
