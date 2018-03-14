'<snippet1>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Class TestQueue
   ' Demonstrates:
   ' ConcurrentQueue<T>.Enqueue()
   ' ConcurrentQueue<T>.TryPeek()
   ' ConcurrentQueue<T>.TryDequeue()
   Shared Sub Main()
      ' Construct a ConcurrentQueue
      Dim cq As New ConcurrentQueue(Of Integer)()

      ' Populate the queue
      For i As Integer = 0 To 9999
         cq.Enqueue(i)
      Next

      ' Peek at the first element
      Dim result As Integer
      If Not cq.TryPeek(result) Then
         Console.WriteLine("CQ: TryPeek failed when it should have succeeded")
      ElseIf result <> 0 Then
         Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result)
      End If

      Dim outerSum As Integer = 0

      ' An action to consume the ConcurrentQueue
      Dim action As Action =
          Sub()
             Dim localSum As Integer = 0
             Dim localValue As Integer
             While cq.TryDequeue(localValue)
                localSum += localValue
             End While
             Interlocked.Add(outerSum, localSum)
          End Sub

      ' Start 4 concurrent consuming actions
      Parallel.Invoke(action, action, action, action)

      Console.WriteLine("outerSum = {0}, should be 49995000", outerSum)
   End Sub
End Class
'</snippet1>