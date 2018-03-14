
Partial Class querystrparam1vb_aspx
  Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' <snippet2>
        Dim empIdParam As New QueryStringParameter()
        empIdParam.Name = "empId"
        empIdParam.QueryStringField = "empId"

        AccessDataSource1.SelectParameters.Add(empIdParam)
        ' </snippet2>

        ' <snippet4>
        Dim employee As New QueryStringParameter("employee", "employee")
        MyAccessDataSource.SelectParameters.Add(employee)
        ' </snippet4>
    End Sub ' Page_Load
End Class
