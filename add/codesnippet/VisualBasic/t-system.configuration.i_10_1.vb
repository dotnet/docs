Imports System
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Namespace MyInstallContextNamespace
   <RunInstallerAttribute(True)> Class InstallContext_Example
      Inherits Installer
      Public myInstallContext As InstallContext

      Public Overrides Sub Install(mySavedState As IDictionary)
         Dim myStringDictionary As StringDictionary = myInstallContext.Parameters
         If myStringDictionary.Count = 0 Then
            Console.WriteLine("No parameters have been entered in the command line" + _
                        "hence, the install will take place in the silent mode")
         Else
            ' Check wether the "LogtoConsole" parameter has been set.
            If myInstallContext.IsParameterTrue("LogtoConsole") = True Then
               ' Display the message to the console and add it to the logfile.
               myInstallContext.LogMessage("The 'Install' method has been called")
            End If
         End If
         ' The 'Install procedure should be added here.
      End Sub 'Install

      Public Overrides Sub Uninstall(mySavedState As IDictionary)
         ' The 'Uninstall' procedure should be added here.
      End Sub 'Uninstall

      Public Overrides Sub Rollback(mySavedState As IDictionary)
         If myInstallContext.IsParameterTrue("LogtoConsole") = True Then
            myInstallContext.LogMessage("The 'Rollback' method has been called")
         End If
         ' The 'Rollback' procedure should be added here.
      End Sub 'Rollback

      Public Overrides Sub Commit(mySavedState As IDictionary)
         If myInstallContext.IsParameterTrue("LogtoConsole") = True Then
            myInstallContext.LogMessage("The 'Commit' method has been called")
         End If
         ' The 'Commit' procedure should be added here.
      End Sub 'Commit

      ' Entry point which delegates to C-style main Private Function
      Public Overloads Shared Sub Main()
         Main(System.Environment.GetCommandLineArgs())
      End Sub

      Overloads Shared Sub Main(args() As String)
         Dim myInstallObject As New InstallContext_Example()
         Dim mySavedState = New Hashtable()

         If args.Length < 2 Then
            ' There are no command line arguments, create an empty 'InstallContext'.
            myInstallObject.myInstallContext = New InstallContext()
         ElseIf args.Length = 2 And args(1) = "/?" Then
               ' Display the 'Help' for this utility.
               Console.WriteLine("Specify the '/Logfile' and '/LogtoConsole' parameters")
               Console.WriteLine("Example: ")
               Console.WriteLine("InstallContext_InstallContext.exe /LogFile=example.log" + _
                                                         " /LogtoConsole=true")
               Return

         Else
            ' Create an InstallContext object with the given parameters.
            Dim commandLine() As String = New String(args.Length - 2) {}
            Dim i As Integer
            For i = 1 To args.Length - 1
               commandLine(i-1) = args(i)
            Next i
            myInstallObject.myInstallContext = _
               New InstallContext("/LogFile:example.log", commandLine)
         End If

         Try
            ' Call the 'Install' method.
            myInstallObject.Install(mySavedState)

            ' Call the 'Commit' method.
            myInstallObject.Commit(mySavedState)
         Catch
            ' Call the 'Rollback' method.
            myInstallObject.Rollback( mySavedState )
         End Try
      End Sub 'Main
   End Class 'InstallContext_Example
End Namespace 'MyInstallContextNamespace
