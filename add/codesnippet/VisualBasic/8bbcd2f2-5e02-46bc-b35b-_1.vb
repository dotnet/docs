        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                           "Andersen, Henriette Thaulow", _
                           "Hedlund, Magnus", "Ito, Shu"}

        Dim index As Integer = 20

        Dim name As String = names.AsQueryable().ElementAtOrDefault(index)

        MsgBox(String.Format("The name at index {0} is '{1}'.", _
            index, IIf(String.IsNullOrEmpty(name), "[NONE AT THIS INDEX]", name)))

        ' This code produces the following output:
        '
        ' The name at index 20 is '[NONE AT THIS INDEX]'.
