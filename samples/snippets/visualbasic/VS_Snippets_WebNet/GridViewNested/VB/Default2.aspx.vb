
Partial Class _Default2
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        '<Snippet2>
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim s As SqlDataSource = CType(e.Row.FindControl("SqlDataSource2"), SqlDataSource)
            s.FilterParameters(0).DefaultValue = e.Row.Cells(0).Text
        End If
        '</Snippet2>
    End Sub
End Class
