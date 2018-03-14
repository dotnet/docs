'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks
Module MRESDemo

    Sub Main()

    End Sub
    ' Demonstrates:
    ' ManualResetEventSlim construction
    ' ManualResetEventSlim.Wait()
    ' ManualResetEventSlim.Set()
    ' ManualResetEventSlim.Reset()
    ' ManualResetEventSlim.IsSet
    Private Sub MRES_SetWaitReset()
        ' initialize as unsignaled
        Dim mres1 As New ManualResetEventSlim(False)
        ' initialize as unsignaled
        Dim mres2 As New ManualResetEventSlim(False)
        ' initialize as signaled
        Dim mres3 As New ManualResetEventSlim(True)

        ' Start an asynchronous Task that manipulates mres3 and mres2
        Dim observer = Task.Factory.StartNew(
            Sub()
                mres1.Wait()
                Console.WriteLine("observer sees signaled mres1!")
                Console.WriteLine("observer resetting mres3...")
                mres3.Reset()
                ' should switch to unsignaled
                Console.WriteLine("observer signalling mres2")
                mres2.[Set]()
            End Sub)

        Console.WriteLine("main thread: mres3.IsSet = {0} (should be true)", mres3.IsSet)
        Console.WriteLine("main thread signalling mres1")
        mres1.[Set]()
        ' This will "kick off" the observer Task
        mres2.Wait()
        ' This won't return until observer Task has finished resetting mres3
        Console.WriteLine("main thread sees signaled mres2!")
        Console.WriteLine("main thread: mres3.IsSet = {0} (should be false)", mres3.IsSet)

        ' make sure that observer has fully completed
        observer.Wait()
        ' It's good form to Dispose() a ManualResetEventSlim when you're done with it
        mres1.Dispose()
        mres2.Dispose()
        mres3.Dispose()
    End Sub

    ' Demonstrates:
    ' ManualResetEventSlim construction w/ SpinCount
    ' ManualResetEventSlim.WaitHandle
    Private Sub MRES_SpinCountWaitHandle()
        ' Construct a ManualResetEventSlim with a SpinCount of 1000
        ' Higher spincount => longer time the MRES will spin-wait before taking lock
        Dim mres1 As New ManualResetEventSlim(False, 1000)
        Dim mres2 As New ManualResetEventSlim(False, 1000)

        Dim bgTask As Task = Task.Factory.StartNew(
            Sub()
                ' Just wait a little
                Thread.Sleep(100)

                ' Now signal both MRESes
                Console.WriteLine("Task signalling both MRESes")
                mres1.[Set]()
                mres2.[Set]()
            End Sub)

        ' A common use of MRES.WaitHandle is to use MRES as a participant in 
        ' WaitHandle.WaitAll/WaitAny. Note that accessing MRES.WaitHandle will
        ' result in the unconditional inflation of the underlying ManualResetEvent.
        WaitHandle.WaitAll(New WaitHandle() {mres1.WaitHandle, mres2.WaitHandle})
        Console.WriteLine("WaitHandle.WaitAll(mres1.WaitHandle, mres2.WaitHandle) completed.")

        ' Wait for bgTask to complete and clean up
        bgTask.Wait()
        mres1.Dispose()
        mres2.Dispose()
    End Sub
End Module
'</snippet01>