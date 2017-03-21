            Structure Package
                Public Company As String
                Public Weight As Double
            End Structure

            Sub SumEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With {.Company = "Coho Vineyard", .Weight = 25.2},
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7},
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0},
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

                ' Sum the values from each item's Weight property.
                Dim totalWeight As Double = packages.Sum(Function(pkg) _
                                                         pkg.Weight)

                ' Display the result.
                MsgBox("The total weight of the packages is: " & totalWeight)
            End Sub

            ' This code produces the following output:
            '
            ' The total weight of the packages is: 83.7
