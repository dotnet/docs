' System.Diagnostics.Process.GetProcessesByName(String, String)
' System.Diagnostics.Process.MachineName

' The following program demonstrates the method 'GetProcessesByName(String,
' String)' and property 'MachineName' of class 'Process'.
' It reads the remote computer name from commandline and gets all the notepad
' processes by name on remote computer and displays its properties to console.
' <Snippet1>
' <Snippet2>
Imports System.Diagnostics

Class GetProcessesByNameClass

    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(Environment.GetCommandLineArgs())
    End Sub

    Public Overloads Shared Sub Main(ByVal args() As String)
        Console.WriteLine("Create notepad processes on remote computer")
        Console.Write("Enter remote computer name : ")
        Dim remoteMachineName As String = Console.ReadLine()

        If remoteMachineName Is Nothing Then
            ' Prepend a new line to prevent it from being on the same line as the prompt.
            Console.WriteLine(Environment.NewLine + "You have to enter a remote computer name.")
            Return
        End If

        Try
            ' Get all notepad processess into Process array.
            Dim myProcesses As Process() = Process.GetProcessesByName _
                                                ("notepad", remoteMachineName)
            If myProcesses.Length = 0 Then
                Console.WriteLine("Could not find notepad processes on remote computer.")
            End If
            Dim myProcess As Process
            For Each myProcess In myProcesses
                Console.WriteLine("Process Name : " & myProcess.ProcessName &
                            "  Process ID : " & myProcess.Id &
                            "  MachineName : " & myProcess.MachineName)
            Next myProcess
        Catch e As ArgumentException
            Console.WriteLine("The value '" & remoteMachineName & "' is an invalid remote computer name.")
        Catch e As PlatformNotSupportedException
            Console.WriteLine(
                "Finding notepad processes on remote computers " &
                "is not supported on this operating system.")
        Catch e As InvalidOperationException
            Console.WriteLine("Unable to get process information on the remote computer.")
        End Try
    End Sub
End Class
' </Snippet1>
' </Snippet2>
