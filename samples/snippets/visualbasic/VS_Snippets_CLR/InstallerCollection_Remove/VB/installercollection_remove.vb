' System.Configuration.Install.InstallerCollection.Remove(Installer)
' System.Configuration.Install.InstallerCollection.Contains(Installer)
' System.Configuration.Install.InstallerCollection.IndexOf(Installer)

' The following example demonstrates the 'Remove(Installer)',
' 'Contains(Installer)' and 'IndexOf(Installer)' methods of the 
' 'InstallerCollection' class. It Creates 'AssemblyInstaller' instances
' for 'MyAssembly1.exe' and 'MyAssembly2.exe'. These instances
' of 'AssemblyInstaller' are added to an instance of 'TransactedInstaller'.
' The 'AssemblyIntaller' instance for 'MyAssembly2.exe' is removed
' from the installers collection of the 'TransactedInstaller' instance.
' The installation process is started which installs only 'MyAssembly1.exe'.

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO
Imports Microsoft.VisualBasic

Public Class InstallerCollection_Remove
   Public Shared Sub Main()
      Try
' <Snippet1>
' <Snippet2>
' <Snippet3>
         Dim myTransactedInstaller As New TransactedInstaller()
         Dim myAssemblyInstaller1 As AssemblyInstaller
         Dim myAssemblyInstaller2 As AssemblyInstaller
         Dim myInstallContext As InstallContext
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller1 = New AssemblyInstaller("MyAssembly1.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(0, myAssemblyInstaller1)
         
         ' Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller2 = New AssemblyInstaller("MyAssembly2.exe", Nothing)
         
         ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(1, myAssemblyInstaller2)
         
         ' Remove the 'myAssemblyInstaller2' from the 'Installers' collection.
         If myTransactedInstaller.Installers.Contains(myAssemblyInstaller2) Then
            Console.WriteLine(ControlChars.Newline + "Installer at index : {0} is being removed", _
                              myTransactedInstaller.Installers.IndexOf(myAssemblyInstaller2))
            myTransactedInstaller.Installers.Remove(myAssemblyInstaller2)
         End If
' </Snippet3>
' </Snippet2>
' </Snippet1>
         'Print the installers to be installed.
         Dim myInstallers As InstallerCollection = myTransactedInstaller.Installers
         Console.WriteLine(ControlChars.Newline + "Printing all installers to be installed" + _
                                                      ControlChars.Newline)
         Dim i As Integer
         For i = 0 To myInstallers.Count - 1
            If myInstallers(i).GetType().Equals(GetType(AssemblyInstaller)) Then
               Console.WriteLine("{0} {1}", i + 1, CType(myInstallers(i), AssemblyInstaller).Path)
            End If
         Next i
         
         ' Create a instance of 'InstallContext' with log file named 'Install.log'.
         myInstallContext = New InstallContext("Install.log", Nothing)
         myTransactedInstaller.Context = myInstallContext
         
         ' Install an assembly.
         myTransactedInstaller.Install(New Hashtable())
      Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'InstallerCollection_Remove