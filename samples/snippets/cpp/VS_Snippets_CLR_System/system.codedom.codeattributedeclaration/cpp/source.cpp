// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

int main()
{
    // Declare a new type called Class1.
    CodeTypeDeclaration^ class1 = gcnew CodeTypeDeclaration("Class1");

    // Declare a new code attribute
    CodeAttributeDeclaration^ codeAttrDecl = gcnew CodeAttributeDeclaration(
        "System.CLSCompliantAttribute",
        gcnew CodeAttributeArgument(gcnew CodePrimitiveExpression(false)));
    class1->CustomAttributes->Add(codeAttrDecl);

    // Create a C# code provider
    CodeDomProvider^ provider = CodeDomProvider::CreateProvider("CSharp");

    // Generate code and send the output to the console
    provider->GenerateCodeFromType(class1, Console::Out, gcnew CodeGeneratorOptions());
}

// The CPP code generator produces the following source code for the preceeding example code:
//
//[System.CLSCompliantAttribute(false)]
//public class Class1 {
//}
// </Snippet1>