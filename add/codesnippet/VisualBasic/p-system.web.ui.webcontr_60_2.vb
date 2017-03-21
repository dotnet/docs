    Protected Sub LinqDataSource1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceStatusEventArgs) Handles LinqDataSource1.Selected
        Literal1.Text = e.TotalRowCount.ToString()
    End Sub