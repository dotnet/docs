            // Create an array indexer expression that references index 5 of array "x"
            CodeArrayIndexerExpression ci1 = new CodeArrayIndexerExpression(new CodeVariableReferenceExpression("x"), new CodePrimitiveExpression(5));

            // A C# code generator produces the following source code for the preceeding example code:

            // x[5]