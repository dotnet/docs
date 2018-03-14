' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Module Example
    ' <Snippet4>
    <Extension()>
    Public Function ReadAsync(strm As Stream, 
                              buffer As Byte(), offset As Integer, 
                              count As Integer) As Task(Of Integer)
        If strm Is Nothing Then 
           Throw New ArgumentNullException("stream")
        End If   
        
        Return Task(Of Integer).Factory.FromAsync(AddressOf strm.BeginRead, 
                                                  AddressOf strm.EndRead, buffer, 
                                                  offset, count, Nothing)
    End Function
    ' </Snippet4>
End Module

