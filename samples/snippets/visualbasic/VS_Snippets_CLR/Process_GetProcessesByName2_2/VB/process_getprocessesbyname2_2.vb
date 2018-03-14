' System.Diagnostics.Process.GetProcessesByName(String, String)
' System.Diagnostics.Process.MachineName

' The following program demonstrates the method 'GetProcessesByName(String,
' String)' and property 'MachineName' of class 'Process'.
' It reads the remote computer name from commandline and gets all the notepad
' processes by name on remote computer and displays its properties to console.
' <Snippet1>
' <Snippet2>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Class GetProcessesByNameClass

   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub

   Public Overloads Shared Sub Main(ByVal args() As String)
      Try

         Console.Writeline("Create notepad processes on remote computer")
         Console.Write("Enter remote computer name : ")
         Dim remoteMachineName As String = Console.ReadLine()
         ' Get all notepad processess into Process array.
         Dim myProcesses As Process() = Process.GetProcessesByName _
                                             ("notepad", remoteMachineName)
         If myProcesses.Length = 0 Then
            Console.WriteLine("Could not find notepad processes on remote computer.")
         End If
         Dim myProcess As Process
         For Each myProcess In myProcesses
            Console.WriteLine("Process Name : " & myProcess.ProcessName & _
                          "  Process ID : " & myProcess.Id & _
                          "  MachineName : " & myProcess.MachineName)
         Next myProcess

      Catch e As SystemException
         Console.Write("Caught Exception .... : " & e.Message)
      Catch e As Exception
         Console.Write("Caught Exception .... : " & e.Message)
      End Try
   End Sub 'Main
End Class 'GetProcessesByNameClass
' </Snippet1>
' </Snippet2>