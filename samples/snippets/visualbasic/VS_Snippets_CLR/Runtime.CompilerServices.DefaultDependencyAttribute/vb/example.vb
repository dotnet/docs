'<snippet1>
Imports System.Runtime.CompilerServices

<Assembly: DefaultDependencyAttribute(LoadHint.Always)> 
Module Program


    Sub Main(ByVal args() As String)
        Console.WriteLine("The DefaultDependencyAttribute attribute was applied.")
    End Sub


End Module
'</snippet1>