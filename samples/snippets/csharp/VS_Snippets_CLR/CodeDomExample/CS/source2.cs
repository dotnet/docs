// <snippet11>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;

public class UsingTheCodeDOM
{
    public static void Main()
    {
        // <snippet12>
        CodeCompileUnit compileUnit = new CodeCompileUnit();
        // </snippet12>

        // <snippet13>
        CodeNamespace samples = new CodeNamespace("Samples");
        // </snippet13>

        // <snippet14>
        samples.Imports.Add(new CodeNamespaceImport("System"));
        // </snippet14>

        // <snippet15>
        compileUnit.Namespaces.Add( samples );
        // </snippet15>

        // <snippet16>
        CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
        // </snippet16>

        // <snippet17>
        samples.Types.Add(class1);
        // </snippet17>

        // <snippet18>
        CodeEntryPointMethod start = new CodeEntryPointMethod();
        CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression("System.Console"),
            "WriteLine", new CodePrimitiveExpression("Hello World!"));
        start.Statements.Add(cs1);
        // </snippet18>

        // <snippet19>
        class1.Members.Add( start );
        // </snippet19>

        CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
        codeProvider.GenerateCodeFromCompileUnit(compileUnit, Console.Out, new CodeGeneratorOptions());
    }
}
// </snippet11>
