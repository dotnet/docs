      // Assigns the value of the 10 to the integer variable "i".
      CodeAssignStatement^ as1 = gcnew CodeAssignStatement( gcnew CodeVariableReferenceExpression( "i" ),gcnew CodePrimitiveExpression( 10 ) );

      // A C# code generator produces the following source code for the preceeding example code:
      // i=10;