
Partial Class Default2
    Inherits System.Web.UI.Page

    ' <Snippet2>
    Protected Sub LinqDataSource1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceStatusEventArgs) Handles LinqDataSource1.Selected
        Literal1.Text = e.TotalRowCount.ToString()
    End Sub
    ' </Snippet2>
End Class
