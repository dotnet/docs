            CodePropertyReferenceExpression propertyRef1 = 
                new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "TestProperty");
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    this.TestProperty