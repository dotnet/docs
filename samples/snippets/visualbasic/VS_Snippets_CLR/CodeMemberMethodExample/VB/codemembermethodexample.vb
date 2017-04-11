'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeMemberMethodExample

        Public Sub New()
            '<Snippet2>
            ' Defines a method that returns a string passed to it.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "ReturnString"
            method1.ReturnType = New CodeTypeReference("System.String")
            method1.Parameters.Add(New CodeParameterDeclarationExpression("System.String", "text"))
            method1.Statements.Add(New CodeMethodReturnStatement(New CodeArgumentReferenceExpression("text")))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   Private Function ReturnString(ByVal [text] As String) As String
            '       Return [Text]
            '   End Function
            '</Snippet2>
        End Sub 'New 

    End Class 'CodeMemberMethodExample 
End Namespace 'CodeDomSamples
'</Snippet1>