// <Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;

public class CodeGenExample
{
    static void Main()
    {
        // Declare a new type called Class1.
        CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");

        // Declares a type constructor that calls a method.
        CodeConstructor constructor1 = new CodeConstructor();
        constructor1.Attributes = MemberAttributes.Public;
        class1.Members.Add( constructor1 );

        // Creates a method reference for dict.Init.
        CodeMethodReferenceExpression methodRef1 =
            new CodeMethodReferenceExpression(
                new CodeVariableReferenceExpression("dict"),
                "Init",
                new CodeTypeReference[] {
                    new CodeTypeReference("System.Decimal"),
                    new CodeTypeReference("System.Int32")});

        // Invokes the dict.Init method from the constructor.
        CodeMethodInvokeExpression invoke1 = new CodeMethodInvokeExpression( methodRef1, new CodeParameterDeclarationExpression[] {} );
        constructor1.Statements.Add( invoke1 );

        // Create a C# code provider
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

        // Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, new CodeGeneratorOptions());
    }
}

// The C# code generator produces the following source code for the preceeding example code:
//
// public class Class1 {
//
//     public Class1() {
//         dict.Init<decimal, int>();
//     }
// }
// </Snippet1>