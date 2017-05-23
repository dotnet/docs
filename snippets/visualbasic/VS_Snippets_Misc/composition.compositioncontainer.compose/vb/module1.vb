Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives


Module Module1
    '<snippet1>
    <Export()>
    Public Class Part1
        Public ReadOnly Property data As String
            Get
                Return "This is the example data!"
            End Get
        End Property
    End Class
    <Export()>
    Public Class Part2
        <Import()>
        Public Property data As Part1
    End Class

    <Export()>
    Public Class Part3
        <Import()>
        Public Property data As Part2
    End Class


    Sub Main()
        Dim container As New CompositionContainer()
        Dim batch As New CompositionBatch()
        batch.AddPart(AttributedModelServices.CreatePart(New Part1()))
        batch.AddPart(AttributedModelServices.CreatePart(New Part2()))
        batch.AddPart(AttributedModelServices.CreatePart(New Part3()))
        container.Compose(batch)
        Dim _part As Part3
        _part = container.GetExportedValue(Of Part3)()
        Console.WriteLine(_part.data.data.data)
        Console.ReadLine()

    End Sub
    '</snippet1>
End Module
