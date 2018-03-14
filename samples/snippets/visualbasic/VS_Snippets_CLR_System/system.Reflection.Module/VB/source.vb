'<Snippet1>
Imports System.Reflection
Imports System

Public Class Program
    Public Shared Sub Main()

        Dim c1 As New Class1

        ' Show the current module.

        ' Note the brackets around "[Module]" to differentiate 
        ' it from the Visual Basic "Module" keyword.
        Dim m As [Module] = c1.GetType().Module
        Console.WriteLine("The current module is {0}.", m.Name)

        ' List all modules in the assembly.
        Dim curAssembly As Assembly = GetType(Program).Assembly
        Console.WriteLine("The executing assembly is {0}.", curAssembly)

        Dim mods() As [Module] = curAssembly.GetModules()

        For Each md As [Module] In mods
            Console.WriteLine("This assembly contains the {0} module", md.Name)
        Next
        Console.ReadLine()
    End Sub


End Class
Class Class1

End Class
'</Snippet1>