' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
        ' Match two or more occurrences of the same character.
        Dim pattern As String = "(\w)\1+"
        
        ' Use case-insensitive matching. 
        Dim rci As New RegexCompilationInfo(pattern, RegexOptions.IgnoreCase,
                                            "DuplicateChars", "CustomRegexes", 
                                            True, TimeSpan.FromSeconds(2))

        ' Define an assembly to contain the compiled regular expression.
        Dim an As New AssemblyName()
        an.Name = "RegexLib"
        Dim rciList As RegexCompilationInfo() = New RegexCompilationInfo() { rci }

        ' Compile the regular expression and create the assembly.
        Regex.CompileToAssembly(rciList, an)
   End Sub
End Module
' </Snippet1>
