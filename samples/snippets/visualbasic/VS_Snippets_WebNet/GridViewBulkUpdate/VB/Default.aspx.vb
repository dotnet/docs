'<Snippet6>
Partial Class VB_Default
    Inherits System.Web.UI.Page

    '<Snippet1>
    Private tableCopied As Boolean = False
    Private originalDataTable As System.Data.DataTable

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not tableCopied Then
                originalDataTable = CType(e.Row.DataItem, System.Data.DataRowView).Row.Table.Copy()
                ViewState("originalValuesDataTable") = originalDataTable
                tableCopied = True
            End If
        End If
    End Sub
    '</Snippet1>

    '<Snippet2>
    Protected Sub UpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UpdateButton.Click
        originalDataTable = CType(ViewState("originalValuesDataTable"), System.Data.DataTable)

        For Each r As GridViewRow In GridView1.Rows
            If IsRowModified(r) Then GridView1.UpdateRow(r.RowIndex, False)
        Next

        ' Rebind the Grid to repopulate the original values table.
        tableCopied = False
        GridView1.DataBind()
    End Sub

    Protected Function IsRowModified(ByVal r As GridViewRow) As Boolean
        Dim currentID As Integer
        Dim currentLastName As String
        Dim currentFirstName As String

        currentID = Convert.ToInt32(GridView1.DataKeys(r.RowIndex).Value)

        currentLastName = CType(r.FindControl("LastNameTextBox"), TextBox).Text
        currentFirstName = CType(r.FindControl("FirstNameTextBox"), TextBox).Text

        Dim row As System.Data.DataRow = _
            originalDataTable.Select(String.Format("EmployeeID = {0}", currentID))(0)

        If Not currentLastName.Equals(row("LastName").ToString()) Then Return True
        If Not currentFirstName.Equals(row("FirstName").ToString()) Then Return True

        Return False
    End Function
    '</Snippet2>

End Class
'</Snippet6>