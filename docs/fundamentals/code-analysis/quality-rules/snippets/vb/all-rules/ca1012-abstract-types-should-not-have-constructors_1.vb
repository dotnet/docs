Imports System

Namespace ca1012
    '<snippet1>
    ' Violates this rule      
    Public MustInherit Class Book

        Public Sub New()
        End Sub

    End Class
    '</snippet1>
End Namespace

Namespace ca1012_2
    '<snippet2>
    ' Violates this rule      
    Public MustInherit Class Book

        Protected Sub New()
        End Sub

    End Class
    '</snippet2>
End Namespace
