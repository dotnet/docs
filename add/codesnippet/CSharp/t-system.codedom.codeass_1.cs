            // Assigns the value of the 10 to the integer variable "i".
            CodeAssignStatement as1 = new CodeAssignStatement(new CodeVariableReferenceExpression("i"), new CodePrimitiveExpression(10));
            
            // A C# code generator produces the following source code for the preceeding example code:

            // i=10;