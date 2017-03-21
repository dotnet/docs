            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            Dim random As Random = New Random(DateTime.Now.Millisecond)

            ' Get a string at a random index within the array.
            Dim name As String = names.ElementAt(random.Next(0, names.Length))

            ' Display the output.
            MsgBox("The name chosen at random is " & name)

            ' This code produces the following output:
            '
            ' The name chosen at random is Ito, Shu
