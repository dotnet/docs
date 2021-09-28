' <Snippet11>
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.IO
Imports Microsoft.CSharp

Public Class CodeDOMSample
    Public Shared Sub Main()
        Dim sourceFile As String
        Dim dotSpot As Integer

        Dim cu As New CodeCompileUnit()
        sourceFile = GenerateCSharpCode(cu)
        Console.WriteLine("CS source file: {0}", sourceFile)
        dotSpot = sourceFile.IndexOf(".")
        CompileCSharpCode(sourceFile, sourceFile.Substring(0, dotSpot) + ".exe")
    End Sub

    ' <snippet13>
    Public Shared Function GenerateCSharpCode(compileunit As CodeCompileUnit) As String
        ' Generate the code with the C# code provider.
        ' <snippet12>
        Dim provider As New CSharpCodeProvider()
        ' </snippet12>

        ' Build the output file name.
        Dim sourceFile As String
        If provider.FileExtension(0) = "." Then
            sourceFile = "HelloWorld" + provider.FileExtension
        Else
            sourceFile = "HelloWorld." + provider.FileExtension
        End If

        ' Create a TextWriter to a StreamWriter to the output file.
        Dim tw As new IndentedTextWriter( _
                New StreamWriter(sourceFile, False), "    ")

        ' Generate source code using the code provider.
        provider.GenerateCodeFromCompileUnit(compileunit, tw, _
               New CodeGeneratorOptions())

        ' Close the output file.
        tw.Close()

        Return sourceFile
    End Function
    ' </snippet13>

    ' <snippet14>
    Public Shared Function CompileCSharpCode(sourceFile As String, _
         exeFile As String) As Boolean
        Dim provider As New CSharpCodeProvider()

        ' Build the parameters for source compilation.
        Dim cp As New CompilerParameters()

        ' Add an assembly reference.
        cp.ReferencedAssemblies.Add("System.dll")

        ' Generate an executable instead of
        ' a class library.
        cp.GenerateExecutable = true

        ' Set the assembly file name to generate.
        cp.OutputAssembly = exeFile

        ' Save the assembly as a physical file.
        cp.GenerateInMemory = false

        ' Invoke compilation.
        Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, sourceFile)

        If cr.Errors.Count > 0 Then
            ' Display compilation errors.
            Console.WriteLine("Errors building {0} into {1}", _
                sourceFile, cr.PathToAssembly)
            For Each ce As CompilerError in cr.Errors
                Console.WriteLine("  {0}", ce.ToString())
                Console.WriteLine()
            Next ce
        Else
            Console.WriteLine("Source {0} built into {1} successfully.", _
                sourceFile, cr.PathToAssembly)
        End If

        ' Return the results of compilation.
        If cr.Errors.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ' </snippet14>
End Class
' </Snippet11>
