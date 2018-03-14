'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeMemberFieldExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain a field and a constructor method.
            Dim type1 As New CodeTypeDeclaration("FieldTest")

            ' Declares a field of type String named testStringField.
            Dim field1 As New CodeMemberField("System.String", "testStringField")
            type1.Members.Add(field1)

            ' Declares an empty type constructor.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' Public Class FieldTest
            '
            '     Private TestStringField As String
            '
            '     Public Sub New()
            '         MyBase.New()
            '     End Sub
            '
            ' End Class

            '</Snippet2>
        End Sub 'New 
    End Class 'CodeMemberFieldExample 
End Namespace 'CodeDomSamples
'</Snippet1>