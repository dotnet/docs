            // Invokes the TestMethod method of the current type object.
            CodeMethodReferenceExpression methodRef1 = new CodeMethodReferenceExpression( new CodeThisReferenceExpression(), "TestMethod" );
            CodeMethodInvokeExpression invoke1 = new CodeMethodInvokeExpression( methodRef1, new CodeParameterDeclarationExpression[] {} );                                    

            // A C# code generator produces the following source code for the preceeding example code:

            //        this.TestMethod();
            