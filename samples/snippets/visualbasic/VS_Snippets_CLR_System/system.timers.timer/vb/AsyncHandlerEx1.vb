' <Snippet3>
Imports System.Threading.Tasks
Imports System.Timers

Public Module Example
   Public Sub Main()
      Dim timer As New Timer(1000)  
      AddHandler timer.Elapsed, AddressOf Example.HandleTimer     
      'timer.Elapsed = Async ( sender, e ) => await HandleTimer()
      timer.Start()
      Console.Write("Press any key to exit... ")
      Console.ReadKey()
   End Sub

   Private Async Sub HandleTimer(sender As Object, e As EventArgs)
      Await Task.Run(Sub()
                        Console.WriteLine()
                        Console.WriteLine("Handler not implemented..." )
                        Throw New NotImplementedException()
                     End Sub)   
   End Sub
End Module
' The example displays output like the following:
'   Press any key to exit...
'   Handler not implemented...
'   
'   Unhandled Exception: System.NotImplementedException: The method or operation is not implemented.
'      at Example._Lambda$__1()
'      at System.Threading.Tasks.Task.Execute()
'   --- End of stack trace from previous location where exception was thrown ---
'      at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
'      at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
'      at Example.VB$StateMachine_0_HandleTimer.MoveNext()
'   --- End of stack trace from previous location where exception was thrown ---
'      at System.Runtime.CompilerServices.AsyncMethodBuilderCore.<>c__DisplayClass2.<ThrowAsync>b__5(Object state)
'      at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
'      at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
'      at System.Threading.QueueUserWorkItemCallback.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
'      at System.Threading.ThreadPoolWorkQueue.Dispatch()
' </Snippet3>
