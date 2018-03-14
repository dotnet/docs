'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodePrimitiveExpressionExample

        Public Sub New()
            '<Snippet2>
            ' Represents a string.
            Dim stringPrimitive As New CodePrimitiveExpression("Test String")
            ' Represents an integer.
            Dim intPrimitive As New CodePrimitiveExpression(10)
            ' Represents a floating point number.
            Dim floatPrimitive As New CodePrimitiveExpression(1.03189)
            ' Represents a null value expression.
            Dim nullPrimitive As New CodePrimitiveExpression(Nothing)
            '</Snippet2>

        End Sub 'New 
    End Class 'CodePrimitiveExpressionExample
End Namespace 'CodeDomSamples
'</Snippet1>