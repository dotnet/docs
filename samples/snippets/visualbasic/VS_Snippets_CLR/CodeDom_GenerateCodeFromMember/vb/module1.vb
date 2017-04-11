 '<Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Text.RegularExpressions



Class Program
    Private Shared providerName As String = "vb"
    Private Shared sourceFileName As String = "test.vb"
    Private Shared snippetMethod As CodeSnippetTypeMember
    
    Shared Sub Main(ByVal args() As String) 
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider(providerName)
        
        ' Create a code snippet to be used in the graph.
        GenCodeFromMember(provider, New CodeGeneratorOptions())
        
        LogMessage("Building CodeDOM graph...")
        
        Dim cu As New CodeCompileUnit()
        
        cu = BuildClass1()
        
        Dim sw As New StringWriter()
        
        LogMessage("Generating code...")
        provider.GenerateCodeFromCompileUnit(cu, sw, Nothing)
        
        Dim output As String = sw.ToString()
        
        LogMessage("Dumping source...")
        LogMessage(output)
        
        LogMessage("Writing source to file...")
        Dim s As Stream = File.Open(sourceFileName, FileMode.Create)
        Dim t As New StreamWriter(s)
        t.Write(output)
        t.Close()
        s.Close()
        
        Dim opt As New CompilerParameters(New String() {"System.dll"})
        opt.GenerateExecutable = False
        opt.OutputAssembly = "Sample.dll"
        
        Dim results As CompilerResults
        
        LogMessage(("Compiling with " + providerName))
        results = provider.CompileAssemblyFromFile(opt, sourceFileName)
        
        OutputResults(results)
        If results.NativeCompilerReturnValue <> 0 Then
            LogMessage("")
            LogMessage("Compilation failed.")
        Else
            LogMessage("")
            LogMessage("Demo completed successfully.")
        End If
        File.Delete(sourceFileName)
    
    End Sub 'Main
    
    
    '<Snippet2>
    ' Build a library program graph using 
    ' System.CodeDom types.
    Public Shared Function BuildClass1() As CodeCompileUnit 
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
        Dim class1 As New CodeTypeDeclaration("Class1")
        
        ' Add the new type to the namespace type collection.
        samples.Types.Add(class1)
        
        class1.Members.Add(snippetMethod)
        
        Return compileUnit
    
    End Function 'BuildClass1
    
    '</Snippet2>
    Shared Sub LogMessage(ByVal [text] As String) 
        Console.WriteLine([text])
    
    End Sub 'LogMessage
    
    
    Shared Sub OutputResults(ByVal results As CompilerResults) 
        LogMessage(("NativeCompilerReturnValue=" + results.NativeCompilerReturnValue.ToString()))
        Dim s As String
        For Each s In  results.Output
            LogMessage(s)
        Next s
    
    End Sub 'OutputResults
    
    '<Snippet3>
    Shared Sub GenCodeFromMember(ByVal provider As CodeDomProvider, ByVal options As CodeGeneratorOptions) 
        options.BracingStyle = "C"
        Dim method1 As New CodeMemberMethod()
        method1.Name = "ReturnString"
        method1.Attributes = MemberAttributes.Public
        method1.ReturnType = New CodeTypeReference("System.String")
        method1.Parameters.Add(New CodeParameterDeclarationExpression("System.String", "text"))
        method1.Statements.Add(New CodeMethodReturnStatement(New CodeArgumentReferenceExpression("text")))
        Dim sw As New StringWriter()
        provider.GenerateCodeFromMember(method1, sw, options)
        snippetMethod = New CodeSnippetTypeMember(sw.ToString())
    
    End Sub 'GenCodeFromMember
End Class 'Program 
'</Snippet3>
'</Snippet1>