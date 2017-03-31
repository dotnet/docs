' The following example builds a CodeDom source graph for a simple
' Hello World program.  The source is then saved to a file,
' compiled into an executable, and run.

' This example is based loosely on the CodeDom example, but its
' primary intent is to illustrate the CompilerParameters class.
'<Snippet1>
Imports System
Imports System.Globalization
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Diagnostics

Namespace CompilerParametersExample

    Class CompileClass

        ' Build a Hello World program graph using System.CodeDom types.
        Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit

            ' Create a new CodeCompileUnit to contain the program graph.
            Dim compileUnit As New CodeCompileUnit()

            ' Declare a new namespace called Samples.
            Dim samples As New CodeNamespace("Samples")

            ' Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples)

            ' Add the new namespace import for the System namespace.
            samples.Imports.Add(New CodeNamespaceImport("System"))

            ' Declare a new type called Class1.
            Dim Class1 As New CodeTypeDeclaration("Class1")

            ' Add the new type to the namespace's type collection.
            samples.Types.Add(class1)

            ' Declare a new code entry point method
            Dim start As New CodeEntryPointMethod()

            ' Create a type reference for the System.Console class.
            Dim csSystemConsoleType As New CodeTypeReferenceExpression( _
                "System.Console")

            ' Build a Console.WriteLine statement.
            Dim cs1 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Hello World!"))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1)

            ' Build another Console.WriteLine statement.
            Dim cs2 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Press the Enter key to continue."))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2)

            ' Build a call to System.Console.ReadLine.
            Dim csReadLine As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "ReadLine")

            ' Add the ReadLine statement.
            start.Statements.Add(csReadLine)

            ' Add the code entry point method to the Members
            ' collection of the type.
            class1.Members.Add(start)

            Return compileUnit
        End Function


        Public Shared Function GenerateCode(ByVal provider As CodeDomProvider, _
        ByVal compileunit As CodeCompileUnit) As String

            ' Build the source file name with the language extension (vb, cs, js).
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "HelloWorld" + provider.FileExtension
            Else
                sourceFile = "HelloWorld." + provider.FileExtension
            End If

            ' Create a TextWriter to a StreamWriter to an output file.
            Dim tw As New IndentedTextWriter(New StreamWriter(sourceFile, False), "    ")

            ' Generate source code using the code provider.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, _
                New CodeGeneratorOptions())

            ' Close the output file.
            tw.Close()

            Return sourceFile
        End Function 'GenerateCode


        '<Snippet2>
        Public Shared Function CompileCode(ByVal provider As CodeDomProvider, _
        ByVal sourceFile As String, ByVal exeFile As String) As Boolean

            Dim cp As New CompilerParameters()

            ' Generate an executable instead of 
            ' a class library.
            cp.GenerateExecutable = True

            ' Set the assembly file name to generate.
            cp.OutputAssembly = exeFile

            ' Generate debug information.
            cp.IncludeDebugInformation = True

            ' Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll")

            ' Save the assembly as a physical file.
            cp.GenerateInMemory = False

            ' Set the level at which the compiler 
            ' should start displaying warnings.
            cp.WarningLevel = 3

            ' Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = False

            ' Set compiler argument to optimize output.
            cp.CompilerOptions = "/optimize"

            ' Set a temporary files collection.
            ' The TempFileCollection stores the temporary files
            ' generated during a build in the current directory,
            ' and does not delete them after compilation.
            cp.TempFiles = New TempFileCollection(".", True)

            If provider.Supports(GeneratorSupport.EntryPointMethod) Then
                ' Specify the class that contains
                ' the main method of the executable.
                cp.MainClass = "Samples.Class1"
            End If


            If Directory.Exists("Resources") Then
                If provider.Supports(GeneratorSupport.Resources) Then
                    ' Set the embedded resource file of the assembly.
                    ' This is useful for culture-neutral resources,
                    ' or default (fallback) resources.
                    cp.EmbeddedResources.Add("Resources\Default.resources")

                    ' Set the linked resource reference files of the assembly.
                    ' These resources are included in separate assembly files,
                    ' typically localized for a specific language and culture.
                    cp.LinkedResources.Add("Resources\nb-no.resources")
                End If
            End If

            ' Invoke compilation.
            Dim cr As CompilerResults = _
                provider.CompileAssemblyFromFile(cp, sourceFile)

            If cr.Errors.Count > 0 Then
                ' Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}", _
                    sourceFile, cr.PathToAssembly)
                Dim ce As CompilerError
                For Each ce In cr.Errors
                    Console.WriteLine("  {0}", ce.ToString())
                    Console.WriteLine()
                Next ce
            Else
                Console.WriteLine("Source {0} built into {1} successfully.", _
                    sourceFile, cr.PathToAssembly)
                Console.WriteLine("{0} temporary files created during the compilation.", _
                        cp.TempFiles.Count.ToString())
            End If

            ' Return the results of compilation.
            If cr.Errors.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Function 'CompileCode

        '</Snippet2>
        <STAThread()> _
        Shared Sub Main()
            Dim exeName As String = "HelloWorld.exe"
            Dim provider As CodeDomProvider = Nothing

            Console.WriteLine("Enter the source language for Hello World (cs, vb, etc):")
            Dim inputLang As String = Console.ReadLine()
            Console.WriteLine()

            If CodeDomProvider.IsDefinedLanguage(inputLang) Then
                Dim helloWorld As CodeCompileUnit = BuildHelloWorldGraph()
                provider = CodeDomProvider.CreateProvider(inputLang)

                Dim sourceFile As String
                sourceFile = GenerateCode(provider, helloWorld)

                Console.WriteLine("HelloWorld source code generated.")

                If CompileCode(provider, sourceFile, exeName) Then
                    Console.WriteLine("Starting HelloWorld executable.")
                    Process.Start(exeName)
                End If
            End If

            If provider Is Nothing Then
                Console.WriteLine("There is no CodeDomProvider for the input language.")
            End If
        End Sub 'Main 

    End Class 'CompileClass
End Namespace
'</Snippet1>
