' System.Configuration.Install.Installer.OnBeforeInstall(IDictionary savedState)
' System.Configuration.Install.Installer.OnAfterInstall(IDictionary savedState)

' The following example demonstrates the methods 'OnBeforeInstall' and
' 'OnAfterInstall' of the 'Installer' class. The methods 'OnBeforeInstall'
' and 'OnAfterInstall' are overridden in the derived class. Space is provided
' to add steps to be done before the installation in 'OnBeforeInstall' method 
' and after the installation in 'OnAfterInstall' method.

' Use the installer process 'InstallUtil' to run the assembly 
' Installer_OnInstall.exe.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)>  _
Public Class MyInstaller
   Inherits Installer
   
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
   End Sub 'Uninstall
   
' <Snippet1>
   ' Override the 'OnBeforeInstall' method.
   Protected Overrides Sub OnBeforeInstall(savedState As IDictionary)
      MyBase.OnBeforeInstall(savedState)
      ' Add steps to be done before the installation starts.
      Console.WriteLine("OnBeforeInstall method of MyInstaller called")
   End Sub 'OnBeforeInstall
' </Snippet1>

' <Snippet2>
   ' Override the 'OnAfterInstall' method.
   Protected Overrides Sub OnAfterInstall(savedState As IDictionary)
      MyBase.OnAfterInstall(savedState)
      ' Add steps to be done after the installation is over.
      Console.WriteLine("OnAfterInstall method of MyInstaller called")
   End Sub 'OnAfterInstall
' </Snippet2>
End Class 'MyInstaller


Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use installutil.exe to run the assembly Installer_OnInstall.exe")
   End Sub 'Main
End Class 'MyAssembly