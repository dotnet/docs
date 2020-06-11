' <snippet11>
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class UsingTheCodeDOM
    Public Shared Sub Main()
        ' <snippet12>
        Dim compileUnit As New CodeCompileUnit()
        ' </snippet12>

        ' <snippet13>
        Dim samples As New CodeNamespace("Samples")
        ' </snippet13>

        ' <snippet14>
        samples.Imports.Add(new CodeNamespaceImport("System"))
        ' </snippet14>

        ' <snippet15>
        compileUnit.Namespaces.Add(samples)
        ' </snippet15>

        ' <snippet16>
        Dim class1 As New CodeTypeDeclaration("Class1")
        ' </snippet16>

        ' <snippet17>
        samples.Types.Add(class1)
        ' </snippet17>

        ' <snippet18>
        Dim start As New CodeEntryPointMethod()
        Dim cs1 As New CodeMethodInvokeExpression( _
            New CodeTypeReferenceExpression("System.Console"), _
            "WriteLine", new CodePrimitiveExpression("Hello World!"))
        start.Statements.Add(cs1)
        ' </snippet18>

        ' <snippet19>
        class1.Members.Add(start)
        ' </snippet19>

        Dim codeProvider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")
        codeProvider.GenerateCodeFromCompileUnit(compileUnit, Console.Out, new CodeGeneratorOptions())
    End Sub
End Class
' </snippet11>
