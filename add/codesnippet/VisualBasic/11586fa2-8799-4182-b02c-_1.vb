        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                             "Andersen, Henriette Thaulow", _
                             "Hedlund, Magnus", "Ito, Shu"}

        ' Get the first string in the array that is longer
        ' than 20 characters, or the default value for type
        ' string (null) if none exists.
        Dim firstLongName As String = _
                    names.AsQueryable().FirstOrDefault(Function(name) name.Length > 20)

        MsgBox(String.Format("The first long name is '{0}'.", firstLongName))

        ' Get the first string in the array that is longer
        ' than 30 characters, or the default value for type
        ' string (null) if none exists.
        Dim firstVeryLongName As String = _
            names.AsQueryable().FirstOrDefault(Function(name) name.Length > 30)

        MsgBox(String.Format( _
            "There is {0} name that is longer than 30 characters.", _
            IIf(String.IsNullOrEmpty(firstVeryLongName), "NOT a", "a")))

        ' This code produces the following output:
        '
        ' The first long name is 'Andersen, Henriette Thaulow'.
        ' There is NOT a name that is longer than 30 characters.
