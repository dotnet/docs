Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Class Class1

    <STAThread()> _
    Public Overloads Shared Sub Main(ByVal args() As String)
        '<Snippet1>
        ' Creates a new CodeGeneratorOptions.
        Dim genOptions As New CodeGeneratorOptions()

        ' Sets a value indicating that the code generator should insert blank lines between type members.
        genOptions.BlankLinesBetweenMembers = True

        ' Sets the style of bracing format to use: either "Block" to start a
        ' bracing block on the same line as the declaration of its container, or 
        ' "C" to start the bracing for the block on the following line.
        genOptions.BracingStyle = "C"

        ' Sets a value indicating that the code generator should not append an else, 
        ' catch or finally block, including brackets, at the closing line of a preceeding if or try block.
        genOptions.ElseOnClosing = False

        ' Sets the string to indent each line with.
        genOptions.IndentString = "    "

        ' Uses the CodeGeneratorOptions indexer property to set an
        ' example object to the type's string-keyed ListDictionary.
        ' Custom ICodeGenerator implementations can use objects 
        ' in this dictionary to customize process behavior.
        genOptions("CustomGeneratorOptionStringExampleID") = "BuildFlags: /A /B /C /D /E"
        '</Snippet1>
        Console.WriteLine(genOptions.ToString())
    End Sub

End Class