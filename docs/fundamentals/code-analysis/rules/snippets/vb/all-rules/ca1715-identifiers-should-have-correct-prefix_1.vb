Imports System

Namespace ca1715
    '<snippet1>
    ' Violates this rule
    Public Interface Book

        ReadOnly Property Title() As String

        Sub Read()

    End Interface
    '</snippet1>

    '<snippet2>
    ' Fixes the violation by prefixing the interface with 'I'
    Public Interface IBook

        ReadOnly Property Title() As String

        Sub Read()

    End Interface
    '</snippet2>

    '<snippet3>
    ' Violates this rule
    Public Class Collection(Of Item)

    End Class
    '</snippet3>
End Namespace

Namespace ca1715_2
    '<snippet4>
    ' Fixes the violation by prefixing the generic type parameter with 'T'
    Public Class Collection(Of TItem)

    End Class
    '</snippet4>

End Namespace
