' <Snippet1>
Imports System
Imports System.Diagnostics
Imports System.ComponentModel

Namespace MyProcessSample
    Class MyProcess
        Sub BindToRunningProcesses()
            ' Get the current process. You can use currentProcess from this point
            ' to access various properties and call methods to control the process.
            Dim currentProcess As Process = Process.GetCurrentProcess()

            ' Get all processes running on the local computer.
            Dim localAll As Process() = Process.GetProcesses()

            ' Get all instances of Notepad running on the local computer.
            ' This will return an empty array if notepad isn't running.
            Dim localByName As Process() = Process.GetProcessesByName("notepad")

            ' Get a process on the local computer, using the process id.
            ' This will throw an exception if there is no such process.
            Dim localById As Process = Process.GetProcessById(1234)


            ' Get processes running on a remote computer. Note that this
            ' and all the following calls will timeout and throw an exception
            ' if "myComputer" and 169.0.0.0 do not exist on your local network.

            ' Get all processes on a remote computer.
            Dim remoteAll As Process() = Process.GetProcesses("myComputer")

            ' Get all instances of Notepad running on the specific computer, using machine name.
            Dim remoteByName As Process() = Process.GetProcessesByName("notepad", "myComputer")

            ' Get all instances of Notepad running on the specific computer, using IP address.
            Dim ipByName As Process() = Process.GetProcessesByName("notepad", "169.0.0.0")

            ' Get a process on a remote computer, using the process id and machine name.
            Dim remoteById As Process = Process.GetProcessById(2345, "myComputer")
        End Sub 'BindToRunningProcesses

        Shared Sub Main()
            Dim myProcess As New MyProcess()
            myProcess.BindToRunningProcesses()
        End Sub 'Main 

    End Class 'MyProcess

End Namespace 'MyProcessSample
' </Snippet1>