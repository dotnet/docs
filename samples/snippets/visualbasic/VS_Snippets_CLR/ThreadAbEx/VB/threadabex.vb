'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.Permissions


Public Class ThreadWork
   Public Shared Sub DoWork()
      Try
         Dim i As Integer
         For i = 0 To 99
            Console.WriteLine("Thread - working.")
            Thread.Sleep(100)
         Next i
      Catch e As ThreadAbortException
         Console.WriteLine("Thread - caught ThreadAbortException - resetting.")
         Console.WriteLine("Exception message: {0}", e.Message)
         Thread.ResetAbort()
      End Try
      Console.WriteLine("Thread - still alive and working.")
      Thread.Sleep(1000)
      Console.WriteLine("Thread - finished working.")
   End Sub 'DoWork
End Class 'ThreadWork


Class ThreadAbortTest
   Public Shared Sub Main()
      Dim myThreadDelegate As New ThreadStart(AddressOf ThreadWork.DoWork)
      Dim myThread As New Thread(myThreadDelegate)
      myThread.Start()
      Thread.Sleep(100)
      Console.WriteLine("Main - aborting my thread.")
      myThread.Abort()
      myThread.Join()
      Console.WriteLine("Main ending.")
   End Sub 'Main
End Class 'ThreadAbortTest
'</Snippet1>