    Protected Sub LinqDataSource_ContextCreating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceContextEventArgs)
        e.ObjectInstance = New ExampleDataContext(ConfigurationManager.ConnectionStrings("ExampleConnectionString").ConnectionString)
    End Sub