'<snippet1>
Imports System.Runtime.CompilerServices

<Assembly: CompilationRelaxationsAttribute(CompilationRelaxations.NoStringInterning)> 

Module Program


    Sub Main(ByVal args() As String)
        Console.WriteLine("The CompilationRelaxationsAttribute attribute was applied.")
    End Sub


End Module
'</snippet1>