' Visual Basic .NET Document
Option Strict On

Module Example
    ' <Snippet1>                                                    
    Public Function Read(buffer As Byte(), offset As Integer,
                         count As Integer) As Integer
        ' </Snippet1>
        Return 0
    End Function

    ' <Snippet2>
    Public Function BeginRead(buffer As Byte, offset As Integer,
                              count As Integer, callback As AsyncCallback,
                              state As Object) As IAsyncResult
        ' </Snippet2>
        Return Nothing
    End Function

    ' <Snippet3>
    Public Function EndRead(asyncResult As IAsyncResult) As Integer
        ' </Snippet3>
        Return 0
    End Function
End Module

