' The following example starts an instance of Notepad. The example 
' then retrieves and displays various properties of the associated
' process.  The example detects when the process exits, and displays
' the process's exit code.

' <Snippet1>
Imports System
Imports System.Diagnostics

Namespace ProcessSample
    Class ProcessMonitorSample

        Public Shared Sub Main()

            ' Define variables to track the peak
            ' memory usage of the process.
            Dim peakPagedMem As Long = 0
            Dim peakWorkingSet As Long = 0
            Dim peakVirtualMem As Long = 0

            Dim myProcess As Process = Nothing

            Try

                ' Start the process.
                myProcess = Process.Start("NotePad.exe")

                ' Display process statistics until
                ' the user closes the program.
                Do

                    If Not myProcess.HasExited Then

                        ' Refresh the current process property values.
                        myProcess.Refresh()

                        Console.WriteLine()

                        ' Display current process statistics.

                        Console.WriteLine("{0} -", myProcess.ToString())
                        Console.WriteLine("-------------------------------------")

                        Console.WriteLine("  physical memory usage: {0}", _
                             myProcess.WorkingSet64)
                        Console.WriteLine("  base priority: {0}", _
                             myProcess.BasePriority)
                        Console.WriteLine("  priority class: {0}", _
                             myProcess.PriorityClass)
                        Console.WriteLine("  user processor time: {0}", _
                             myProcess.UserProcessorTime)
                        Console.WriteLine("  privileged processor time: {0}", _
                             myProcess.PrivilegedProcessorTime)
                        Console.WriteLine("  total processor time: {0}", _
                             myProcess.TotalProcessorTime)
                        Console.WriteLine("  PagedSystemMemorySize64: {0}", _
                            myProcess.PagedSystemMemorySize64)
                        Console.WriteLine("  PagedMemorySize64: {0}", _
                           myProcess.PagedMemorySize64)

                        ' Update the values for the overall peak memory statistics.
                        peakPagedMem = myProcess.PeakPagedMemorySize64
                        peakVirtualMem = myProcess.PeakVirtualMemorySize64
                        peakWorkingSet = myProcess.PeakWorkingSet64

                        If myProcess.Responding Then
                            Console.WriteLine("Status = Running")
                        Else
                            Console.WriteLine("Status = Not Responding")
                        End If
                    End If
                Loop While Not myProcess.WaitForExit(1000)

                Console.WriteLine()
                Console.WriteLine("Process exit code: {0}", myProcess.ExitCode)

                ' Display peak memory statistics for the process.
                Console.WriteLine("Peak physical memory usage of the process: {0}", _
                    peakWorkingSet)
                Console.WriteLine("Peak paged memory usage of the process: {0}", _
                    peakPagedMem)
                Console.WriteLine("Peak virtual memory usage of the process: {0}", _
                    peakVirtualMem)

            Finally
                If Not myProcess Is Nothing Then
                    myProcess.Close()
                End If
            End Try
        End Sub 'Main
    End Class
End Namespace
' </Snippet1>