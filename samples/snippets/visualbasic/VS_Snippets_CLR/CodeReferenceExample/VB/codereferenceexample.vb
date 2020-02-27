'<Snippet1>
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeReferenceExample

        Public Sub New()
        End Sub

        Public Sub CodeFieldReferenceExample()
            '<Snippet2>
            Dim fieldRef1 As New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "TestField")
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	Me.TestField
            '</Snippet2>
        End Sub

        Public Sub CodePropertyReferenceExample()
            '<Snippet3>
            Dim propertyRef1 As New CodePropertyReferenceExpression(New CodeThisReferenceExpression(), "TestProperty")
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	Me.TestProperty
            '</Snippet3>
        End Sub

        Public Sub CodeVariableReferenceExample()
            '<Snippet4>
            Dim variableRef1 As New CodeVariableReferenceExpression("TestVariable")
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	TestVariable
            '</Snippet4>
        End Sub

    End Class
End Namespace 'CodeDomSamples 
'</Snippet1>