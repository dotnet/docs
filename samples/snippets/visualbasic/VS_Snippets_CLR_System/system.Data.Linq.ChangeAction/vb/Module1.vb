Imports System.Data.Linq


Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    Public Sub OnValidate(ByVal action As System.Data.Linq.ChangeAction)
        If action = ChangeAction.Insert Then
            Console.WriteLine("Notify billing office.")
        End If
    End Sub
    ' </Snippet1>

End Module
