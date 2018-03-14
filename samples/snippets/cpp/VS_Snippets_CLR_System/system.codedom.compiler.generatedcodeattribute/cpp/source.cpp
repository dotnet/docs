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

    // Declare a new generated code attribute
    GeneratedCodeAttribute^ generatedCodeAttribute =
        gcnew GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0");

    // Use the generated code attribute members in the attribute declaration
    CodeAttributeDeclaration^ codeAttrDecl =
        gcnew CodeAttributeDeclaration(generatedCodeAttribute->GetType()->Name,
            gcnew CodeAttributeArgument(
                gcnew CodePrimitiveExpression(generatedCodeAttribute->Tool)),
            gcnew CodeAttributeArgument(
                gcnew CodePrimitiveExpression(generatedCodeAttribute->Version)));
    class1->CustomAttributes->Add(codeAttrDecl);

    // Create a C# code provider
    CodeDomProvider^ provider = CodeDomProvider::CreateProvider("CSharp");

    // Generate code and send the output to the console
    provider->GenerateCodeFromType(class1, Console::Out, gcnew CodeGeneratorOptions());
}

// The CPP code generator produces the following source code for the preceeding example code:
//
// [GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0")]
// public class Class1 {
// }
// </Snippet1>