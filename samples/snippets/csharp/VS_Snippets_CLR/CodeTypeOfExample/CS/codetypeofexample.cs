//<Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace CodeDomSamples
{
    public class CodeTypeOfExample
    {
        public static void Main()
        {
            ShowTypeReference();
            Console.WriteLine();
            ShowTypeReferenceExpression();
        }

        public static void ShowTypeReference()
        {
            //<Snippet2>
            // Creates a reference to the System.DateTime type.
            CodeTypeReference typeRef1 = new CodeTypeReference("System.DateTime");

            // Creates a typeof expression for the specified type reference.
            CodeTypeOfExpression typeof1 = new CodeTypeOfExpression(typeRef1);

            // Create a C# code provider
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            // Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeof1, Console.Out, new CodeGeneratorOptions());
            // The code generator produces the following source code for the preceeding example code:
            //    typeof(System.DateTime)
            //</Snippet2>
        }

        public static void ShowTypeReferenceExpression()
        {
            //<Snippet3>
            // Creates an expression referencing the System.DateTime type.
            CodeTypeReferenceExpression typeRef1 = new CodeTypeReferenceExpression("System.DateTime");

            // Create a C# code provider
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            // Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeRef1, Console.Out, new CodeGeneratorOptions());
            // The code generator produces the following source code for the preceeding example code:

            //    System.DateTime

            //</Snippet3>
        }
    }
}
//</Snippet1>