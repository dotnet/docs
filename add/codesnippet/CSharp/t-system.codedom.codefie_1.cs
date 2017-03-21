            CodeFieldReferenceExpression fieldRef1 = 
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "TestField");

            // A C# code generator produces the following source code for the preceeding example code:
            
            //    this.TestField