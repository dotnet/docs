Imports System.Web.Routing

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' <Snippet2>
        Dim vpd As VirtualPathData
        Dim parameters As RouteValueDictionary

        parameters = New RouteValueDictionary(New With {.action = "show", .categoryName = "bikes"})
        vpd = RouteTable.Routes.GetVirtualPath(Nothing, parameters)
        HyperLink1.NavigateUrl = vpd.VirtualPath
        ' </Snippet2>
    End Sub
End Class
