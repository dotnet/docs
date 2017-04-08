'<snippet1>
Imports System.Threading
Imports System.Collections.Generic
Imports System.Text

Class SafeQueue(Of T)

   '<Snippet3>
   '<Snippet2>
   ' A queue that is protected by Monitor.
   Private m_inputQueue As New Queue(Of T)
   '</Snippet2>

   ' Lock the queue and add an element.
   Public Sub Enqueue(ByVal qValue As T)

      ' Request the lock, and block until it is obtained.
      Monitor.Enter(m_inputQueue)
      Try
         ' When the lock is obtained, add an element.
         m_inputQueue.Enqueue(qValue)

      Finally
         ' Ensure that the lock is released.
         Monitor.Exit(m_inputQueue)
      End Try
   End Sub
   '</Snippet3>

   '<Snippet4>
   ' Try to add an element to the queue: Add the element to the queue 
   ' only if the lock is immediately available.
   Public Function TryEnqueue(ByVal qValue As T) As Boolean

      ' Request the lock.
      If Monitor.TryEnter(m_inputQueue) Then
         Try
            m_inputQueue.Enqueue(qValue)

         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(m_inputQueue)
         End Try
         Return True
      Else
         Return False
      End If
   End Function
   '</Snippet4>

   '<Snippet5>
   ' Try to add an element to the queue: Add the element to the queue 
   ' only if the lock becomes available during the specified time
   ' interval.
   Public Function TryEnqueue(ByVal qValue As T, ByVal waitTime As Integer) As Boolean

      ' Request the lock.
      If Monitor.TryEnter(m_inputQueue, waitTime) Then
         Try
            m_inputQueue.Enqueue(qValue)

         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(m_inputQueue)
         End Try
         Return True
      Else
         Return False
      End If
   End Function
   '</Snippet5>

   ' Lock the queue and dequeue an element.
   Public Function Dequeue() As T

      Dim retval As T

      ' Request the lock, and block until it is obtained.
      Monitor.Enter(m_inputQueue)
      Try
         ' When the lock is obtained, dequeue an element.
         retval = m_inputQueue.Dequeue()

      Finally
         ' Ensure that the lock is released.
         Monitor.Exit(m_inputQueue)
      End Try

      Return retval
   End Function

   ' Delete all elements that equal the given object.
   Public Function Remove(ByVal qValue As T) As Integer

      Dim removedCt As Integer = 0

      ' Wait until the lock is available and lock the queue.
      Monitor.Enter(m_inputQueue)
      Try
         Dim counter As Integer = m_inputQueue.Count
         While (counter > 0)
            'Check each element.
            Dim elem As T = m_inputQueue.Dequeue()
            If Not elem.Equals(qValue) Then
               m_inputQueue.Enqueue(elem)
            Else
               ' Keep a count of items removed.
               removedCt += 1
            End If
            counter = counter - 1
         End While

      Finally
         ' Ensure that the lock is released.
         Monitor.Exit(m_inputQueue)
      End Try

      Return removedCt
   End Function

   ' Print all queue elements.
   Public Function PrintAllElements() As String

      Dim output As New StringBuilder()

      'Lock the queue.
      Monitor.Enter(m_inputQueue)
      Try
         For Each elem As T In m_inputQueue
            ' Print the next element.
            output.AppendLine(elem.ToString())
         Next

      Finally
         ' Ensure that the lock is released.
         Monitor.Exit(m_inputQueue)
      End Try

      Return output.ToString()
   End Function
End Class

Public Class Example

   Private Shared q As New SafeQueue(Of Integer)
   Private Shared threadsRunning As Integer = 0
   Private Shared results(2)() As Integer

   Friend Shared Sub Main()

      Console.WriteLine("Working...")

      For i As Integer = 0 To 2

         Dim t As New Thread(AddressOf ThreadProc)
         t.Start(i)
         Interlocked.Increment(threadsRunning)

      Next i

   End Sub

   Private Shared Sub ThreadProc(ByVal state As Object)

      Dim finish As DateTime = DateTime.Now.AddSeconds(10)
      Dim rand As New Random()
      Dim result() As Integer = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
      Dim threadNum As Integer = CInt(state)

      While (DateTime.Now < finish)

         Dim what As Integer = rand.Next(250)
         Dim how As Integer = rand.Next(100)

         If how < 16 Then
            q.Enqueue(what)
            result(ThreadResultIndex.EnqueueCt) += 1
         Else If how < 32 Then
            If q.TryEnqueue(what)
               result(ThreadResultIndex.TryEnqueueSucceedCt) += 1
            Else
               result(ThreadResultIndex.TryEnqueueFailCt) += 1
            End If
         Else If how < 48 Then
            ' Even a very small wait significantly increases the success 
            ' rate of the conditional enqueue operation.
            If q.TryEnqueue(what, 10)
               result(ThreadResultIndex.TryEnqueueWaitSucceedCt) += 1
            Else
               result(ThreadResultIndex.TryEnqueueWaitFailCt) += 1
            End If
         Else If how < 96 Then
            result(ThreadResultIndex.DequeueCt) += 1
            Try
               q.Dequeue()
            Catch
               result(ThreadResultIndex.DequeueExCt) += 1
            End Try
         Else
            result(ThreadResultIndex.RemoveCt) += 1
            result(ThreadResultIndex.RemovedCt) += q.Remove(what)
         End If
         
      End While

      results(threadNum) = result

      If 0 = Interlocked.Decrement(threadsRunning) Then
      
         Dim sb As New StringBuilder( _
            "                               Thread 1 Thread 2 Thread 3    Total" & vbLf)

         For row As Integer = 0 To 8

            Dim total As Integer = 0
            sb.Append(titles(row))

            For col As Integer = 0 To 2

               sb.Append(String.Format("{0,9}", results(col)(row)))
               total += results(col)(row)

            Next col

            sb.AppendLine(String.Format("{0,9}", total))

         Next row

         Console.WriteLine(sb.ToString())

      End If     
    
   End Sub

   Private Shared titles() As String = { _
      "Enqueue                       ", _
      "TryEnqueue succeeded          ", _
      "TryEnqueue failed             ", _
      "TryEnqueue(T, wait) succeeded ", _
      "TryEnqueue(T, wait) failed    ", _
      "Dequeue attempts              ", _
      "Dequeue exceptions            ", _
      "Remove operations             ", _
      "Queue elements removed        "  _
   }

   Private Enum ThreadResultIndex
      EnqueueCt
      TryEnqueueSucceedCt
      TryEnqueueFailCt
      TryEnqueueWaitSucceedCt
      TryEnqueueWaitFailCt
      DequeueCt
      DequeueExCt
      RemoveCt
      RemovedCt
   End Enum

End Class

' This example produces output similar to the following:
'
'Working...
'                               Thread 1 Thread 2 Thread 3    Total
'Enqueue                          294357   512164   302838  1109359
'TryEnqueue succeeded             294486   512403   303117  1110006
'TryEnqueue failed                   108      234      127      469
'TryEnqueue(T, wait) succeeded    294259   512796   302556  1109611
'TryEnqueue(T, wait) failed            1        1        1        3
'Dequeue attempts                 882266  1537993   907795  3328054
'Dequeue exceptions                12691    21474    13480    47645
'Remove operations                 74059   128715    76187   278961
'Queue elements removed            12667    22606    13219    48492
'</snippet1>
