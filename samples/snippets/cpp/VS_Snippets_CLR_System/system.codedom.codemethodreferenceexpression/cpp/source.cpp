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

    // Declares a type constructor that calls a method.
    CodeConstructor^ constructor1 = gcnew CodeConstructor();
    constructor1->Attributes = MemberAttributes::Public;
    class1->Members->Add(constructor1);

    // Creates a method reference for dict.Init.
    CodeMethodReferenceExpression^ methodRef1 =
        gcnew CodeMethodReferenceExpression(
            gcnew CodeVariableReferenceExpression("dict"),
            "Init",
            gcnew array<CodeTypeReference^> {
                gcnew CodeTypeReference("System.Decimal"),
                gcnew CodeTypeReference("System.Int32")});

    // Invokes the dict.Init method from the constructor.
    CodeMethodInvokeExpression^ invoke1 =
        gcnew CodeMethodInvokeExpression(methodRef1, gcnew array<CodeParameterDeclarationExpression^> {});
    constructor1->Statements->Add(invoke1);

    // Create a C# code provider
    CodeDomProvider^ provider = CodeDomProvider::CreateProvider("CSharp");

    // Generate code and send the output to the console
    provider->GenerateCodeFromType(class1, Console::Out, gcnew CodeGeneratorOptions());
}

// The CPP code generator produces the following source code for the preceeding example code:
//
//public class Class1 {
//
//     public Class1() {
//         dict.Init<decimal, int>();
//     }
// }
// </Snippet1>