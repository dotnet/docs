Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting

Module Module1

    '<snippet1>
    <Export()>
    Public Class MyAddin
        Public ReadOnly Property theData As String
            Get
                Return "The Data!"
            End Get
        End Property
    End Class

    Public Class MyProgam
        Private _MyAddin As MyAddin

        <Import()>
        Public Property MyAddinProperty As MyAddin
            Get
                Return _MyAddin
            End Get
            Set(ByVal value As MyAddin)
                _MyAddin = value
            End Set
        End Property

    End Class



    Sub Main()
        Dim catalog As AggregateCatalog = New AggregateCatalog()
        catalog.Catalogs.Add(New AssemblyCatalog(GetType(MyAddin).Assembly))
        Dim container As CompositionContainer = New CompositionContainer(catalog)
        Dim theProgam As MyProgam = New MyProgam()
        container.SatisfyImportsOnce(theProgam)
        Console.WriteLine(theProgam.MyAddinProperty.theData)
        Console.ReadLine()

        container.Dispose()

    End Sub
    '</snippet1>

End Module
