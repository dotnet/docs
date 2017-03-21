            ' Create three string arrays.
            Dim names1() As String =
            {"Hartono, Tommy"}
            Dim names2() As String =
            {"Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}
            Dim names3() As String =
            {"Solanki, Ajay", "Hoeing, Helge", "Andersen, Henriette Thaulow", "Potra, Cristina", "Iallo, Lucio"}

            ' Create a List that contains 3 elements, where
            ' each element is an array of strings.
            Dim namesList As New List(Of String())(New String()() {names1, names2, names3})

            ' Select arrays that have four or more elements and union
            ' them into one collection, using Empty() to generate the 
            ' empty collection for the seed value.
            Dim allNames As IEnumerable(Of String) =
            namesList.Aggregate(Enumerable.Empty(Of String)(),
                                Function(current, nextOne) _
                                    IIf(nextOne.Length > 3, current.Union(nextOne), current))

            Dim output As New System.Text.StringBuilder
            For Each name As String In allNames
                output.AppendLine(name)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' Adams, Terry
            ' Andersen, Henriette Thaulow
            ' Hedlund, Magnus
            ' Ito, Shu
            ' Solanki, Ajay
            ' Hoeing, Helge
            ' Potra, Cristina
            ' Iallo, Lucio
