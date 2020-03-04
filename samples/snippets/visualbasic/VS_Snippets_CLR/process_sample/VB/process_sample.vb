' System.Diagnostics.Process.WorkingSet
' System.Diagnostics.Process.BasePriority
' System.Diagnostics.Process.UserProcessorTime
' System.Diagnostics.Process.PrivilegedProcessorTime
' System.Diagnostics.Process.TotalProcessorTime
' System.Diagnostics.Process.ToString
' System.Diagnostics.Process.Responding
' System.Diagnostics.Process.PriorityClass
' System.Diagnostics.Process.ExitCode

' The following example starts an instance of Notepad. The example 
' then retrieves and displays various properties of the associated
' process.  The example detects when the process exits, and displays the process's exit code.

' <Snippet1>
Imports System.Diagnostics
Imports System.Threading

Namespace Process_Sample
    Class MyProcessClass

        Public Shared Sub Main()
            Try

                Using myProcess = Process.Start("NotePad.exe")

                    While Not myProcess.HasExited

                        Console.WriteLine()

                        Console.WriteLine($"Process's physical memory usage          : {myProcess.WorkingSet}")
                        Console.WriteLine($"Base priority of the associated process  : {myProcess.BasePriority}")
                        Console.WriteLine($"Priority class of the associated process : {myProcess.PriorityClass}")
                        Console.WriteLine($"User processor time                      : {myProcess.UserProcessorTime}")
                        Console.WriteLine($"Privileged processor time                : {myProcess.PrivilegedProcessorTime}")
                        Console.WriteLine($"Total processor time                     : {myProcess.TotalProcessorTime}")
                        Console.WriteLine($"Process's name                           : {myProcess}")
                        Console.WriteLine("-------------------------------------")

                        If myProcess.Responding Then
                            Console.WriteLine("Status:  Responding to user interface")
                            myProcess.Refresh()
                        Else
                            Console.WriteLine("Status:  Not Responding")
                        End If
                        Thread.Sleep(1000)
                    End While

                    Console.WriteLine()
                    Console.WriteLine($"Process exit code: {myProcess.ExitCode}")
                End Using

            Catch e As Exception
                Console.WriteLine($"The following exception was raised: {e.Message}")
            End Try
        End Sub
    End Class
End Namespace 'Process_Sample

' </Snippet1>
