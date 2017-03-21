            ' Declares a parameter passed by reference using a CodeDirectionExpression.
            Dim param1 As New CodeDirectionExpression(FieldDirection.Ref, New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "TestParameter"))
            ' Invokes a method on this named TestMethod using the direction expression as a parameter.
            Dim methodInvoke1 As New CodeMethodInvokeExpression(New CodeThisReferenceExpression(), "TestMethod", param1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:	

            '      Me.TestMethod("TestParameter")