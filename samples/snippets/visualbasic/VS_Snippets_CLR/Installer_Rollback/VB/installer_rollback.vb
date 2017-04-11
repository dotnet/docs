'   System.Configuration.Install.Installer.Rollback

'   The following example demonstrates the Rollback method
'   of the class 'installer'. The Rollback method is overridden
'   in a derived class of 'installer'. An exception is generated to
'   force an installation rollback.

Imports System
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections

Namespace MyAssembly
   <RunInstaller(True)> Public Class MyInstallerSample
      Inherits Installer

      ' Override 'Install' method of Installer class.
      Public Overrides Sub Install(mySavedState As IDictionary)
         MyBase.Install(mySavedState)
         Console.WriteLine("")
         ' Include code to install an application.
         Console.WriteLine("The Install method of 'MyInstallerSample'" + _
                                                      " has been called")
         Console.WriteLine("")

         ' Exception generated to call Rollback method.
         Dim myException As New Exception()
         Console.WriteLine("Exception thrown during Installation")
         Throw myException
      End Sub 'Install

' <Snippet1>
      ' Override 'Rollback' method of Installer class.
      Public Overrides Sub Rollback(mySavedState As IDictionary)
         MyBase.Rollback(mySavedState)
         Console.WriteLine("The Rollback method of 'MyInstallerSample'" + _
                                                      " has been called")
      End Sub 'Rollback
' </Snippet1>

      Shared Sub Main()
         Console.WriteLine("Use installutil.exe to run the assembly" + _
                                             " Installer_Rollback.exe")
      End Sub 'Main
   End Class 'MyInstallerSample
End Namespace 'MyAssembly