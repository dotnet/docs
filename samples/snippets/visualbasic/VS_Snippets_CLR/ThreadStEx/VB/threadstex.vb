'<Snippet1>
Imports System.Threading

Public Class ThreadWork
   
   Public Shared Sub DoWork()
      Console.WriteLine("Working thread...")
   End Sub
End Class

Class ThreadStateTest
   
   Public Shared Sub Main()
      Dim myThreadDelegate As New ThreadStart(AddressOf ThreadWork.DoWork)
      Dim myThread As New Thread(myThreadDelegate)
      myThread.Start()
      Thread.Sleep(0)
      Console.WriteLine("In main. Attempting to restart myThread.")
      Try
         myThread.Start()
      Catch e As ThreadStateException
         Console.WriteLine("Caught: {0}", e.Message)
      End Try
   End Sub
End Class
'</Snippet1>