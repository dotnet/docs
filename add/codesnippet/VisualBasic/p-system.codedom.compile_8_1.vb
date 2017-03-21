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
