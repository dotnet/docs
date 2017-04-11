
Partial Class _Default
    Inherits System.Web.UI.Page
    '<snippet1>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gwp As GenericWebPart
        gwp = Control1.Parent
        gwp.ExportMode = WebPartExportMode.All
    End Sub
    '</snippet1>
End Class
