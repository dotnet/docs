Module ILookup
    Sub Main(ByVal args As String())
        ILookupExample()
    End Sub

    ' <Snippet1>
    Structure Package
        Public Company As String
        Public Weight As Double
        Public TrackingNumber As Long
    End Structure

    Sub ILookupExample()
        ' Create a list of Packages to put into an ILookup data structure.
        Dim packages As New System.Collections.Generic.List(Of Package)(New Package() _
            {New Package With {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L}, _
              New Package With {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L}, _
              New Package With {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L}, _
              New Package With {.Company = "Contoso Pharmaceuticals", .Weight = 9.3, .TrackingNumber = 670053128L}, _
              New Package With {.Company = "Wide World Importers", .Weight = 33.8, .TrackingNumber = 4665518773L}})

        ' Create a ILookup to organize the packages. Use the first character of Company as the key value.
        ' Select Company appended to TrackingNumber for each element value.
        Dim packageLookup As ILookup(Of Char, String) = _
            packages.ToLookup(Function(p) Convert.ToChar(p.Company.Substring(0, 1)), _
                              Function(p) p.Company & " " & p.TrackingNumber)

        Dim output As New System.Text.StringBuilder
        ' Iterate through each group in the Lookup and output the contents.
        For Each packageGroup In packageLookup
            ' Print the key value.
            output.AppendLine(packageGroup.Key)
            ' Iterate through each value in the group and output it.
            For Each str As String In packageGroup
                output.AppendLine(String.Format("    {0}", str))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())

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
    End Sub
    ' </Snippet1>
End Module