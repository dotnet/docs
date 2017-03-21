            CodeMethodInvokeExpression methodInvoke = new CodeMethodInvokeExpression(
                // targetObject that contains the method to invoke.
                new CodeThisReferenceExpression(),
                // methodName indicates the method to invoke.
                "Dispose",
                // parameters array contains the parameters for the method.
                new CodeExpression[] { new CodePrimitiveExpression(true) } );

            // A C# code generator produces the following source code for the preceeding example code:

            // this.Dispose(true);