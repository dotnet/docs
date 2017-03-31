' System.Configuration.Install.Installer.Installers
' System.Configuration.Install.Installer.Parent

' The following example demonstrates the properties 'Installers' and
' 'Parent'. The Installers property shows the InstallerCollection
' associated with an Installer and the Parent property gets the
' installer containing the collection that this installer belongs to.

Imports System
Imports System.Collections
Imports System.ServiceProcess
Imports System.Diagnostics
Imports System.Configuration.Install

Public Class Installer_Installers
   Public Shared Sub Main()
' <Snippet1>
      Dim myAssemblyInstaller As New AssemblyInstaller()
      Dim myServiceInstaller As New ServiceInstaller()
      Dim myEventLogInstaller As New EventLogInstaller()
      Dim myInstallerCollection As InstallerCollection = _
                                             myAssemblyInstaller.Installers

      ' Add Installers to the InstallerCollection of 'myAssemblyInstaller'.
      myInstallerCollection.Add(myServiceInstaller)
      myInstallerCollection.Add(myEventLogInstaller)

      Dim myInstaller(1) As Installer
      myInstallerCollection.CopyTo(myInstaller, 0)
      ' Show the contents of the InstallerCollection of 'myAssemblyInstaller'.
      Console.WriteLine("Installers in the InstallerCollection : ")
      Dim iIndex As Integer
      For iIndex = 0 To myInstaller.Length - 1
         Console.WriteLine(myInstaller(iIndex).ToString())
      Next iIndex
' </Snippet1>

      Console.WriteLine("")
' <Snippet2>
      Dim myAssemblyInstaller1 As New AssemblyInstaller()
      Dim myInstallerCollection1 As InstallerCollection = _
                                            myAssemblyInstaller1.Installers
      ' 'myAssemblyInstaller' is an installer of type 'AssemblyInstaller'.
      myInstallerCollection1.Add(myAssemblyInstaller)

      Dim myInstaller1 As Installer = myAssemblyInstaller.Parent
      Console.WriteLine("Parent of myAssembly : {0}", myInstaller1.ToString())
' </Snippet2>
End Sub 'Main
End Class 'Installer_Installers
