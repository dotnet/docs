' System.Configuration.Install.Installer.HelpText

' The following example demonstrates the property 'HelpText'. The
' 'HelpText' property is defined in the 'Installer', which when called
' returns the description of the 'Installer' and the command line
' options for the installation executable, such as the InstallUtil.exe
' utility, that can be passed to and understood by the 'Installer'.

' Use 'installutil' to run the assembly Installer_HelpText.exe.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install
Imports Microsoft.VisualBasic

<RunInstaller(True)> _
Public Class MyInstaller
   Inherits Installer

   ' Override the 'Install' method.
   Public Overrides Sub Install(ByVal savedState As IDictionary)
      MyBase.Install(savedState)
      Dim myHelpText As String = HelpText
      Console.WriteLine("Help Text : ")
      Console.WriteLine(myHelpText)
   End Sub 'Install

   ' Override the 'Commit' method.
   Public Overrides Sub Commit(ByVal savedState As IDictionary)
      MyBase.Commit(savedState)
   End Sub 'Commit

   ' Override the 'Rollback' method.
   Public Overrides Sub Rollback(ByVal savedState As IDictionary)
      MyBase.Rollback(savedState)
   End Sub 'Rollback

   ' Override the 'Uninstall' method.
   Public Overrides Sub Uninstall(ByVal savedState As IDictionary)
      MyBase.Uninstall(savedState)
   End Sub 'Uninstall

' <Snippet1>
   ' Override the property 'HelpText'.
   Public Overrides ReadOnly Property HelpText() As String
      Get
         Return _
         "Installer Description : This is a sample Installer" + ControlChars.NewLine + _
         "HelpText is used to provide useful information about the installer."
      End Get
   End Property
' </Snippet1>

End Class 'MyInstaller

Public Class MyAssembly
   Public Shared Sub Main()
      Console.WriteLine("Use installutil.exe to run the assembly Installer_HelpText.exe")
   End Sub 'Main
End Class 'MyAssembly
