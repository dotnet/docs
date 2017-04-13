Module IGrouping
    Sub Main(ByVal args As String())
        LookupExample()
    End Sub

    ' <Snippet1>
    Structure Package
        Public Company As String
        Public Weight As Double
        Public TrackingNumber As Long
    End Structure

    Sub LookupExample()
        ' Create a list of Packages to put into a Lookup data structure.
        Dim packages As New System.Collections.Generic.List(Of Package)(New Package() _
            {New Package With {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L}, _
              New Package With {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L}, _
              New Package With {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L}, _
              New Package With {.Company = "Contoso Pharmaceuticals", .Weight = 9.3, .TrackingNumber = 670053128L}, _
              New Package With {.Company = "Wide World Importers", .Weight = 33.8, .TrackingNumber = 4665518773L}})

        ' Create a Lookup to organize the packages. Use the first character of Company as the key value.
        ' Select Company appended to TrackingNumber for each element value in the Lookup.
        Dim lookup As ILookup(Of Char, String) = _
            packages.ToLookup(Function(ByVal p) Convert.ToChar(p.Company.Substring(0, 1)), _
                              Function(ByVal p) p.Company & " " & p.TrackingNumber)

        ' <Snippet5>
        Dim output As New System.Text.StringBuilder
        ' Iterate through each IGrouping in the Lookup and output the contents.
        For Each packageGroup As IGrouping(Of Char, String) In lookup
            ' Print the key value of the IGrouping.
            output.AppendLine(packageGroup.Key)
            ' Iterate through each value in the IGrouping and print its value.
            For Each str As String In packageGroup
                output.AppendLine(String.Format("    {0}", str))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
        ' </Snippet5>

        ' This code produces the following output:
        '
        ' C
        '     Coho Vineyard 89453312
        '     Contoso Pharmaceuticals 670053128
        ' L
        '     Lucerne Publishing 89112755
        ' W
        '     Wingtip Toys 299456122
        '     Wide World Importers 4665518773

        ' <Snippet2>
        ' Get the number of key-collection pairs in the Lookup.
        Dim count As Integer = lookup.Count
        ' </Snippet2>

        ' <Snippet3>
        ' Select a collection of Packages by indexing directly into the Lookup.
        Dim cgroup As System.Collections.Generic.IEnumerable(Of String) = lookup("C"c)
        ' </Snippet3>

        output = New System.Text.StringBuilder
        ' Output the results.
        output.AppendLine(vbCrLf & "Packages that have a key of 'C':")
        For Each str As String In cgroup
            output.AppendLine(str)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' Packages that have a key of 'C'
        ' Coho Vineyard 89453312
        ' Contoso Pharmaceuticals 670053128

        ' <Snippet4>
        ' Determine if there is a key with the value 'G' in the Lookup.
        Dim hasG As Boolean = lookup.Contains("G"c)
        ' </Snippet4>
    End Sub
    ' </Snippet1>
End Module