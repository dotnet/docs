' The following example illustrates using the C# or Visual Basic 
' code providers to compile a source file.  The example program takes
' a source file as input and attempts to compile the code into an executable.
' If the source file has a .vb extension, it is compiled with the Visual Basic
' code provider.  If it has a .cs extension, it is compiled with the CSharp 
' code provider.

' <Snippet1>
Imports System
Imports System.IO
Imports System.Globalization
Imports System.CodeDom.Compiler
Imports System.Text
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic

Namespace CodeProviders
    Class CompileSample
        <STAThread()>  _
        Public Shared Sub Main(args() As String)

            If args.Length > 0
                ' First parameter is the source file name.
                If File.Exists(args(0))
                    CompileExecutable(args(0))
                Else 
                    Console.WriteLine("Input source file not found - {0}", _
                        args(0))
                End If
            
            Else
                Console.WriteLine("Input source file not specified on command line!")
            End If
        End Sub

        '<Snippet2>
        Public Shared Function CompileExecutable(sourceName As String) As Boolean
            Dim sourceFile As FileInfo = New FileInfo(sourceName)
            Dim provider As CodeDomProvider = Nothing
            Dim compileOk As Boolean = False

            ' Select the code provider based on the input file extension.
            If sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".CS"

                provider = CodeDomProvider.CreateProvider("CSharp")

            ElseIf sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".VB"

                provider = CodeDomProvider.CreateProvider("VisualBasic")

            Else
                Console.WriteLine("Source file must have a .cs or .vb extension")
            End If

            If Not provider Is Nothing

                ' Format the executable file name.
                ' Build the output assembly path using the current directory
                ' and <source>_cs.exe or <source>_vb.exe.

                Dim exeName As String = String.Format("{0}\{1}.exe", _
                    System.Environment.CurrentDirectory, _
                    sourceFile.Name.Replace(".", "_"))

                Dim cp As CompilerParameters = new CompilerParameters()

                ' Generate an executable instead of 
                ' a class library.
                cp.GenerateExecutable = True

                ' Specify the assembly file name to generate.
                cp.OutputAssembly = exeName
    
                ' Save the assembly as a physical file.
                cp.GenerateInMemory = False
    
                ' Set whether to treat all warnings as errors.
                cp.TreatWarningsAsErrors = False
 
                ' Invoke compilation of the source file.
                Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, _
                    sourceName)
    
                If cr.Errors.Count > 0
                    ' Display compilation errors.
                    Console.WriteLine("Errors building {0} into {1}", _
                        sourceName, cr.PathToAssembly)

                    Dim ce As CompilerError
                    For Each ce In cr.Errors
                        Console.WriteLine("  {0}", ce.ToString())
                        Console.WriteLine()
                    Next ce
                Else
                    ' Display a successful compilation message.
                    Console.WriteLine("Source {0} built into {1} successfully.", _
                        sourceName, cr.PathToAssembly)
                End If
              
                ' Return the results of the compilation.
                If cr.Errors.Count > 0
                    compileOk = False
                Else 
                    compileOk = True
                End If
            End If
            return compileOk

        End Function
        '</Snippet2>
    End Class
End Namespace
' </Snippet1>
