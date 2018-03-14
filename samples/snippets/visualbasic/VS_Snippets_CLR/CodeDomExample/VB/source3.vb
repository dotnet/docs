'<snippet20>
Imports System
Imports System.IO
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp

Class Example
    Public Shared Sub Main()
        Dim sourcefile As String
        Dim exefile As String

        Dim codeUnit As New CodeCompileUnit()
        sourcefile = GenerateCSharpCode(codeUnit)
        exefile = sourcefile.Substring(0, sourcefile.LastIndexOf(".")) + ".exe"
        Console.WriteLine("outfile: {0}", exefile)
        CompileCSharpCode(sourcefile, exefile)
    End Sub

    '<snippet22>
    Public Shared Function GenerateCSharpCode(compileunit As CodeCompileUnit) As String
        ' Generate the code with the C# code provider.
        '<snippet21>
        Dim provider As New CSharpCodeProvider()
        '</snippet21>

        ' Build the output file name.
        Dim sourceFile As String
        If provider.FileExtension(0) = "." Then
           sourceFile = "HelloWorld" + provider.FileExtension
        Else
           sourceFile = "HelloWorld." + provider.FileExtension
        End If

        ' Create a TextWriter to a StreamWriter to the output file.
        Using sw As New StreamWriter(sourceFile, false)
            Dim tw As New IndentedTextWriter(sw, "    ")

            ' Generate source code Imports the code provider.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, _
                New CodeGeneratorOptions())

            ' Close the output file.
            tw.Close()
        End Using

        Return sourceFile
    End Function
    '</snippet22>

    '<snippet23>
    Public Shared Function CompileCSharpCode(sourceFile As String, _
        exeFile As String) As Boolean
        Dim provider As New CSharpCodeProvider()

        ' Build the parameters for source compilation.
        Dim cp As New CompilerParameters()

        ' Add an assembly reference.
        cp.ReferencedAssemblies.Add( "System.dll" )

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
            For Each ce As CompilerError In cr.Errors
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
    '</snippet23>
End Class
'</snippet20>
