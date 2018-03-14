'<snippet1>
' This code example demonstrates the RegexCompilationInfo constructor
' and the Regex.CompileToAssembly() method.
' compile: csc genFishRegex.cs

Imports System.Reflection
Imports System.Text.RegularExpressions

Class GenFishRegEx
    Public Shared Sub Main() 
        ' Pattern = Group matches one or more word characters, 
        '           one or more white space characters, 
        '           group matches the string "fish".
        Dim pat As String = "(\w+)\s+(fish)"
        
        ' Create the compilation information.
        ' Case-insensitive matching; type name = "FishRegex"; 
        ' namespace = "MyApp"; type is public.
        Dim rci As New RegexCompilationInfo(pat, RegexOptions.IgnoreCase, _
                                            "FishRegex", "MyApp", True)
        
        ' Setup to compile.
        Dim an As New AssemblyName()
        an.Name = "FishRegex"
        Dim rciList As RegexCompilationInfo() = New RegexCompilationInfo() { rci }
        
        ' Compile the regular expression.
        Regex.CompileToAssembly(rciList, an)
    
    End Sub 'Main
End Class 'GenFishRegEx
' </snippet1>
