    Sub Page_Load
        If Not IsPostBack
            ' Validate initially to force the asterisks
            ' to appear before the first roundtrip.
            Validate()
        End If
    End Sub