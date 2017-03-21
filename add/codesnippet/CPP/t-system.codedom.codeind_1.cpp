      array<CodePrimitiveExpression^>^temp1 = {gcnew CodePrimitiveExpression( 1 )};
      System::CodeDom::CodeIndexerExpression^ indexerExpression = gcnew CodeIndexerExpression( gcnew CodeThisReferenceExpression,temp1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this[1];