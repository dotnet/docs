' System.Diagnostics.Process.StandardError
'
' The following example demonstrates property 'StandardError' of
' 'Process' class.

' It starts a process(net.exe) which writes an error message on to the standard
' error when a bad network path is given.This program gets 'StandardError' of
' net.exe process and reads output from its stream reader.*/

Imports System
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic

Namespace Process_StandardError

   Class Class1

      ' Entry point which delegates to C-style main Private Function
      Public Overloads Shared Sub Main()
         Main(System.Environment.GetCommandLineArgs())
      End Sub

      Overloads Shared Sub Main(args() As String)
         If args.Length < 2 Then
            Console.WriteLine(ControlChars.Newline + _
            "This requires a machine name as a parameter which is not on the network.")
            Console.WriteLine(ControlChars.Newline + "Usage:")
            Console.WriteLine("Process_StandardError <\\machine name>")
         Else
            GetStandardError(args)
         End If
         Return
      End Sub 'Main

      Public Shared Sub GetStandardError(args() As String)
         Try
' <Snippet1>
            Dim myProcess As New Process()
            Dim myProcessStartInfo As New ProcessStartInfo("net ", "use " + args(1))

            myProcessStartInfo.UseShellExecute = False
            myProcessStartInfo.RedirectStandardError = True
            myProcess.StartInfo = myProcessStartInfo
            myProcess.Start()

            Dim myStreamReader As StreamReader = myProcess.StandardError
            ' Read the standard error of net.exe and write it on to console.
            Console.WriteLine(myStreamReader.ReadLine())
            myProcess.Close()
' </Snippet1>
         Catch e As Win32Exception
            Console.WriteLine(e.Message)
         Catch e As SystemException
            Console.WriteLine(e.Message)
         Catch e As Exception
            Console.WriteLine(e.Message)
         End Try
      End Sub 'GetStandardError
   End Class 'Class1
End Namespace 'Process_StandardError