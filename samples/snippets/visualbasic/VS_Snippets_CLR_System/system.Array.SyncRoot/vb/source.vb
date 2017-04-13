Imports System

Public Class Example

    Public Shared Sub Main()
    
'<Snippet1>
        Dim myArray As Array = New Integer() { 1, 2, 4 }
        SyncLock(myArray.SyncRoot) 
            For Each item As Object In myArray
                Console.WriteLine(item)
            Next
        End SyncLock
'</Snippet1>
    End Sub
End Class