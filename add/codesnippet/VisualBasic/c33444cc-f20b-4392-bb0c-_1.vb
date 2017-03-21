        Structure Package
            Public Company As String
            Public Weight As Double
            Public TrackingNumber As Long
        End Structure

        Sub ToLookupEx1()
            ' Create a list of Packages.
            Dim packages As New List(Of Package)(New Package() _
             {New Package With
              {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L},
              New Package With
              {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L},
              New Package With
              {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L},
              New Package With
              {.Company = "Contoso Pharmaceuticals", .Weight = 9.3, .TrackingNumber = 670053128L},
              New Package With
              {.Company = "Wide World Importers", .Weight = 33.8, .TrackingNumber = 4665518773L}})

            ' Create a Lookup to organize the packages. 
            ' Use the first character of Company as the key value.
            ' Select Company appended to TrackingNumber 
            ' as the element values of the Lookup.
            Dim lookup As ILookup(Of Char, String) =
            packages.ToLookup(Function(p) _
                                  Convert.ToChar(p.Company.Substring(0, 1)),
                              Function(p) _
                                  p.Company & " " & p.TrackingNumber)

            Dim output As New System.Text.StringBuilder

            ' Iterate through each IGrouping in the Lookup.
            For Each packageGroup As IGrouping(Of Char, String) In lookup
                ' Print the key value of the IGrouping.
                output.AppendLine(packageGroup.Key)
                ' Iterate through each value in the IGrouping and print its value.
                For Each str As String In packageGroup
                    output.AppendLine("   " & str)
                Next
            Next

            ' Select a group of packages by indexing directly into the Lookup.
            Dim cgroup As IEnumerable(Of String) = lookup("C"c)

            output.AppendLine(vbCrLf & "Packages from Company names that start with 'C':")
            For Each str As String In cgroup
                output.AppendLine(str)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' C
        '    Coho Vineyard 89453312
        '    Contoso Pharmaceuticals 670053128
        ' L
        '    Lucerne Publishing 89112755
        ' W
        '    Wingtip Toys 299456122
        '    Wide World Importers 4665518773
        '
        ' Packages from Company names that start with 'C':
        ' Coho Vineyard 89453312
        ' Contoso Pharmaceuticals 670053128
