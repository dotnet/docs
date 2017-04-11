'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class StaticMembers
    
        Private Shared someField As Integer 

        Shared Property SomeProperty As Integer
            Get
                Return someField
            End Get
            Set
                someField = Value
            End Set
        End Property

        Private Sub New()
        End Sub

        Shared Sub SomeMethod()
        End Sub

    End Class

End Namespace
'</Snippet1>
