//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeIterationStatementExample
    {
        public CodeIterationStatementExample()
        {
            //<Snippet2>
            // Declares and initializes an integer variable named testInt.
            CodeVariableDeclarationStatement testInt = new CodeVariableDeclarationStatement(typeof(int), "testInt", new CodePrimitiveExpression(0) );

            // Creates a for loop that sets testInt to 0 and continues incrementing testInt by 1 each loop until testInt is not less than 10.
            CodeIterationStatement forLoop = new CodeIterationStatement(
                // initStatement parameter for pre-loop initialization.
                new CodeAssignStatement( new CodeVariableReferenceExpression("testInt"), new CodePrimitiveExpression(1) ),
                // testExpression parameter to test for continuation condition.
                new CodeBinaryOperatorExpression( new CodeVariableReferenceExpression("testInt"), 
                    CodeBinaryOperatorType.LessThan, new CodePrimitiveExpression(10) ),
                // incrementStatement parameter indicates statement to execute after each iteration.
                new CodeAssignStatement( new CodeVariableReferenceExpression("testInt"), new CodeBinaryOperatorExpression( 
                    new CodeVariableReferenceExpression("testInt"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1) )),
                // statements parameter contains the statements to execute during each interation of the loop.
                // Each loop iteration the value of the integer is output using the Console.WriteLine method.
                new CodeStatement[] { new CodeExpressionStatement( new CodeMethodInvokeExpression( new CodeMethodReferenceExpression( 
                    new CodeTypeReferenceExpression("Console"), "WriteLine" ), new CodeMethodInvokeExpression( 
                    new CodeVariableReferenceExpression("testInt"), "ToString" ) ) ) } );

            // A C# code generator produces the following source code for the preceeding example code:

            //     int testInt = 0;
            //     for (testInt = 1; (testInt < 10); testInt = (testInt + 1)) {
            //        Console.WriteLine(testInt.ToString());
            //</Snippet2>
        }
    }
}
//</Snippet1>