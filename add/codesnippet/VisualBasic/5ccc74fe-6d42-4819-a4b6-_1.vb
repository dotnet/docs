            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            Dim index As Integer = 20

            ' Get a string at an index that is out of range in the array.
            Dim name As String = names.ElementAtOrDefault(index)

            Dim text As String = If(String.IsNullOrEmpty(name), "[THERE IS NO NAME AT THIS INDEX]", name)

            ' Display the output.
            MsgBox("The name chosen at index " & index & " is " & text)

            ' This code produces the following output:
            '
            ' The name chosen at index 20 is [THERE IS NO NAME AT THIS INDEX]
