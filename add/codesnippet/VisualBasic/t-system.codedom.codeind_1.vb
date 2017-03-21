            Dim indexerExpression = New CodeIndexerExpression(New CodeThisReferenceExpression(), New CodePrimitiveExpression(1))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me(1)            		