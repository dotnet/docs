Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting

Module Module1

    '<snippet1>
    'Default export infers type and contract name from the
    'exported type.  This is the preferred method.
    <Export()>
    Public Class MyExport1
        Public ReadOnly Property data As String
            Get
                Return "Test Data 1."
            End Get
        End Property
    End Class

    Public Class MyImporter1

        <Import()>
        Public Property ImportedMember As MyExport1

    End Class

    Public Interface MyInterface

    End Interface

    'Specifying the contract type may be important if
    'you want to export a type other then the base type,
    'such as an interface.
    <Export(GetType(MyInterface))>
    Public Class MyExport2
        Implements MyInterface
        Public ReadOnly Property data As String
            Get
                Return "Test Data 2."
            End Get
        End Property
    End Class

    Public Class MyImporter2
        'The import must match the contract type!
        <Import(GetType(MyInterface))>
        Public Property ImportedMember As MyExport2
    End Class

    'Specifying a contract name should only be 
    'needed in rare caes. Usually, using metadata
    'is a better approach.
    <Export("MyContractName", GetType(MyInterface))>
    Public Class MyExport3
        Implements MyInterface
        Public ReadOnly Property data As String
            Get
                Return "Test Data 3."
            End Get
        End Property
    End Class

    Public Class MyImporter3
        'Both contract name and type must match!
        <Import("MyContractName", GetType(MyInterface))>
        Public Property ImportedMember As MyExport3
    End Class



    Sub Main()
        Dim catalog As AggregateCatalog = New AggregateCatalog()
        catalog.Catalogs.Add(New AssemblyCatalog(GetType(MyExport1).Assembly))
        Dim container As CompositionContainer = New CompositionContainer(catalog)
        Dim test1 As MyImporter1 = New MyImporter1()
        Dim test2 As MyImporter2 = New MyImporter2()
        Dim test3 As MyImporter3 = New MyImporter3()
        container.SatisfyImportsOnce(test1)
        container.SatisfyImportsOnce(test2)
        container.SatisfyImportsOnce(test3)
        Console.WriteLine(test1.ImportedMember.data)
        Console.WriteLine(test2.ImportedMember.data)
        Console.WriteLine(test3.ImportedMember.data)
        Console.ReadLine()
    End Sub

    '</snippet1>

End Module