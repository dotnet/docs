' <snippet5>
' This program lists all the public constructors
' of the System.String class.
Imports System.Reflection

Public Class OtherSnippets
    Public Shared Sub Main()
        SnippetA()
        SnippetB()
    End Sub

    Public Shared Sub SnippetA()
        ' <snippet6>
        ' Gets the mscorlib assembly in which the object is defined.
        Dim a As Assembly = GetType(Object).Module.Assembly
        ' </snippet6>
    End Sub

    Public Shared Sub SnippetB()
        ' <snippet7>
        ' Loads an assembly using its file name.
        Dim a As Assembly = Assembly.LoadFrom("MyExe.exe")
        ' Gets the type names from the assembly.
        Dim types2() As Type = a.GetTypes()
        For Each t As Type In types2
            Console.WriteLine(t.FullName)
        Next t
        ' </snippet7>
    End Sub
End Class
' </snippet5>
