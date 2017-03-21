            System.CodeDom.CodeIndexerExpression indexerExpression = new CodeIndexerExpression( new CodeThisReferenceExpression(), new CodePrimitiveExpression(1) );

            // A C# code generator produces the following source code for the preceeding example code:
            
            //        this[1];        