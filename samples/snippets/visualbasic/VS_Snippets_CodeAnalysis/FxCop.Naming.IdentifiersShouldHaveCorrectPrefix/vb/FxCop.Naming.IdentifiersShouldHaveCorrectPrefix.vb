'<Snippet1>
Imports System

Namespace Samples

    Public Interface Book      ' Violates this rule

        ReadOnly Property Title() As String

        Sub Read()

    End Interface

End Namespace
'</Snippet1>

