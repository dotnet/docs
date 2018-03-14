//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{

    public class CodeGotoStatementExample
    {
        public CodeGotoStatementExample()
        {
            //<Snippet2>
            // Declares a type to contain the example code.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("Type1");            
            // Declares an entry point method.
            CodeEntryPointMethod entry1 = new CodeEntryPointMethod();                        
            type1.Members.Add( entry1 );
            // Adds a goto statement to continue program flow at the "JumpToLabel" label.
            CodeGotoStatement goto1 = new CodeGotoStatement("JumpToLabel");
            entry1.Statements.Add( goto1 );
            // Invokes Console.WriteLine to print "Test Output", which is skipped by the goto statement.
            CodeMethodInvokeExpression method1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"), "WriteLine", new CodePrimitiveExpression("Test Output."));
            entry1.Statements.Add( method1 );
            // Declares a label named "JumpToLabel" associated with a method to output a test string using Console.WriteLine.
            CodeMethodInvokeExpression method2 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"), "WriteLine", new CodePrimitiveExpression("Output from labeled statement."));
            CodeLabeledStatement label1 = new CodeLabeledStatement("JumpToLabel", new CodeExpressionStatement(method2) );
            entry1.Statements.Add( label1 );

            // A C# code generator produces the following source code for the preceeding example code:

            //    public class Type1 
            //    {
            //        
            //        public static void Main() 
            //        {
            //            goto JumpToLabel;
            //            System.Console.WriteLine("Test Output");
            //            JumpToLabel:
            //            System.Console.WriteLine("Output from labeled statement.");
            //        }
            //    }
            //</Snippet2>
        }
    }
}
//</Snippet1>