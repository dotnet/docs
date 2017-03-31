
'<Snippet1>
Imports System
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports System.Collections.Generic



Class Program

    Shared Sub Main(ByVal args() As String)
        DisplayCSharpCompilerInfo()
        DisplayVBCompilerInfo()
        Console.WriteLine("Press Enter key to exit.")
        Console.ReadLine()

    End Sub 'Main

    Shared Sub DisplayCSharpCompilerInfo()
        Dim provOptions As New Dictionary(Of String, String)
        provOptions.Add("CompilerVersion", "v4")
        ' Get the provider for Microsoft.CSharp
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("CSharp", provOptions)

        ' Display the C# language provider information.
        Console.WriteLine("CSharp provider is {0}", provider.ToString())
        Console.WriteLine("  Provider hash code:     {0}", provider.GetHashCode().ToString())
        Console.WriteLine("  Default file extension: {0}", provider.FileExtension)

        Console.WriteLine()

    End Sub 'DisplayCSharpCompilerInfo


    Shared Sub DisplayVBCompilerInfo()
        Dim provOptions As New Dictionary(Of String, String)
        provOptions.Add("CompilerVersion", "v3.5")
        ' Get the provider for Microsoft.VisualBasic
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic", provOptions)

        ' Display the Visual Basic language provider information.
        Console.WriteLine("Visual Basic provider is {0}", provider.ToString())
        Console.WriteLine("  Provider hash code:     {0}", provider.GetHashCode().ToString())
        Console.WriteLine("  Default file extension: {0}", provider.FileExtension)

        Console.WriteLine()

    End Sub 'DisplayVBCompilerInfo
End Class 'Program
'</Snippet1>