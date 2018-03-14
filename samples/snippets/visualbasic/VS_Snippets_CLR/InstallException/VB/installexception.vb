' System.Configuration.Install.InstallException
' System.Configuration.Install.InstallException.InstallException()
' System.Configuration.Install.InstallException.InstallException(String, Exception)
' System.Configuration.Install.InstallException.InstallException(String)

' The following example demonstrates the 'InstallException()', 'InstallException(String)'
' and 'InstallException(String, Exception)' constructors for 'InstallException' class.
' This example shows an assembly having its own installer named 'MyInstaller'
' which has an attribute 'RunInstallerAttribute', indicating that this installer
' will be invoked by InstallUtil.exe. InstallUtil.exe calls the 'Install', 'Commit',
' 'Rollback' and 'Uninstall' methods. The code in 'Commit' method presumes that 
' a file named 'FileDoesNotExist.txt' exists before the installation of the 
' assembly can be committed. If the file 'FileDoesNotExist.txt' does not exist
' 'Commit' raises a 'InstallException'. Same is the case with 'Uninstall', 
' uninstalltion will only progress if the file named 'FileDoesNotExist.txt' 
' exists else it raises an 'InstallException'. In 'Rollback' some piece of
' code is executed which may raise an exception. If the exception is raised then
' it is caught and an 'InstallException' is raised with that exception being passed
' to it.

' Note : Run this example with the help of 'InstallUtil.exe'
'       InstallUtil InstallException.exe
'       InstallUtil /u InstallException.exe 

' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO

<RunInstaller(True)> Public Class MyInstaller
   Inherits Installer

   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
      Console.WriteLine("Install ...")

     ' Commit is called when install goes through successfully.
     ' Rollback is called if there is any error during Install.
     ' Uncommenting the code below will lead to 'RollBack' being called,
     ' currently 'Commit' shall be called.
     ' throw new IOException();

   End Sub

' <Snippet2>
   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
      Console.WriteLine("Commit ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException()
      End If
      ' Perform the final installation if the file exists.
   End Sub
' </Snippet2>

' <Snippet3>
   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
      Console.WriteLine("RollBack ...")
      Try
         ' Performing some activity during rollback that raises an 'IOException'.
         Throw New IOException()
      Catch e As Exception
         Throw New InstallException("IOException raised", e)
      End Try
   End Sub 'Rollback
    ' Perform the remaining rollback activites if no exception raised.
' </Snippet3>

' <Snippet4>
   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("UnInstall ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException("The file 'FileDoesNotExist'" + " does not exist")
      End If
      ' Perform the uninstall activites if the file exists.
   End Sub
' </Snippet4>

End Class

' An Assembly that has its own installer.
Public Class MyAssembly1
   Public Shared Sub Main()
      Console.WriteLine("This assembly is just an example for the Installer")
   End Sub
End Class
' </Snippet1>