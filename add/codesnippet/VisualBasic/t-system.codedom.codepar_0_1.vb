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