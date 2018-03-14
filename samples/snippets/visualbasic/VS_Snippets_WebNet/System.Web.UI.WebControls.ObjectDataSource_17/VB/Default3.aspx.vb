
Partial Class Default3
    Inherits System.Web.UI.Page

    '<Snippet2>
    Protected Sub rowsToDisplay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rowsToDisplay.SelectedIndexChanged
        GridView1.PageSize = Integer.Parse(rowsToDisplay.SelectedValue)
    End Sub
    '</Snippet2>
End Class
