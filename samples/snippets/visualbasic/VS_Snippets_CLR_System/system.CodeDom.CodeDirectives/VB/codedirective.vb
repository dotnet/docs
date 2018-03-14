' Demonstrate the use of classed derived from CodeDirective.
'<Snippet1>
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Globalization


Class CodeDirectiveDemo

    Shared Sub Main()
        Try
            DemonstrateCodeDirectives("vb", "ChecksumPragma.vb", "ChecksumPragmaVB.exe")
        Catch e As Exception
            Console.WriteLine(("Unexpected exception:" + e.ToString()))
        End Try

    End Sub 'Main


    ' Create and compile code containing code directives.
    Shared Sub DemonstrateCodeDirectives(ByVal providerName As String, ByVal sourceFileName As String, ByVal assemblyName As String)

        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider(providerName)
        
        Console.WriteLine("Building the CodeDOM graph...")
        Dim cu As New CodeCompileUnit()
        CreateGraph(cu)

        Dim sw As New StringWriter()

        Console.WriteLine("Generating code...")
        provider.GenerateCodeFromCompileUnit(cu, sw, Nothing)
        Dim output As String = sw.ToString()
        output = Regex.Replace(output, "Runtime version:[^" + vbCr + vbLf + "]*", "Runtime version omitted for this demo")

        Console.WriteLine("Dumping source code...")
        Console.WriteLine(output)

        Console.WriteLine("Writing source code to file...")
        Dim s As Stream = File.Open(sourceFileName, FileMode.Create)
        Dim t As New StreamWriter(s)
        t.Write(output)
        t.Close()
        s.Close()

        Dim opt As New CompilerParameters(New String() {"System.dll", "System.Xml.dll", "System.Windows.Forms.dll", "System.Data.dll", "System.Drawing.dll"})
        opt.GenerateExecutable = False
        opt.TreatWarningsAsErrors = True
        opt.IncludeDebugInformation = True
        opt.GenerateInMemory = True

        Dim results As CompilerResults

        Console.WriteLine(("Compiling with " + providerName))
        results = provider.CompileAssemblyFromFile(opt, sourceFileName)

        OutputResults(results)
        If results.NativeCompilerReturnValue <> 0 Then
            Console.WriteLine("")
            Console.WriteLine("Compilation failed.")
        Else
            Console.WriteLine("")
            Console.WriteLine("Demo completed successfully.")
        End If
        File.Delete(sourceFileName)

    End Sub 'DemonstrateCodeDirectives

    Private Shared HashMD5 As New Guid(&H406EA660, &H64CF, &H4C82, &HB6, &HF0, &H42, &HD4, &H81, &H72, &HA7, &H99)
    Private Shared HashSHA1 As New Guid(&HFF1816EC, &H65FF, &H4D10, &H87, &HF7, &H6F, &H49, &H63, &H83, &H34, &H60)

    ' Create a CodeDOM graph.
    Shared Sub CreateGraph(ByVal cu As CodeCompileUnit)  'ICodeGenerator generator, 
        '<Snippet2>
        cu.StartDirectives.Add(New CodeRegionDirective(CodeRegionMode.Start, "Compile Unit Region"))
        '</Snippet2>
        '<Snippet3>
        cu.EndDirectives.Add(New CodeRegionDirective(CodeRegionMode.End, String.Empty))
        '</Snippet3>
        '<Snippet4>
        Dim pragma1 As New CodeChecksumPragma()
        '</Snippet4>
        '<Snippet5>
        pragma1.FileName = "c:\temp\test\OuterLinePragma.txt"
        '</Snippet5>
        '<Snippet6>
        pragma1.ChecksumAlgorithmId = HashMD5
        '</Snippet6>
        '<Snippet7>
        pragma1.ChecksumData = New Byte() {&HAA, &HAA}
        '</Snippet7>
        cu.StartDirectives.Add(pragma1)
        '<Snippet8>
        Dim pragma2 As New CodeChecksumPragma("test.txt", HashSHA1, New Byte() {&HBB, &HBB, &HBB})
        '</Snippet8>
        cu.StartDirectives.Add(pragma2)

        Dim ns As New CodeNamespace("Namespace1")
        ns.Imports.Add(New CodeNamespaceImport("System"))
        ns.Imports.Add(New CodeNamespaceImport("System.IO"))
        cu.Namespaces.Add(ns)
        ns.Comments.Add(New CodeCommentStatement("Namespace Comment"))
        Dim cd As New CodeTypeDeclaration("Class1")
        ns.Types.Add(cd)

        cd.Comments.Add(New CodeCommentStatement("Outer Type Comment"))
        cd.LinePragma = New CodeLinePragma("c:\temp\test\OuterLinePragma.txt", 300)

        Dim method1 As New CodeMemberMethod()
        method1.Name = "Method1"
        method1.Attributes = method1.Attributes And Not MemberAttributes.AccessMask Or MemberAttributes.Public


        Dim method2 As New CodeMemberMethod()
        method2.Name = "Method2"
        method2.Attributes = method2.Attributes And Not MemberAttributes.AccessMask Or MemberAttributes.Public
        method2.Comments.Add(New CodeCommentStatement("Method2 Comment"))

        cd.Members.Add(method1)
        cd.Members.Add(method2)

        cd.StartDirectives.Add(New CodeRegionDirective(CodeRegionMode.Start, "Outer Type Region"))

        cd.EndDirectives.Add(New CodeRegionDirective(CodeRegionMode.End, String.Empty))

        Dim field1 As New CodeMemberField(GetType(String), "field1")
        cd.Members.Add(field1)
        field1.Comments.Add(New CodeCommentStatement("Field1 Comment"))

        '<Snippet9>
        Dim codeRegionDirective1 As New CodeRegionDirective(CodeRegionMode.Start, "Field Region")
        '</Snippet9>
        '<Snippet10>
        field1.StartDirectives.Add(codeRegionDirective1)
        '</Snippet10>
        Dim codeRegionDirective2 As New CodeRegionDirective(CodeRegionMode.End, "")
        '<Snippet11>
        codeRegionDirective2.RegionMode = CodeRegionMode.End
        '</Snippet11>
        '<Snippet12>
        codeRegionDirective2.RegionText = String.Empty
        '</Snippet12>
        '<Snippet13>
        field1.EndDirectives.Add(codeRegionDirective2)
        '</Snippet13>
        '<Snippet16>
        Dim snippet1 As New CodeSnippetStatement()
        snippet1.Value = "            Console.WriteLine(field1)"

        Dim regionStart As New CodeRegionDirective(CodeRegionMode.End, "")
        regionStart.RegionText = "Snippet Region"
        regionStart.RegionMode = CodeRegionMode.Start
        snippet1.StartDirectives.Add(regionStart)
        snippet1.EndDirectives.Add(New CodeRegionDirective(CodeRegionMode.End, String.Empty))
        '</Snippet16>

        ' CodeStatement example
        Dim constructor1 As New CodeConstructor()
        constructor1.Attributes = constructor1.Attributes And Not MemberAttributes.AccessMask _
            Or MemberAttributes.Public
        Dim codeAssignStatement1 As New CodeAssignStatement( _
             New CodeFieldReferenceExpression( _
             New CodeThisReferenceExpression(), "field1"), _
             New CodePrimitiveExpression("value1"))
        '<Snippet14>
        codeAssignStatement1.StartDirectives.Add(New CodeRegionDirective(CodeRegionMode.Start, "Statements Region"))
        '</Snippet14>
        cd.Members.Add(constructor1)
        '<Snippet15>
        codeAssignStatement1.EndDirectives.Add(New CodeRegionDirective(CodeRegionMode.End, String.Empty))
        '</Snippet15>
        method2.Statements.Add(codeAssignStatement1)
        method2.Statements.Add(snippet1)

    End Sub 'CreateGraph

    Shared Sub OutputResults(ByVal results As CompilerResults)
        Console.WriteLine(("NativeCompilerReturnValue=" + results.NativeCompilerReturnValue.ToString()))
        Dim s As String
        For Each s In results.Output
            Console.WriteLine(s)
        Next s

    End Sub 'OutputResults
End Class 'CodeDirectiveDemo 
'</Snippet1>