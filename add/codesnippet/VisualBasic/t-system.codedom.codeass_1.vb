            ' Assigns the value 10 to the integer variable "i".
            Dim as1 As New CodeAssignStatement(New CodeVariableReferenceExpression("i"), New CodePrimitiveExpression(10))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' i = 10