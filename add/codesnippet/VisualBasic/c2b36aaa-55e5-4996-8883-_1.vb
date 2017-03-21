            Structure Package
                Public Company As String
                Public Weight As Double
                Public TrackingNumber As Long
            End Structure

            Sub ToDictionaryEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With
                  {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L},
                  New Package With
                  {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L},
                  New Package With
                  {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L},
                  New Package With
                  {.Company = "Adventure Works", .Weight = 33.8, .TrackingNumber = 4665518773L}})

                ' Create a Dictionary that contains Package values, 
                ' using TrackingNumber as the key.
                Dim dict As Dictionary(Of Long, Package) =
                packages.ToDictionary(Function(p) p.TrackingNumber)

                ' Display the results.
                Dim output As New System.Text.StringBuilder
                For Each kvp As KeyValuePair(Of Long, Package) In dict
                    output.AppendLine("Key " & kvp.Key & ": " &
                                  kvp.Value.Company & ", " &
                                  kvp.Value.Weight & " pounds")
                Next
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Key 89453312: Coho Vineyard, 25.2 pounds
            ' Key 89112755: Lucerne Publishing, 18.7 pounds
            ' Key 299456122: Wingtip Toys, 6 pounds
            ' Key 4665518773: Adventure Works, 33.8 pounds
