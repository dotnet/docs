            ' Create an array indexer expression that references index 5 of array "x"
            Dim ci1 As New CodeArrayIndexerExpression(New CodeVariableReferenceExpression("x"), New CodePrimitiveExpression(5))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' x[5]