'<Snippet1>
Imports System
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports System.Collections.Generic



Class Program

    Shared Sub Main(ByVal args() As String)
        DisplayVBCompilerInfo()
        Console.WriteLine("Press Enter key to exit.")
        Console.ReadLine()

    End Sub 'Main

    Shared Sub DisplayVBCompilerInfo()
        Dim provOptions As New Dictionary(Of String, String)
        provOptions.Add("CompilerVersion", "v3.5")
        ' Get the provider for Microsoft.VisualBasic
        Dim vbProvider As VBCodeProvider = New VBCodeProvider(provOptions)

        ' Display the Visual Basic language provider information.
        Console.WriteLine("Visual Basic provider is {0}", vbProvider.ToString())
        Console.WriteLine("  Provider hash code:     {0}", vbProvider.GetHashCode().ToString())
        Console.WriteLine("  Default file extension: {0}", vbProvider.FileExtension)

        Console.WriteLine()

    End Sub 'DisplayVBCompilerInfo
End Class 'Program
'</Snippet1>
