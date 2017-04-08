'<snippet04>
Imports System.Threading
Imports System.Threading.Tasks
Module ContuationOptionsDemo
    ' Demonstrated features:
    '   TaskContinuationOptions
    '   Task.ContinueWith()
    '   Task.Factory
    '   Task.Wait()
    ' Expected results:
    '   This sample demonstrates branched continuation sequences - Task+Commit or Task+Rollback.
    '   Notice that no if statements are used.
    '   The first sequence is successful - tran1 and commitTran1 are executed. rollbackTran1 is canceled.
    '   The second sequence is unsuccessful - tran2 and rollbackTran2 are executed. tran2 is faulted, and commitTran2 is canceled.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskcontinuationoptions(VS.100).aspx
    Private Sub Main()
        Dim success As Action = Sub()
                                    Console.WriteLine("Task={0}, Thread={1}: Begin successful transaction", Task.CurrentId, Thread.CurrentThread.ManagedThreadId)
                                End Sub

        Dim failure As Action = Sub()
                                    Console.WriteLine("Task={0}, Thread={1}: Begin transaction and encounter an error", Task.CurrentId, Thread.CurrentThread.ManagedThreadId)
                                    Throw New InvalidOperationException("SIMULATED EXCEPTION")
                                End Sub

        Dim commit As Action(Of Task) = Sub(antecendent)
                                            Console.WriteLine("Task={0}, Thread={1}: Commit transaction", Task.CurrentId, Thread.CurrentThread.ManagedThreadId)
                                        End Sub

        Dim rollback As Action(Of Task) = Sub(antecendent)
                                              ' "Observe" your antecedent's exception so as to avoid an exception
                                              ' being thrown on the finalizer thread
                                              Dim unused = antecendent.Exception

                                              Console.WriteLine("Task={0}, Thread={1}: Rollback transaction", Task.CurrentId, Thread.CurrentThread.ManagedThreadId)
                                          End Sub

        ' Successful transaction - Begin + Commit
        Console.WriteLine("Demonstrating a successful transaction")

        ' Initial task
        ' Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
        Dim tran1 As Task = Task.Factory.StartNew(success)

        ' The following task gets scheduled only if tran1 completes successfully
        Dim commitTran1 = tran1.ContinueWith(commit, TaskContinuationOptions.OnlyOnRanToCompletion)

        ' The following task gets scheduled only if tran1 DOES NOT complete successfully
        Dim rollbackTran1 = tran1.ContinueWith(rollback, TaskContinuationOptions.NotOnRanToCompletion)

        ' For demo purposes, wait for the sample to complete
        commitTran1.Wait()

        ' -----------------------------------------------------------------------------------


        ' Failed transaction - Begin + exception + Rollback 
        Console.WriteLine(vbLf & "Demonstrating a failed transaction")

        ' Initial task
        ' Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
        Dim tran2 As Task = Task.Factory.StartNew(failure)

        ' The following task gets scheduled only if tran2 completes successfully
        Dim commitTran2 = tran2.ContinueWith(commit, TaskContinuationOptions.OnlyOnRanToCompletion)

        ' The following task gets scheduled only if tran2 DOES NOT complete successfully
        Dim rollbackTran2 = tran2.ContinueWith(rollback, TaskContinuationOptions.NotOnRanToCompletion)

        ' For demo purposes, wait for the sample to complete
        rollbackTran2.Wait()
    End Sub
End Module
'</snippet04>

