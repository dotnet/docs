'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeMemberPropertyExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain a field and a constructor method.
            Dim type1 As New CodeTypeDeclaration("PropertyTest")

            ' Declares a field of type String named testStringField.
            Dim field1 As New CodeMemberField("System.String", "testStringField")
            type1.Members.Add(field1)

            ' Declares a property of type String named StringProperty.
            Dim property1 As New CodeMemberProperty()
            property1.Name = "StringProperty"
            property1.Type = New CodeTypeReference("System.String")
            property1.Attributes = MemberAttributes.Public
            property1.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "testStringField")))
            property1.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "testStringField"), New CodePropertySetValueReferenceExpression()))
            type1.Members.Add(property1)

            ' Declares an empty type constructor.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' Public Class PropertyTest
            '
            '     Private testStringField As String
            '
            '     Public Sub New()
            '         MyBase.New()
            '     End Sub
            '
            '     Public Overridable Property StringProperty() As String
            '         Get
            '             Return Me.testStringField
            '         End Get
            '         Set(ByVal Value As String)
            '             Me.testStringField = value
            '         End Set
            '     End Property
            ' End Class
            '</Snippet2>
        End Sub 'New

        Public Sub SpecificExample()
            '<Snippet3>			
            ' Declares a property of type String named StringProperty.
            Dim property1 As New CodeMemberProperty()
            property1.Name = "StringProperty"
            property1.Type = New CodeTypeReference("System.String")
            property1.Attributes = MemberAttributes.Public
            property1.GetStatements.Add(New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "testStringField")))
            property1.SetStatements.Add(New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "testStringField"), New CodePropertySetValueReferenceExpression()))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '     Public Overridable Property StringProperty() As String
            '         Get
            '             Return Me.testStringField
            '         End Get
            '         Set(ByVal Value As String)
            '             Me.testStringField = value
            '         End Set
            '     End Property

            '</Snippet3>
        End Sub 'SpecificExample 

    End Class 'CodeMemberPropertyExample
End Namespace 'CodeDomSamples
'</Snippet1>