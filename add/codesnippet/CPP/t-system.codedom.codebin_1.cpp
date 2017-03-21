         // This CodeBinaryOperatorExpression represents the addition of 1 and 2.
         
         // Right operand.
         CodeBinaryOperatorExpression^ addMethod = gcnew CodeBinaryOperatorExpression( gcnew CodePrimitiveExpression( 1 ),CodeBinaryOperatorType::Add,gcnew CodePrimitiveExpression( 2 ) );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // (1 + 2)        