' System.Configuration.Install.Installer.OnCommitting(Idictionary savedState)
' System.Configuration.Install.Installer.OnCommitted(Idictionary savedState)

' The following example demonstrates the methods 'OnCommitting' and
' 'OnCommitted' of the 'Installer' class. The methods 'OnCommitting' and
' 'OnCommitted' are overridden in the derived class. Space is provided
' for the user to add the steps to be performed before committing and
' after committing.

' 'Installer_Committed.exe' needs to be run using the installer process 
' 'installutil'. 

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
   
' <Snippet1>
   ' Override the 'OnCommitting' method.
   Protected Overrides Sub OnCommitting(savedState As IDictionary)
      MyBase.OnCommitting(savedState)
      ' Add steps to be done before committing an application.
      Console.WriteLine("The OnCommitting method of MyInstaller called")
   End Sub 'OnCommitting
   
' </Snippet1>
' <Snippet2>
   ' Override the 'OnCommitted' method.
   Protected Overrides Sub OnCommitted(savedState As IDictionary)
      MyBase.OnCommitted(savedState)
      ' Add steps to be done after committing an application.
      Console.WriteLine("The OnCommitted method of MyInstaller called")
   End Sub 'OnCommitted
' </Snippet2>
End Class 'MyInstaller


Public Class MyAssembly
   
   Public Shared Sub Main()
      Console.WriteLine("Use installutil.exe to run the assembly Installer_Committed.exe")
   End Sub 'Main
End Class 'MyAssembly
