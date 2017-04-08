'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class ObsoleteAttributeOnMember
    
        <ObsoleteAttribute("This property is obsolete and will " & _
             "be removed in a future version. Use the FirstName " & _
             "and LastName properties instead.", False)> _
        ReadOnly Property Name As String
            Get
                Return "Name"
            End Get
        End Property

        ReadOnly Property FirstName As String
            Get
                Return "FirstName"
            End Get
        End Property

        ReadOnly Property LastName As String
            Get
                Return "LastName"
            End Get
        End Property

    End Class

End Namespace
'</Snippet1>
