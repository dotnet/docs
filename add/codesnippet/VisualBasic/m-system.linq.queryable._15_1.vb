        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                           "Andersen, Henriette Thaulow", _
                           "Hedlund, Magnus", "Ito, Shu"}

        Dim rand As New Random(DateTime.Now.Millisecond)

        Dim name As String = _
            names.AsQueryable().ElementAt(rand.Next(0, names.Length))

        MsgBox(String.Format("The name chosen at random is '{0}'.", name))

        ' This code produces the following sample output.
        ' Yours may be different due to the use of Random.
        '
        ' The name chosen at random is 'Ito, Shu'.
