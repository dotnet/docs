            Structure Package
                Public Company As String
                Public Weight As Double
            End Structure

            Sub ToArrayEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With {.Company = "Coho Vineyard", .Weight = 25.2},
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7},
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0},
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

                ' Project the Company values from each item in the list
                ' and put them into an array.
                Dim companies() As String =
                packages _
                .Select(Function(pkg) pkg.Company) _
                .ToArray()

                ' Display the results.
                Dim output As New System.Text.StringBuilder
                For Each company As String In companies
                    output.AppendLine(company)
                Next
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Coho Vineyard
            ' Lucerne Publishing
            ' Wingtip Toys
            ' Adventure Works
