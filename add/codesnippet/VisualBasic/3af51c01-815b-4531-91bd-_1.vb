    Structure Package
        Public Company As String
        Public Weight As Double
    End Structure

    Shared Sub SumEx3()
        Dim packages As New List(Of Package)(New Package() { _
                New Package With {.Company = "Coho Vineyard", .Weight = 25.2}, _
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7}, _
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0}, _
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

        ' Calculate the sum of all package weights.
        Dim totalWeight As Double = packages.AsQueryable().Sum(Function(pkg) pkg.Weight)

        MsgBox("The total weight of the packages is: " & totalWeight)
    End Sub

    'This code produces the following output:

    'The total weight of the packages is: 83.7
