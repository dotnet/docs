' System.Configuration.Install.InstallerCollection.Item(Int32)

' The following example demonstrates the 'CopyTo(Installer[], Int32)' method
' of the 'InstallerCollection' class. It Creates 'AssemblyInstaller' instances
' for 'MyAssembly1.exe' and 'MyAssembly2.exe'. These instances are added to an 
' instance of 'TransactedInstaller' instance. The names of the assemblies to be 
' installed are displayed on the console. The installation process then installs 
' both 'MyAssembly1.exe' and 'MyAssembly2.exe'.

Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO
Imports Microsoft.VisualBasic

Public Class InstallerCollection_Item
   
   Public Shared Sub Main()
      Try
' <Snippet1>
         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Add(myAssemblyInstaller)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.  
         myTransactedInstaller.Installers.Add(myAssemblyInstaller)
         
         'Print the assemblies to be installed.
         Dim myInstallers As InstallerCollection = myTransactedInstaller.Installers
         Console.WriteLine(ControlChars.Newline + "Printing all assemblies to be installed")
         Dim i As Integer
         For i = 0 To myInstallers.Count - 1
            If myInstallers(i).GetType().Equals(GetType(AssemblyInstaller)) Then
               Console.WriteLine("{0} {1}", i + 1, CType(myInstallers(i), AssemblyInstaller).Path)
            End If
         Next i
' </Snippet1>
         ' Create a instance of 'InstallContext' with log file named 'Install.log'.
         myInstallContext = New InstallContext("Install.log", Nothing)
         myTransactedInstaller.Context = myInstallContext
         
         ' Install an assembly .
         myTransactedInstaller.Install(New Hashtable())
      Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'InstallerCollection_Item