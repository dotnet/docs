
      // Create an array indexer expression that references index 5 of array "x"
      array<CodeExpression^>^temp = {gcnew CodePrimitiveExpression( 5 )};
      CodeArrayIndexerExpression^ ci1 = gcnew CodeArrayIndexerExpression( gcnew CodeVariableReferenceExpression( "x" ),temp );

      // A C# code generator produces the following source code for the preceeding example code:
      // x[5]