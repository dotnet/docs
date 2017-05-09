'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeParameterDeclarationExample

        Public Sub New()
            '<Snippet2>			
            ' Declares a new type to contain the example methods.
            Dim type1 As New CodeTypeDeclaration("Type1")

            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            '<Snippet3>
            ' Declares a method.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "TestMethod"

            ' Declares a string parameter passed by reference.
            Dim param1 As New CodeParameterDeclarationExpression("System.String", "stringParam")
            param1.Direction = FieldDirection.Ref
            method1.Parameters.Add(param1)

            ' Declares a Int32 parameter passed by incoming field.
            Dim param2 As New CodeParameterDeclarationExpression("System.Int32", "intParam")
            param2.Direction = FieldDirection.Out
            method1.Parameters.Add(param2)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:
 
            '	 Private Sub TestMethod(ByRef stringParam As String, ByRef intParam As Integer)
            '    End Sub
            '</Snippet3>

            type1.Members.Add(method1)
            '</Snippet2>

        End Sub 'New 
    End Class 'CodeParameterDeclarationExample
End Namespace 'CodeDomSamples
'</Snippet1>