' <snippet4>
Partial Class param1avb_aspx
   Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim sqlSource As SqlDataSource

        sqlSource = New SqlDataSource(ConfigurationManager.ConnectionStrings("MyNorthwind").ConnectionString, "SELECT FirstName, LastName FROM Employees WHERE Country = @country;")
        ' <snippet2>
        Dim country As New ControlParameter()
        country.Name = "country"
        country.Type = TypeCode.String
        country.ControlID = "DropDownList1"
        country.PropertyName = "SelectedValue"
        ' </snippet2>
        ' <snippet3>
        ' If the DefaultValue is not set, the DataGrid does not
        ' display anything on the first page load. This is because
        ' on the first page load, the DropDownList has no
        ' selected item, and the ControlParameter evaluates to
        ' String.Empty.
        country.DefaultValue = "USA"
        ' </snippet3>
        sqlSource.SelectParameters.Add(country)

        ' Add the SqlDataSource to the page controls collection.
        Page.Controls.Add(sqlSource)


        DataGrid1.DataSource = sqlSource
        DataGrid1.DataBind()

    End Sub 'Page_Load
End Class
' </snippet4>