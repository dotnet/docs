            ' Invokes the TestMethod method of the current type object.
            Dim methodRef1 As New CodeMethodReferenceExpression(New CodeThisReferenceExpression(), "TestMethod")
            Dim invoke1 As New CodeMethodInvokeExpression(methodRef1, New CodeParameterDeclarationExpression() {})

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me.TestMethod
