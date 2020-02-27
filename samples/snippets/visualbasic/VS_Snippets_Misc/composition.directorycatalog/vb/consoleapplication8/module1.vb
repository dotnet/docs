Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports ClassLibrary1

Module Module1

    '<snippet1>
    Public Class Test2
        <Import()>
        Public Property data As Test1
    End Class

    Sub Main()
        Dim catalog As New DirectoryCatalog(".")
        Dim container As New CompositionContainer(catalog)
        Dim test As New Test2()
        container.SatisfyImportsOnce(test)
        Console.WriteLine(test.data.data)
        Console.ReadLine()
    End Sub
    '</snippet1>
End Module
