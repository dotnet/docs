Imports System.Runtime.CompilerServices

Module Module1

    <Extension()>
    Sub Add(ByVal genericList As List(Of Customer),
            ByVal id As Integer,
            ByVal name As String,
            ByVal orders As OrderCollection)

        genericList.Add(New Customer(id, name, orders))
    End Sub
End Module