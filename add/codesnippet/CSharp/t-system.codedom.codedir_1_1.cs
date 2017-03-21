            // Declares a parameter passed by reference using a CodeDirectionExpression.
            CodeDirectionExpression param1 = new CodeDirectionExpression(FieldDirection.Ref, new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), "TestParameter" ));
            // Invokes a method on this named TestMethod using the direction expression as a parameter.
            CodeMethodInvokeExpression methodInvoke1 = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "TestMethod", param1 );
            
            // A C# code generator produces the following source code for the preceeding example code:    
            
            //        this.TestMethod(ref TestParameter);