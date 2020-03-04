' This program is supposed to be used with the IntallerCollection_***.cs
' examples. Provide the exe of this program as input to the 
' InstallerCollection_***.exe programs.

Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> _
Public Class MyInstaller
   Inherits Installer
   
   Public Overrides Sub Install(savedState As IDictionary)
      MyBase.Install(savedState)
      Console.WriteLine("Install ..." + ControlChars.Newline)
   End Sub
   
   
   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
      Console.WriteLine("Committing ..." + ControlChars.Newline)
   End Sub
   
   
   Public Overrides Sub Rollback(savedState As IDictionary)
      MyBase.Rollback(savedState)
      Console.WriteLine("RollBack ..." + ControlChars.Newline)
   End Sub
   
   
   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("UnInstall ..." + ControlChars.Newline)
   End Sub
End Class

' An Assembly that has its own installer.
Public Class MyAssembly1
   
   Public Shared Sub Main()
      Console.WriteLine("This assembly is just an example for the Installer" + ControlChars.Newline)
   End Sub
End Class


