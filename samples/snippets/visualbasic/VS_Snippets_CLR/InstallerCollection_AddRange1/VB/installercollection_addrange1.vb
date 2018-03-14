' System.Configuration.Install.InstallerCollection.AddRange(Installer[])

' The following example demonstrates the 'AddRange(Installer[])'
' method of the 'InstallerCollection' class. Its Creates 'AssemblyInstaller' 
' instances for 'MyAssembly1.exe' and for 'MyAssembly2.exe'. These 
' instances are added to an instance of 'TransactedInstaller'. The installation 
' process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.

Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO

Public Class InstallerCollection_AddRange1
   
   Public Shared Sub Main()
      Try
' <Snippet1>
         Dim myInstallers As New ArrayList()
         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller)
         
         ' Add the installers to the 'TransactedInstaller' instance.
         myTransactedInstaller.Installers.AddRange(CType(myInstallers.ToArray(GetType(Installer)), _
                                                                              Installer()))
' </Snippet1>
         ' Create a instance of 'InstallContext' with log file named 'Install.log'.
         myInstallContext = New InstallContext("Install.log", Nothing)
         myTransactedInstaller.Context = myInstallContext
         
         ' Install an assembly.
         myTransactedInstaller.Install(New Hashtable())
      Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'InstallerCollection_AddRange1