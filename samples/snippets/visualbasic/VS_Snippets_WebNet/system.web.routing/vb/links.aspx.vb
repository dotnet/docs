'<Snippet110>
Imports System.Web.Routing
'</Snippet110>

Partial Class Links
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '<Snippet128>
        '<Snippet120>
        Dim parameters As RouteValueDictionary
        parameters = New RouteValueDictionary(New With _
                 {.locale = "CA", .year = "2008"})
        '</Snippet120>

        '<Snippet122>
        Dim vpd As VirtualPathData
        vpd = RouteTable.Routes.GetVirtualPath(Nothing, "ExpensesRoute", parameters)
        '</Snippet122>

        '<Snippet124>
        HyperLink6.NavigateUrl = vpd.VirtualPath
        '</Snippet124>
        '</Snippet128>
    End Sub
End Class
