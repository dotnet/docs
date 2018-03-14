
Partial Class Default2
    Inherits System.Web.UI.Page
    ' <Snippet4>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not (IsPostBack) Then
            Cache(ObjectDataSource2.CacheKeyDependency) = "CacheExample"
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Cache.Remove(ObjectDataSource2.CacheKeyDependency)
        Cache(ObjectDataSource2.CacheKeyDependency) = "CacheExample"
        DetailsView1.DataBind()
    End Sub
    ' </Snippet4>
End Class
