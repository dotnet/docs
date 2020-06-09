'<Snippet1>
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Text.RegularExpressions

Class Program
    Private Shared providerName As String = "vb"
    Private Shared sourceFileName As String = "test.vb"

    Shared Sub Main(ByVal args() As String)
        Dim provider As CodeDomProvider = _
            CodeDomProvider.CreateProvider(providerName)

        LogMessage("Building CodeDOM graph...")

        Dim cu As New CodeCompileUnit()

        cu = BuildHelloWorldGraph()

        '<Snippet5>
        Dim sourceFile As New StreamWriter(sourceFileName)

        LogMessage("Generating code...")
        provider.GenerateCodeFromCompileUnit(cu, sourceFile, Nothing)
        sourceFile.Close()
        '</Snippet5>

        '<Snippet6>
        Dim opt As New CompilerParameters(New String() {"System.dll"})
        opt.GenerateExecutable = True
        opt.OutputAssembly = "HelloWorld.exe"
        opt.TreatWarningsAsErrors = True
        opt.IncludeDebugInformation = True
        opt.GenerateInMemory = True
        opt.CompilerOptions = "/doc"

        Dim results As CompilerResults

        LogMessage(("Compiling with " & providerName))
        results = provider.CompileAssemblyFromFile(opt, sourceFileName)
        '</Snippet6>

        OutputResults(results)
        If results.NativeCompilerReturnValue <> 0 Then
            LogMessage("")
            LogMessage("Compilation failed.")
        Else
            LogMessage("")
            LogMessage("Demo completed successfully.")
        End If
        File.Delete(sourceFileName)

    End Sub

    '<Snippet2>
    ' Build a Hello World program graph using System.CodeDom types.
    Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit
        ' Create a new CodeCompileUnit to contain 
        ' the program graph.
        Dim compileUnit As New CodeCompileUnit()

        ' Declare a new namespace called Samples.
        Dim samples As New CodeNamespace("Samples")
        ' Add the new namespace to the compile unit.
        compileUnit.Namespaces.Add(samples)

        ' Add the new namespace import for the System namespace.
        samples.Imports.Add(New CodeNamespaceImport("System"))

        ' Declare a new type called Class1.
        '<Snippet4>
        Dim class1 As New CodeTypeDeclaration("Class1")

        class1.Comments.Add(New CodeCommentStatement("<summary>", True))
        class1.Comments.Add(New CodeCommentStatement( _
            "Create a Hello World application.", True))
        class1.Comments.Add(New CodeCommentStatement("</summary>", True))
        class1.Comments.Add(New CodeCommentStatement( _
            "<seealso cref=" & ControlChars.Quote & "Class1.Main" & _
            ControlChars.Quote & "/>", True))

        ' Add the new type to the namespace type collection.
        samples.Types.Add(class1)

        '<Snippet3>
        ' Declare a new code entry point method.
        Dim start As New CodeEntryPointMethod()
        start.Comments.Add(New CodeCommentStatement("<summary>", True))
        start.Comments.Add(New CodeCommentStatement( _
            "Main method for HelloWorld application.", True))
        start.Comments.Add(New CodeCommentStatement( _
            "<para>Add a new paragraph to the description.</para>", True))
        start.Comments.Add(New CodeCommentStatement("</summary>", True))
        '</Snippet3>
        '</Snippet4>
        ' Create a type reference for the System.Console class.
        Dim csSystemConsoleType As New CodeTypeReferenceExpression( _
            "System.Console")

        ' Build a Console.WriteLine statement.
        Dim cs1 As New CodeMethodInvokeExpression(csSystemConsoleType, _
            "WriteLine", New CodePrimitiveExpression("Hello World!"))

        ' Add the WriteLine call to the statement collection.
        start.Statements.Add(cs1)

        ' Build another Console.WriteLine statement.
        Dim cs2 As New CodeMethodInvokeExpression(csSystemConsoleType, _
            "WriteLine", New CodePrimitiveExpression( _
            "Press the ENTER key to continue."))

        ' Add the WriteLine call to the statement collection.
        start.Statements.Add(cs2)

        ' Build a call to System.Console.ReadLine.
        Dim csReadLine As New CodeMethodInvokeExpression( _
            csSystemConsoleType, "ReadLine")

        ' Add the ReadLine statement.
        start.Statements.Add(csReadLine)

        ' Add the code entry point method to
        ' the Members collection of the type.
        class1.Members.Add(start)

        Return compileUnit

    End Function 'BuildHelloWorldGraph

    '</Snippet2>
    Shared Sub LogMessage(ByVal [text] As String)
        Console.WriteLine([text])

    End Sub

    Shared Sub OutputResults(ByVal results As CompilerResults)
        LogMessage(("NativeCompilerReturnValue=" & _
            results.NativeCompilerReturnValue.ToString()))
        Dim s As String
        For Each s In results.Output
            LogMessage(s)
        Next s

    End Sub
End Class
'</Snippet1>
