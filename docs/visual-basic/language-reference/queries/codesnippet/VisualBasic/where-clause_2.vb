    Private Sub DisplayElements()
        Dim elements As List(Of Element) = BuildList()

        ' Get a list of elements that have an atomic number from 12 to 14,
        ' or that have a name that ends in "r".
        Dim subset = From theElement In elements
            Where (theElement.AtomicNumber >= 12 And theElement.AtomicNumber < 15) _
            Or theElement.Name.EndsWith("r")
            Order By theElement.Name

        For Each theElement In subset
            Console.WriteLine(theElement.Name & " " & theElement.AtomicNumber)
        Next

        ' Output:
        '  Aluminum 13
        '  Magnesium 12
        '  Silicon 14
        '  Sulfur 16
    End Sub

    Private Function BuildList() As List(Of Element)
        Return New List(Of Element) From
            {
                {New Element With {.Name = "Sodium", .AtomicNumber = 11}},
                {New Element With {.Name = "Magnesium", .AtomicNumber = 12}},
                {New Element With {.Name = "Aluminum", .AtomicNumber = 13}},
                {New Element With {.Name = "Silicon", .AtomicNumber = 14}},
                {New Element With {.Name = "Phosphorous", .AtomicNumber = 15}},
                {New Element With {.Name = "Sulfur", .AtomicNumber = 16}}
            }
    End Function

    Public Class Element
        Public Property Name As String
        Public Property AtomicNumber As Integer
    End Class