' Visual Basic .NET Document
Option Strict On
Option Infer On

Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    ' <Snippet12>
    <Extension()>
    Public Function WaitOneAsync(waitHandle As WaitHandle) As Task
        If waitHandle Is Nothing Then 
            Throw New ArgumentNullException("waitHandle")
        End If
        
        Dim tcs As New TaskCompletionSource(Of Boolean)()
        Dim rwh As RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(waitHandle, 
            Sub(state, timedOut) 
               tcs.TrySetResult(True)
            End Sub, Nothing, -1, True)
        Dim t = tcs.Task
        t.ContinueWith( Sub(antecedent) 
                           rwh.Unregister(Nothing)
                        End Sub)
        Return t
    End Function
   ' </Snippet12>
   
    Public Sub MethodA()
       Dim task As Task = Task.Run( Sub() Thread.Sleep(1000) )
       ' <Snippet14>
       Dim wh As WaitHandle = CType(task, IAsyncResult).AsyncWaitHandle
       ' </Snippet14>
    End Sub    
End Module

