
Partial Class sessionparam2vb_aspx
    	Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' <Snippet1>
        ' In this example, the session parameter "empid" is set
        ' after the employee successfully logs in.
        Dim empid As New SessionParameter()
        empid.Name = "empid"
        empid.Type = TypeCode.Int32
        empid.SessionField = "empid"
        ' </Snippet1>
    End Sub ' Page_Load
End Class
