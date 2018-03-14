' System.Configuration.Install.UninstallAction
' System.Configuration.Install.UninstallAction.NoAction
' System.Configuration.Install.UninstallAction.Remove

' The following program demonstrates "NoAction" and "Remove"
' members of "UninstallAction" enumeration. A resource is
' installed and uninstalled using 'installutil.exe' in an event
' log depending on the user input.

' <Snippet1>
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)>  _
Public Class MyUninstallActionClass
   Inherits Installer
   Private myInstaller As New EventLogInstaller()

   ' Override the 'Install' method.
   Public Overrides Sub Install(savedState As IDictionary)
      Console.Write("Enter a new log to create (eg: MyLog ): ")
      myInstaller.Log = Console.ReadLine()
      Console.Write("Enter a source for log (eg: MySource ): ")
      myInstaller.Source = Console.ReadLine()
      Installers.Add(myInstaller)
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

' <Snippet3>
' <Snippet2>
   Public Overrides Sub Uninstall(savedState As IDictionary)

      Console.Write("Enter a source from log to uninstall(eg: MySource ): ")
      myInstaller.Source = Console.ReadLine()

      Console.Write("Do you want to uninstall, press 'y' for 'YES' and 'n' for 'NO':")
      Dim myUninstall As String = Console.ReadLine()

      If myUninstall = "n" Then
         ' No action to be taken on the resource in the event log.
         myInstaller.UninstallAction = System.Configuration.Install.UninstallAction.NoAction
      Else
         ' Remove the resource from the event log.
         myInstaller.UninstallAction = System.Configuration.Install.UninstallAction.Remove
      End If
      Installers.Add(myInstaller)
      MyBase.Uninstall(savedState)
   End Sub 'Uninstall
' </Snippet2>
' </Snippet3>

   Public Shared Sub Main()
      Console.WriteLine("Syntax for install: installutil.exe "+ _
                        "UninstallAction_NoAction_Remove_3.exe ")
      Console.WriteLine("Syntax for uninstall: installutil.exe /u " + _
                        "UninstallAction_NoAction_Remove_3.exe ")
   End Sub 'Main

End Class 'MyUninstallActionClass
' </Snippet1>



