Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load()

    End Sub

    ' <Snippet2>
    Protected Sub CheckReorderStatus()
        Dim dv As DataView
        Dim reorderedProducts As Integer

        dv = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
        reorderedProducts = CType(dv.Table.Rows(0)(0), Integer)
        If (reorderedProducts > 0) Then
            Label1.Text = "Number of products on reorder: " & reorderedProducts
        Else
            Label1.Text = "No products on reorder."
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        CheckReorderStatus()
    End Sub
    ' </Snippet2>

End Class
