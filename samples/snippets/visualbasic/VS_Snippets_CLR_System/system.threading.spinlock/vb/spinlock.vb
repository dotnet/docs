'<snippet01>
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks


Module SpinLockDemo

    ' Demonstrates:
    ' Default SpinLock construction ()
    ' SpinLock.Enter(ref bool)
    ' SpinLock.Exit()
    Private Sub SpinLockSample1()
        Dim sl As New SpinLock()

        Dim sb As New StringBuilder()

        ' Action taken by each parallel job.
        ' Append to the StringBuilder 10000 times, protecting
        ' access to sb with a SpinLock.
        Dim action As Action =
            Sub()
                Dim gotLock As Boolean = False
                For i As Integer = 0 To 9999
                    gotLock = False
                    Try
                        sl.Enter(gotLock)
                        sb.Append((i Mod 10).ToString())
                    Finally
                        ' Only give up the lock if you actually acquired it
                        If gotLock Then
                            sl.[Exit]()
                        End If
                    End Try
                Next
            End Sub

        ' Invoke 3 concurrent instances of the action above
        Parallel.Invoke(action, action, action)

        ' Check/Show the results
        Console.WriteLine("sb.Length = {0} (should be 30000)", sb.Length)
        Console.WriteLine("number of occurrences of '5' in sb: {0} (should be 3000)", sb.ToString().Where(Function(c) (c = "5"c)).Count())
    End Sub

    ' Demonstrates:
    ' Default SpinLock constructor (tracking thread owner)
    ' SpinLock.Enter(ref bool)
    ' SpinLock.Exit() throwing exception
    ' SpinLock.IsHeld
    ' SpinLock.IsHeldByCurrentThread
    ' SpinLock.IsThreadOwnerTrackingEnabled
    Private Sub SpinLockSample2()
        ' Instantiate a SpinLock
        Dim sl As New SpinLock()

        ' These MRESs help to sequence the two jobs below
        Dim mre1 As New ManualResetEventSlim(False)
        Dim mre2 As New ManualResetEventSlim(False)
        Dim lockTaken As Boolean = False

        Dim taskA As Task = Task.Factory.StartNew(
            Sub()
                Try
                    sl.Enter(lockTaken)
                    Console.WriteLine("Task A: entered SpinLock")
                    mre1.[Set]()
                    ' Signal Task B to commence with its logic
                    ' Wait for Task B to complete its logic
                    ' (Normally, you would not want to perform such a potentially
                    ' heavyweight operation while holding a SpinLock, but we do it
                    ' here to more effectively show off SpinLock properties in
                    ' taskB.)
                    mre2.Wait()
                Finally
                    If lockTaken Then
                        sl.[Exit]()
                    End If
                End Try
            End Sub)

        Dim taskB As Task = Task.Factory.StartNew(
            Sub()
                mre1.Wait()
                ' wait for Task A to signal me
                Console.WriteLine("Task B: sl.IsHeld = {0} (should be true)", sl.IsHeld)
                Console.WriteLine("Task B: sl.IsHeldByCurrentThread = {0} (should be false)", sl.IsHeldByCurrentThread)
                Console.WriteLine("Task B: sl.IsThreadOwnerTrackingEnabled = {0} (should be true)", sl.IsThreadOwnerTrackingEnabled)

                Try
                    sl.[Exit]()
                    Console.WriteLine("Task B: Released sl, should not have been able to!")
                Catch e As Exception
                    Console.WriteLine("Task B: sl.Exit resulted in exception, as expected: {0}", e.Message)
                End Try

                ' Signal Task A to exit the SpinLock
                mre2.[Set]()
            End Sub)

        ' Wait for task completion and clean up
        Task.WaitAll(taskA, taskB)
        mre1.Dispose()
        mre2.Dispose()
    End Sub

    ' Demonstrates:
    ' SpinLock constructor(false) -- thread ownership not tracked
    Private Sub SpinLockSample3()
        ' Create SpinLock that does not track ownership/threadIDs
        Dim sl As New SpinLock(False)

        ' Used to synchronize with the Task below
        Dim mres As New ManualResetEventSlim(False)

        ' We will verify that the Task below runs on a separate thread
        Console.WriteLine("main thread id = {0}", Thread.CurrentThread.ManagedThreadId)

        ' Now enter the SpinLock.  Ordinarily, you would not want to spend so
        ' much time holding a SpinLock, but we do it here for the purpose of 
        ' demonstrating that a non-ownership-tracking SpinLock can be exited 
        ' by a different thread than that which was used to enter it.
        Dim lockTaken As Boolean = False
        sl.Enter(lockTaken)

        ' Create a separate Task
        Dim worker As Task = Task.Factory.StartNew(
            Sub()
                Console.WriteLine("worker task thread id = {0} (should be different than main thread id)", Thread.CurrentThread.ManagedThreadId)

                ' Now exit the SpinLock
                Try
                    sl.[Exit]()
                    Console.WriteLine("worker task: successfully exited SpinLock, as expected")
                Catch e As Exception
                    Console.WriteLine("worker task: unexpected failure in exiting SpinLock: {0}", e.Message)
                End Try

                ' Notify main thread to continue
                mres.[Set]()
            End Sub)

        ' Do this instead of worker.Wait(), because worker.Wait() could inline the worker Task,
        ' causing it to be run on the same thread. The purpose of this example is to show that
        ' a different thread can exit the SpinLock created (without thread tracking) on your thread.
        mres.Wait()

        ' now Wait() on worker and clean up
        worker.Wait()
        mres.Dispose()
    End Sub


End Module
'</snippet01>