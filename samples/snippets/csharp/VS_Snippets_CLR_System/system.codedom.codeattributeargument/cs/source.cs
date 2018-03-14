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

        // Use attributes to mark the class as serializable and obsolete.
        CodeAttributeDeclaration codeAttrDecl =
            new CodeAttributeDeclaration("System.Serializable");
        class1.CustomAttributes.Add(codeAttrDecl);

        CodeAttributeArgument codeAttr =
            new CodeAttributeArgument( new CodePrimitiveExpression("This class is obsolete."));
        codeAttrDecl = new CodeAttributeDeclaration("System.Obsolete", codeAttr);
        class1.CustomAttributes.Add(codeAttrDecl);

        // Create a C# code provider
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

        // Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, new CodeGeneratorOptions());
    }
}

// The C# code generator produces the following source code for the preceeding example code:
//
// [System.Serializable()]
// [System.Obsolete("This class is obsolete.")]
// public class Class1 {
// }
// </Snippet1>