'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodePropertySetValueExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type.
            Dim type1 As New CodeTypeDeclaration("Type1")

            ' Declares a constructor.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' Declares an integer field.
            Dim field1 As New CodeMemberField("System.Int32", "integerField")
            type1.Members.Add(field1)

            ' Declares a property.
            Dim property1 As New CodeMemberProperty()
            ' Declares a property get statement to return the value of the integer field.
            property1.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "integerField")))
            ' Declares a property set statement to set the value to the integer field.
            ' The CodePropertySetValueReferenceExpression represents the value argument passed to the property set statement.
            property1.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "integerField"), New CodePropertySetValueReferenceExpression()))
            type1.Members.Add(property1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   Public Class Type1
            '
            '       Private integerField As Integer
            '
            '       Public Sub New()
            '           MyBase.New()
            '       End Sub
            '
            '       Private Property integerProperty() As Integer
            '           Get
            '               Return Me.integerField
            '           End Get
            '           Set(ByVal Value As Integer)
            '               Me.integerField = value
            '           End Set
            '       End Property
            '   End Class
            '</Snippet2>

        End Sub 'New 
    End Class 'CodePropertySetValueExample 
End Namespace 'CodeDomSamples
'</Snippet1>