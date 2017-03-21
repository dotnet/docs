            // Creates a code expression for a CodeExpressionStatement to contain.
            CodeExpression invokeExpression = new CodeMethodInvokeExpression( 
                new CodeTypeReferenceExpression("Console"), 
                "Write", new CodePrimitiveExpression("Example string") );

            // Creates a statement using a code expression.
            CodeExpressionStatement expressionStatement;
            expressionStatement = new CodeExpressionStatement( invokeExpression );                        

            // A C# code generator produces the following source code for the preceeding example code:

            // Console.Write( "Example string" );