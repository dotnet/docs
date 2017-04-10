' How to: Use SpinWait to Implement a Two-Phase Wait Operation
' <Snippet03>
#Const LOGGING = 1

Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

Class Latch
   Private latchLock As New Object()
   ' 0 = unset, 1 = set.
   Private m_state As Integer = 0
   Private totalKernelWaits As Integer = 0
   
   ' Block threads waiting for ManualResetEvent.
   Private m_ev = New ManualResetEvent(False)

#If LOGGING Then
   ' For fast logging with minimal impact on latch behavior.
   ' Spin counts greater than 20 might be encountered depending on machine config.
   Dim spinCountLog(19) As Long

   Public Sub DisplayLog()
      For i As Integer = 0 To spinCountLog.Length - 1
         Console.WriteLine("Wait succeeded with spin count of {0} on {1:N0} attempts", 
                           i, spinCountLog(i))
      Next
      Console.WriteLine("Wait used the kernel event on {0:N0} attempts.", 
                        totalKernelWaits)
      Console.WriteLine("Logging complete")
   End Sub
#End If

   Public Sub SetLatch()
      SyncLock(latchLock)
         m_state = 1
         m_ev.Set()
      End SyncLock   
   End Sub

   Public Sub Wait()
      Trace.WriteLine("Wait timeout infinite")
      Wait(Timeout.Infinite)
   End Sub

   Public Function Wait(ByVal timeout As Integer) As Boolean
      ' Allocated on the stack.
      Dim spinner = New SpinWait()
      Dim watch As Stopwatch

      While (m_state = 0)
         ' Lazily allocate and start stopwatch to track timeout.
         watch = Stopwatch.StartNew()

         ' Spin only until the SpinWait is ready
         ' to initiate its own context switch.
         If Not spinner.NextSpinWillYield Then
            spinner.SpinOnce()

            ' Rather than let SpinWait do a context switch now,
            '  we initiate the kernel Wait operation, because
            ' we plan on doing this anyway.
         Else
            Interlocked.Increment(totalKernelWaits)
            ' Account for elapsed time.
            Dim realTimeout As Long = timeout - watch.ElapsedMilliseconds

            ' Do the wait.
            If realTimeout <= 0 OrElse Not m_ev.WaitOne(realTimeout) Then
               Trace.WriteLine("wait timed out.")
               Return False
            End If
         End If
      End While

#If LOGGING Then
      Interlocked.Increment(spinCountLog(spinner.Count))
#End If
      ' Take the latch.
      Interlocked.Exchange(m_state, 0)

      Return True
   End Function
End Class

Class Program
   Shared latch = New Latch()
   Shared count As Integer = 2
   Shared cts = New CancellationTokenSource()
   Shared lockObj As New Object()
   
   Shared Sub TestMethod()
      While (Not cts.IsCancellationRequested)
         ' Obtain the latch.
         If (latch.Wait(50)) Then
            ' Do the work. Here we vary the workload a slight amount
            ' to help cause varying spin counts in latch.
            Dim d As Double = 0
            If (count Mod 2 <> 0) Then
               d = Math.Sqrt(count)
            End If
            
            SyncLock(lockObj)
               If count = Int32.MaxValue Then count = 0
               count += 1
            End SyncLock   

            ' Release the latch.
            latch.SetLatch()
         End If
      End While
   End Sub
   
   Shared Sub Main()
      ' Demonstrate latch with a simple scenario:
      ' two threads updating a shared integer and
      ' accessing a shared StringBuilder. Both operations
      ' are relatively fast, which enables the latch to
      ' demonstrate successful waits by spinning only. 
      latch.SetLatch()

      ' UI thread. Press 'c' to cancel the loop.
      Task.Factory.StartNew(Sub()
                               Console.WriteLine("Press 'c' to cancel.")
                               If (Console.ReadKey(True).KeyChar = "c"c) Then
                                  cts.Cancel()
                               End If
                            End Sub)
      Parallel.Invoke(
             Sub() TestMethod(),
             Sub() TestMethod(),
             Sub() TestMethod()
             )

#If LOGGING Then
         latch.DisplayLog()
#End If
          If cts IsNot Nothing Then cts.Dispose()
   End Sub
End Class
' </Snippet03>
