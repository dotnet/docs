            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            ' Select the first string in the array whose length is greater than 20.
            Dim firstLongName As String =
            names.FirstOrDefault(Function(name) name.Length > 20)

            ' Display the output.
            MsgBox("The first long name is " & firstLongName)

            ' Select the first string in the array whose length is greater than 30,
            ' or a default value if there are no such strings in the array.
            Dim firstVeryLongName As String =
            names.FirstOrDefault(Function(name) name.Length > 30)

            Dim text As String = IIf(String.IsNullOrEmpty(firstVeryLongName), "not a", "a")

            MsgBox("There is " & text & " name longer than 30 characters.")

            ' This code produces the following output:
            '
            ' The first long name is Andersen, Henriette Thaulow
            '
            ' There is not a name longer than 30 characters.
