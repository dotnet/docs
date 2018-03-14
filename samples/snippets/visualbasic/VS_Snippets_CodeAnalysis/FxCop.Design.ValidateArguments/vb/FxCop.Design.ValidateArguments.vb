'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class Test

        ' This method violates the rule.
        Sub DoNotValidate(ByVal input As String)

            If input.Length <> 0 Then
                Console.WriteLine(input)
            End If

        End Sub

        ' This method satisfies the rule.
        Sub Validate(ByVal input As String)

            If input Is Nothing Then
                Throw New ArgumentNullException("input")
            End If

            If input.Length <> 0 Then
                Console.WriteLine(input)
            End If

        End Sub

    End Class

End Namespace
'</Snippet1>

Public Class SnippetClass
    '<Snippet2>
    Public Function Method(ByVal value As String) As String
        EnsureNotNull(value)

        ' Fires incorrectly    
        Return value.ToString()
    End Function

    Private Sub EnsureNotNull(ByVal value As String)
        If value Is Nothing Then
            Throw (New ArgumentNullException("value"))
        End If
    End Sub
    '</Snippet2>


    '<Snippet3>
    Public Function Method(ByVal value1 As String, ByVal value2 As String) As String
        If value1 Is Nothing OrElse value2 Is Nothing Then
            Throw New ArgumentNullException()
        End If

        ' Fires incorrectly    
        Return value1.ToString() + value2.ToString()

    End Function
    '</Snippet3>
End Class