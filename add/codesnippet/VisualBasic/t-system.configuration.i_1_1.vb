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

   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
      Console.WriteLine("Commit ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException()
      End If
      ' Perform the final installation if the file exists.
   End Sub

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

   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("UnInstall ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException("The file 'FileDoesNotExist'" + " does not exist")
      End If
      ' Perform the uninstall activites if the file exists.
   End Sub

End Class

' An Assembly that has its own installer.
Public Class MyAssembly1
   Public Shared Sub Main()
      Console.WriteLine("This assembly is just an example for the Installer")
   End Sub
End Class