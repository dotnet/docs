' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Reflection
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim SentencePattern As New RegexCompilationInfo("\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]",
                                                        RegexOptions.Multiline,
                                                        "SentencePattern",
                                                        "Utilities.RegularExpressions",
                                                        True)
        Dim regexes() As RegexCompilationInfo = {SentencePattern}
        Dim assemName As New AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null")
        Regex.CompileToAssembly(regexes, assemName)
    End Sub
End Module
' </Snippet6>
