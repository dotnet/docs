         ' This CodeBinaryOperatorExpression represents the addition of 1 and 2.
         Dim addMethod As New CodeBinaryOperatorExpression( _
            New CodePrimitiveExpression(1), _         
            CodeBinaryOperatorType.Add, _            
            New CodePrimitiveExpression(2) )        

         ' A Visual Basic code generator produces the following source code for the preceeding example code:	

         ' (1 + 2)
