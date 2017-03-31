' <Snippet1>
Imports System.Reflection

Public Class Example
    Public Shared Sub Main()
        Dim mainAssembly As Assembly = GetType(Example).Assembly
        Console.WriteLine("The executing assembly is {0}.", mainAssembly)
        Dim mods() As [Module] = mainAssembly.GetModules()
        Console.WriteLine(vbTab & "Modules in the assembly:")
        For Each m As [Module] In mods
            Console.WriteLine(vbTab & m.ToString())
        Next
    End Sub 
End Class 
' </Snippet1>