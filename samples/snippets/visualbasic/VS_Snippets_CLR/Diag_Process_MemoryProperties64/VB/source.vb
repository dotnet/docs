' The following example starts an instance of Notepad. The example 
' then retrieves and displays various properties of the associated
' process.  The example detects when the process exits, and displays
' the process's exit code.

' <Snippet1>
Imports System.Diagnostics

Namespace ProcessSample
    Class ProcessMonitorSample

        Public Shared Sub Main()

            ' Define variables to track the peak
            ' memory usage of the process.
            Dim peakPagedMem As Long = 0
            Dim peakWorkingSet As Long = 0
            Dim peakVirtualMem As Long = 0

            ' Start the process.
            Using myProcess = Process.Start("NotePad.exe")

                ' Display process statistics until
                ' the user closes the program.
                Do

                    If Not myProcess.HasExited Then

                        ' Refresh the current process property values.
                        myProcess.Refresh()

                        Console.WriteLine()

                        ' Display current process statistics.

                        Console.WriteLine($"{myProcess} -")
                        Console.WriteLine("-------------------------------------")

                        Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}")
                        Console.WriteLine($"  Base priority             : {myProcess.BasePriority}")
                        Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}")
                        Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}")
                        Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}")
                        Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}")
                        Console.WriteLine($"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}")
                        Console.WriteLine($"  Paged memory size         : {myProcess.PagedMemorySize64}")

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
                Console.WriteLine($"  Process exit code                         : {myProcess.ExitCode}")

                ' Display peak memory statistics for the process.
                Console.WriteLine($"  Peak physical memory usage of the process : {peakWorkingSet}")
                Console.WriteLine($"  Peak paged memory usage of the process    : {peakPagedMem}")
                Console.WriteLine($"  Peak virtual memory usage of the process  : {peakVirtualMem}")
            End Using
        End Sub
    End Class
End Namespace
' </Snippet1>
