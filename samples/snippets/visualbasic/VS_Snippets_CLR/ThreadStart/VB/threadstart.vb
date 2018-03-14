'<Snippet1>
Imports System.Threading

Public Class ThreadWork
   Public Shared Sub DoWork()
      Dim i As Integer
      For i = 0 To 2
         Console.WriteLine("Working thread...")
         Thread.Sleep(100)
      Next i
   End Sub
End Class

Class ThreadTest
   Public Shared Sub Main()
      Dim thread1 As New Thread(AddressOf ThreadWork.DoWork)
      thread1.Start()
      Dim i As Integer
      For i = 0 To 2
         Console.WriteLine("In main.")
         Thread.Sleep(100)
      Next
   End Sub
End Class
' The example displays output like the following:
'       In main.
'       Working thread...
'       In main.
'       Working thread...
'       In main.
'       Working thread...
'</Snippet1>