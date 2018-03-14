'   System.Configuration.Install.Installer.Install
'   System.Configuration.Install.Installer.Commit

'   The following example demonstrates the 'Install' and 'Commit' methods 
'   of the 'Installer' class.
'   A class is derived from the 'Installer' base class and the Install
'   and Commit methods are overridden.

Imports System
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections

Namespace MyAssembly
   <RunInstaller(True)> Public Class MyInstallerSample
      Inherits Installer

' <Snippet1>
      ' Override the 'Install' method of the Installer class.
      Public Overrides Sub Install(mySavedState As IDictionary)
         MyBase.Install(mySavedState)
         ' Code maybe written for installation of an application.
         Console.WriteLine("The Install method of 'MyInstallerSample' has been called")
      End Sub 'Install
' </Snippet1>

' <Snippet2>
      ' Override the 'Commit' method of the Installer class.
      Public Overrides Sub Commit(mySavedState As IDictionary)
         MyBase.Commit(mySavedState)
         Console.WriteLine("The Commit method of 'MyInstallerSample'" + _
                                                      "has been called")
      End Sub 'Commit
' </Snippet2>

      Shared Sub Main()
         Console.WriteLine("Use installutil.exe to run the assembly" + _
                                             " Installer_Install.exe")
      End Sub 'Main
   End Class 'MyInstallerSample
End Namespace 'MyAssembly