Private Sub EditRow(view As DataView)
    view.AllowEdit = True
    view(0).BeginEdit
    view(0)("FirstName") = "Mary"
    view(0)("LastName") = "Jones"
    view(0).EndEdit
End Sub