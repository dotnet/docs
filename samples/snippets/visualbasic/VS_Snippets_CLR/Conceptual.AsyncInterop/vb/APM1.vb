' Visual Basic .NET Document
Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Module Example
    ' <Snippet6>
    <Extension()>
    Public Function AsApm(Of T)(task As Task(Of T), 
                                callback As AsyncCallback, 
                                state As Object) As IAsyncResult
        If task Is Nothing Then 
            Throw New ArgumentNullException("task")
        End If
        
        Dim tcs As New TaskCompletionSource(Of T)(state)
        task.ContinueWith(Sub(antecedent) 
                             If antecedent.IsFaulted Then 
                                tcs.TrySetException(antecedent.Exception.InnerExceptions)
                             ElseIf antecedent.IsCanceled Then    
                                tcs.TrySetCanceled()
                             Else 
                                tcs.TrySetResult(antecedent.Result)
                             End If
                             
                             If callback IsNot Nothing Then 
                                callback(tcs.Task)
                             End If   
                          End Sub, TaskScheduler.Default)
        Return tcs.Task
    End Function
    ' </Snippet6>
End Module

