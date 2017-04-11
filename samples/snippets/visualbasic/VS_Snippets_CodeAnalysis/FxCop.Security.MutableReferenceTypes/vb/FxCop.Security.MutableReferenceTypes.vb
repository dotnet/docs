'<Snippet1>
Imports System
Imports System.Text

Namespace SecurityLibrary

    Public Class MutableReferenceTypes

        Shared Protected ReadOnly SomeStringBuilder As StringBuilder

        Shared Sub New()
            SomeStringBuilder = New StringBuilder()
        End Sub

    End Class

End Namespace
'</Snippet1>
