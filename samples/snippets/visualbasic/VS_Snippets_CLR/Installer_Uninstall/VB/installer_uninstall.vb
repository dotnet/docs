'   System.Configuration.Install.Installer.Uninstall

'   The following example demonstrates the Uninstall method 
'   of the class 'installer'. The method Uninstall is overridden
'   in the derived class of 'installer'.

Imports System
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections

Namespace MyAssembly
   <RunInstaller(True)> Public Class MyInstallerSample
      Inherits Installer

' <Snippet1>
      ' Override 'Uninstall' method of Installer class.
      Public Overrides Sub Uninstall(mySavedState As IDictionary)
         If mySavedState Is Nothing Then
            Console.WriteLine("Uninstallation Error !")
         Else
            MyBase.Uninstall(mySavedState)
            Console.WriteLine("The Uninstall method of 'MyInstallerSample' has been called")
         End If
      End Sub 'Uninstall
' </Snippet1>

      Shared Sub Main()
         Console.WriteLine("Use 'installutil.exe -u' to run the assembly" + _
                                                " Installer_Uninstall.exe")
      End Sub 'Main
   End Class 'MyInstallerSample
End Namespace 'MyAssembly