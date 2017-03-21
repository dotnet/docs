         // This CodeCastExpression casts an Int32 of 1000 to an Int64.        
         
         // targetType parameter indicating the target type of the cast.
         // The CodeExpression to cast, here an Int32 value of 1000.
         CodeCastExpression^ castExpression = gcnew CodeCastExpression( "System.Int64",gcnew CodePrimitiveExpression( 1000 ) );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // ((long)(1000));