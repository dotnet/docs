Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections

Class Class1

    Sub New()
    End Sub

    '<Snippet1>
    ' Displays information from a CompilerResults.
    Public Shared Sub DisplayCompilerResults(ByVal cr As System.CodeDom.Compiler.CompilerResults)
        ' If errors occurred during compilation, output the compiler output and errors.
        If cr.Errors.Count > 0 Then
            Dim i As Integer
            For i = 0 To cr.Output.Count - 1
                Console.WriteLine(cr.Output(i))
            Next i        
            For i = 0 To cr.Errors.Count - 1
                Console.WriteLine((i.ToString() + ": " + cr.Errors(i).ToString()))
            Next i
        Else
            ' Display information about the compiler's exit code and the generated assembly.
            Console.WriteLine(("Compiler returned with result code: " + cr.NativeCompilerReturnValue.ToString()))
            Console.WriteLine(("Generated assembly name: " + cr.CompiledAssembly.FullName))
            If cr.PathToAssembly Is Nothing Then
                Console.WriteLine("The assembly has been generated in memory.")
            Else
                Console.WriteLine(("Path to assembly: " + cr.PathToAssembly))
            End If
            ' Display temporary files information.
            If Not cr.TempFiles.KeepFiles Then
                Console.WriteLine("Temporary build files were deleted.")
            Else
                Console.WriteLine("Temporary build files were not deleted.")
                ' Display a list of the temporary build files
                Dim enu As IEnumerator = cr.TempFiles.GetEnumerator()
                Dim i As Integer
                i = 0
                While enu.MoveNext()
                    Console.WriteLine(("TempFile " + i.ToString() + ": " + CStr(enu.Current)))
                    i += 1
                End While
            End If
        End If
    End Sub
    '</Snippet1>

End Class