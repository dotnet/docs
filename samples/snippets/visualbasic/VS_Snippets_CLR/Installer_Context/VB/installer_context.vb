' System.Configuration.Install.Installer.Context

' The following example demonstrates the 'Context' property of
' the 'Installer' class. The contents of the 'Context' property
' like information about the location of the log file for the
' installation, the location of the file to save information
' required by the Uninstall method, and the command line that
' was entered when the installation executable was run is
' displayed on the console.

' Use 'installutil' to run the assembly Installer_Context.exe

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections.Specialized

<RunInstaller(True)>  _
Public Class MyInstaller
   Inherits Installer

   ' Override the 'Install' method.
   Public Overrides Sub Install(mySavedState As IDictionary)
      MyBase.Install(mySavedState)
      Console.WriteLine("")
' <Snippet1>
      Dim myStringDictionary As StringDictionary = Context.Parameters
      If Context.Parameters.Count > 0 Then
         Console.WriteLine("Context Property : ")
         Dim myString As String
         For Each myString In  Context.Parameters.Keys
            Console.WriteLine(Context.Parameters(myString))
         Next myString
      End If
' </Snippet1>
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
End Class 'MyInstaller

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Run the assembly Installer_Context.exe using the" + _
                        " installer process 'installutil'")
   End Sub 'Main
End Class 'MyAssembly

