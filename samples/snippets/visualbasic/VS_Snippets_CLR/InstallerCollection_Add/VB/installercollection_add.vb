' System.Configuration.Install.InstallerCollection
' System.Configuration.Install.InstallerCollection.Add(Installer)

' The following example demonstrates the Add(Installer)
' method of the 'InstallerCollection' class. This example provides
' an implementation similar to that of 'InstallUtil.exe'. It installs
' assemblies with the options preceding that particular assembly.
' If an option is not specified for an assembly the previous assemblies
' options are taken if there is a previous assembly in the list. If the
' '/u' or '/uninstall' option is specified then the assemblies are uninstalled.
' If the '/?' or '/help' option is provided then the help information is
' displayed to the console.

' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Configuration.Install
Imports System.IO

Public Class InstallerCollection_Add
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Public Shared Sub Main(args() As String)
      Dim options As New ArrayList()
      Dim myOption As String
      Dim toUnInstall As Boolean = False
      Dim toPrintHelp As Boolean = False
      Dim myTransactedInstaller As New TransactedInstaller()
      Dim myAssemblyInstaller As AssemblyInstaller
      Dim myInstallContext As InstallContext
      
      Try
         Dim i As Integer
         For i = 1 To args.Length - 1
            ' Process the arguments.
            If args(i).StartsWith("/") Or args(i).StartsWith("-") Then
               myOption = args(i).Substring(1)
               ' Determine whether the option is to 'uninstall' a assembly.
               If String.Compare(myOption, "u", True) = 0 Or String.Compare(myOption, "uninstall", _
                                                                              True) = 0 Then
                  toUnInstall = True
                  GoTo ContinueFor1
               End If
               ' Determine whether the option is for printing help information.
               If String.Compare(myOption, "?", True) = 0 Or String.Compare(myOption, "help", _
                                                                                 True) = 0 Then
                  toPrintHelp = True
                  GoTo ContinueFor1
               End If
               ' Add the option encountered to the list of all options
               ' encountered for the current assembly.
               options.Add(myOption)
            Else
               ' Determine whether the assembly file exists.
               If Not File.Exists(args(i)) Then
                  ' If assembly file doesn't exist then print error.
                  Console.WriteLine(" Error : {0} - Assembly file doesn't exist.", args(i))
                  Return
               End If
' <Snippet2>
               ' Create an instance of 'AssemblyInstaller' that installs the given assembly.
               myAssemblyInstaller = New AssemblyInstaller(args(i), CType(options.ToArray _
                                                               (GetType(String)), String()))
               ' Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
               myTransactedInstaller.Installers.Add(myAssemblyInstaller)
' </Snippet2>
            End If
         ContinueFor1: 
         Next i
         ' If user requested help or didn't provide any assemblies to install
         ' then print help message.
         If toPrintHelp Or myTransactedInstaller.Installers.Count = 0 Then
            PrintHelpMessage()
            Return
         End If
         
         ' Create an instance of 'InstallContext' with the options specified.
         myInstallContext = New InstallContext("Install.log", CType(options.ToArray _
                                                               (GetType(String)), String()))
         myTransactedInstaller.Context = myInstallContext
         
         ' Install or Uninstall an assembly depending on the option provided.
         If Not toUnInstall Then
            myTransactedInstaller.Install(New Hashtable())
         Else
            myTransactedInstaller.Uninstall(Nothing)
         End If
      Catch e As Exception
         Console.WriteLine(" Exception raised : {0}", e.Message)
      End Try
   End Sub 'Main

   Public Shared Sub PrintHelpMessage()
      Console.WriteLine("Usage : InstallerCollection_Add [/u | /uninstall] [option [...]]assembly"+ _
                                                               "[[option [...]] assembly] [...]]")
      Console.WriteLine("InstallerCollection_Add executes the installers in each of" + _
      " the given assembly. If /u or /uninstall option is given it uninstalls the assemblies.")
   End Sub 'PrintHelpMessage
End Class 'InstallerCollection_Add
' </Snippet1>