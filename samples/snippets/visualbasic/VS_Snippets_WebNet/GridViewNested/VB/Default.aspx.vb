
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        '<Snippet1>
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim s As SqlDataSource = CType(e.Row.FindControl("SqlDataSource2"), SqlDataSource)
            s.SelectParameters(0).DefaultValue = e.Row.Cells(0).Text
        End If
        '</Snippet1>
    End Sub
End Class
