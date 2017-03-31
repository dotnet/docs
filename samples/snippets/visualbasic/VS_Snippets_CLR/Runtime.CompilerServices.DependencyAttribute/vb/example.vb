'<snippet1>
Imports System.Runtime.CompilerServices

<Assembly: DependencyAttribute("AssemblyA", LoadHint.Always)> 
<Assembly: DependencyAttribute("AssemblyB", LoadHint.Sometimes)> 
Module Program


    Sub Main(ByVal args() As String)
        Console.WriteLine("The DependencyAttribute attribute was applied.")
    End Sub


End Module
'</snippet1>