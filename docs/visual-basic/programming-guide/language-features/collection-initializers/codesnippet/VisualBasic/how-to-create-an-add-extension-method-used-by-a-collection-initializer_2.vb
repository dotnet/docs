Imports System.Runtime.CompilerServices

Module Module1

    <Extension()>
    Sub Add(ByVal list As List(Of Employee), ByVal id As Integer,
                                             ByVal name As String)
        list.Add(New Employee With {.Id = id, .Name = name})
    End Sub

End Module