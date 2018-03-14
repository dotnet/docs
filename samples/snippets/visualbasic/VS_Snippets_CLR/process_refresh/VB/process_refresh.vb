' System::Diagnostics::Process::Refresh
' System::Diagnostics::Process::HasExited
' System::Diagnostics::Process::Close
' System::Diagnostics::Process::CloseMainWindow

' The following example starts an instance of Notepad. It then
' retrieves the physical memory usage of the associated process at
' 2 second intervals for a maximum of 10 seconds.  The example detects
' whether the process exits before 10 seconds have elapsed.  
' The example closes the process if it is still running after
' 10 seconds.

' <Snippet1>
Imports System
Imports System.Diagnostics
Imports System.Threading

Namespace Process_Sample
   Class MyProcessClass

      Public Shared Sub Main()
         Try

            Dim myProcess As Process
            myProcess = Process.Start("Notepad.exe")
            ' Display physical memory usage 5 times at intervals of 2 seconds.
            Dim i As Integer
            For i = 0 To 4
               If not myProcess.HasExited Then
               
                  ' Discard cached information about the process.
                  myProcess.Refresh()
                  ' Print working set to console.
                  Console.WriteLine("Physical Memory Usage: " + _
                                              myProcess.WorkingSet.ToString())
                  ' Wait 2 seconds.
                  Thread.Sleep(2000)
               Else 
                  Exit For
               End If
              
            Next i

           ' Close process by sending a close message to its main window.
           myProcess.CloseMainWindow()
           ' Free resources associated with process.
           myProcess.Close()

         Catch e As Exception
            Console.WriteLine("The following exception was raised: ")
            Console.WriteLine(e.Message)
         End Try
      End Sub 'Main
   End Class 'MyProcessClass
End Namespace 'Process_Sample
' </Snippet1>