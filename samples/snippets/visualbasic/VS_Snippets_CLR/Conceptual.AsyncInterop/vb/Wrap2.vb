' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Module Example
    ' <Snippet5>

    <Extension()>
    Public Function ReadAsync(stream As Stream, buffer As Byte(), _
                              offset As Integer, count As Integer) _
                              As Task(Of Integer)
       If stream Is Nothing Then 
           Throw New ArgumentNullException("stream")
       End If    

       Dim tcs As New TaskCompletionSource(Of Integer)()
       stream.BeginRead(buffer, offset, count, 
                        Sub(iar)
                           Try  
                              tcs.TrySetResult(stream.EndRead(iar)) 
                           Catch e As OperationCanceledException  
                              tcs.TrySetCanceled() 
                           Catch e As Exception 
                              tcs.TrySetException(e) 
                           End Try
                        End Sub, Nothing)
       Return tcs.Task
   End Function
   ' </Snippet5>
End Module

