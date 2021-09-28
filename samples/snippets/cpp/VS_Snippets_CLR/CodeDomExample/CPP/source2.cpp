// <snippet11>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

public ref class UsingTheCodeDOM
{
public:
    static void Main()
    {
        // <snippet12>
        CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit();
        // </snippet12>

        // <snippet13>
        CodeNamespace^ samples = gcnew CodeNamespace("Samples");
        // </snippet13>

        // <snippet14>
        samples->Imports->Add(gcnew CodeNamespaceImport("System"));
        // </snippet14>

        // <snippet15>
        compileUnit->Namespaces->Add( samples );
        // </snippet15>

        // <snippet16>
        CodeTypeDeclaration^ class1 = gcnew CodeTypeDeclaration("Class1");
        // </snippet16>

        // <snippet17>
        samples->Types->Add(class1);
        // </snippet17>

        // <snippet18>
        CodeEntryPointMethod^ start = gcnew CodeEntryPointMethod();
        CodeMethodInvokeExpression^ cs1 = gcnew CodeMethodInvokeExpression(
            gcnew CodeTypeReferenceExpression("System.Console"),
            "WriteLine", gcnew CodePrimitiveExpression("Hello World!"));
        start->Statements->Add(cs1);
        // </snippet18>

        // <snippet19>
        class1->Members->Add(start);
        // </snippet19>

        CodeDomProvider^ codeProvider = CodeDomProvider::CreateProvider("CSharp");
        codeProvider->GenerateCodeFromCompileUnit(compileUnit, Console::Out, gcnew CodeGeneratorOptions());
    }
};

int main()
{
    UsingTheCodeDOM::Main();
}
// </snippet11>
