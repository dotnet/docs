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
Imports System
Imports System.Diagnostics
Imports System.Threading

Namespace Process_Sample
   Class MyProcessClass

      Public Shared Sub Main()
         Try

            Dim myProcess As Process
            myProcess = Process.Start("NotePad.exe")

            While Not myProcess.HasExited

               Console.WriteLine()
               
               ' Get physical memory usage of the associated process.
               Console.WriteLine("Process's physical memory usage: " + _
                                      myProcess.WorkingSet.ToString)
               ' Get base priority of the associated process.
               Console.WriteLine("Base priority of the associated process: " + _
                                      myProcess.BasePriority.ToString)
               ' Get priority class of the associated process.
               Console.WriteLine("Priority class of the associated process: " + _
                                      myProcess.PriorityClass.ToString)
               ' Get user processor time for this process.
               Console.WriteLine("User Processor Time: " + _
                                      myProcess.UserProcessorTime.ToString)
               ' Get privileged processor time for this process.
               Console.WriteLine("Privileged Processor Time: " + _
                                   myProcess.PrivilegedProcessorTime.ToString)
               ' Get total processor time for this process.
               Console.WriteLine("Total Processor Time: " + _
                                     myProcess.TotalProcessorTime.ToString)
               ' Invoke overloaded ToString function.
               Console.WriteLine("Process's Name: " + myProcess.ToString)
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
            Console.WriteLine("Process exit code: {0}", myProcess.ExitCode)

         Catch e As Exception
            Console.WriteLine("The following exception was raised: " + e.Message)
         End Try
      End Sub 'Main
   End Class 'MyProcessClass
End Namespace 'Process_Sample

' </Snippet1>