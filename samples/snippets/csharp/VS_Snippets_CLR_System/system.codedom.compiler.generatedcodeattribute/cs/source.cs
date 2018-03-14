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

        // Declare a new generated code attribute
        GeneratedCodeAttribute generatedCodeAttribute =
            new GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0");

        // Use the generated code attribute members in the attribute declaration
        CodeAttributeDeclaration codeAttrDecl =
            new CodeAttributeDeclaration(generatedCodeAttribute.GetType().Name,
                new CodeAttributeArgument(
                    new CodePrimitiveExpression(generatedCodeAttribute.Tool)),
                new CodeAttributeArgument(
                    new CodePrimitiveExpression(generatedCodeAttribute.Version)));
        class1.CustomAttributes.Add(codeAttrDecl);

        // Create a C# code provider
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

        // Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, new CodeGeneratorOptions());
    }
}

// The C# code generator produces the following source code for the preceeding example code:
//
// [GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0")]
// public class Class1 {
// }
// </Snippet1>