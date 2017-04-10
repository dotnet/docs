' Visual Basic .NET Document
Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Class Example
   ' <Snippet7>
   Public Shared Function DownloadStringAsync(url As Uri) As Task(Of String)
   ' </Snippet7>
      Return Task.FromResult(Of String)(String.Empty)
    End Function

   ' <Snippet8>
   Public Function BeginDownloadString(url As Uri, 
                                       callback As AsyncCallback, 
                                       state As Object) As IAsyncResult
   ' </Snippet8>
      Return Nothing
   End Function

   ' <Snippet9>                                        
   Public Function EndDownloadString(asyncResult As IAsyncResult) As String
   ' </Snippet9>
      Return String.Empty
   End Function
End Class

Public Class Example2
   ' <Snippet10>
   Public Function BeginDownloadString(url As Uri, 
                                       callback As AsyncCallback, 
                                       state As Object) As IAsyncResult
      Return DownloadStringAsync(url).AsApm(callback, state)
   End Function

   Public Function EndDownloadString(asyncResult As IAsyncResult) As String
      Return CType(asyncResult, Task(Of String)).Result
   End Function
   ' </Snippet10>
   
   Public Shared Function DownloadStringAsync(url As Uri) As Task(Of String)
      Return Task.FromResult(Of String)(String.Empty)
    End Function
End Class

Module Library
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
End Module

