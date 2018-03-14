' System.Configuration.Install.InstallerCollection.Insert(Int32, Installer)
' System.Configuration.Install.InstallerCollection.AddRange(InstallerCollection)

' The following example demonstrates the 'Insert(Int32, Installer)' and
' 'AddRange(InstallerCollection)' methods of the 'InstallerCollection' 
' class. It Creates 'AssemblyInstaller' instances for 'MyAssembly1.exe' 
' and 'MyAssembly2.exe'. These instances are added to an instance of 
' 'TransactedInstaller' named 'myTransactedInstaller1'.
' The installers in the 'myTransactedInstaller1' are copied to another
' instance of 'TransactedInstaller' named 'myTransactedInstaller2'.The 
' installation process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO
Imports Microsoft.VisualBasic

Public Class InstallerCollection_Insert
   
   Public Shared Sub Main()
' <Snippet1>
' <Snippet2>
      Dim myTransactedInstaller1 As New TransactedInstaller()
      Dim myTransactedInstaller2 As New TransactedInstaller()
      Dim myAssemblyInstaller As New AssemblyInstaller()
      Dim myInstallContext As InstallContext
      
      ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
      
      ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(0, myAssemblyInstaller)
      
      ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
      
      ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(1, myAssemblyInstaller)
      
      ' Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
      myTransactedInstaller2.Installers.AddRange(myTransactedInstaller1.Installers)
      
' </Snippet2>
' </Snippet1>
      ' Create a instance of 'InstallContext' with log file named 'Install.log'.
      myInstallContext = New InstallContext("Install.log", Nothing)
      myTransactedInstaller2.Context = myInstallContext
      
      ' Install an assembly.
      myTransactedInstaller2.Install(New Hashtable())
   End Sub 'Main
End Class 'InstallerCollection_Insert