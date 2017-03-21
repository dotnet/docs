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
