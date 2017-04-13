Imports Microsoft.VisualBasic

' <Snippet2>
Namespace Samples.AspNet.VB.Controls


    Public Class MyCatalogPartChrome
        Inherits CatalogPartChrome

        Public Sub New(ByVal zone As CatalogZoneBase)
            MyBase.New(zone)
        End Sub

        ' <Snippet3>
        Protected Overrides Function CreateCatalogPartChromeStyle(ByVal catalogPart As System.Web.UI.WebControls.WebParts.CatalogPart, ByVal chromeType As System.Web.UI.WebControls.WebParts.PartChromeType) As System.Web.UI.WebControls.Style
            Dim editorStyle As Style
            editorStyle = MyBase.CreateCatalogPartChromeStyle(catalogPart, chromeType)
            editorStyle.BackColor = Drawing.Color.Bisque
            Return editorStyle
        End Function
        ' </Snippet3>

        ' <Snippet4>
        Public Overrides Sub PerformPreRender()
            Dim zoneStyle As Style = New Style
            zoneStyle.BackColor = Drawing.Color.Cornsilk

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, Nothing)
            Zone.MergeStyle(zoneStyle)
        End Sub
        ' </Snippet4>

        ' <Snippet5>
        Protected Overrides Sub RenderPartContents(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal catalogPart As System.Web.UI.WebControls.WebParts.CatalogPart)
            writer.AddStyleAttribute("color", "red")
            writer.RenderBeginTag("p")
            writer.Write("Apply all changes")
            writer.RenderEndTag()
            catalogPart.RenderControl(writer)
        End Sub
        ' </Snippet5>

        Public Overrides Sub RenderCatalogPart(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal catalogPart As System.Web.UI.WebControls.WebParts.CatalogPart)
            MyBase.RenderCatalogPart(writer, catalogPart)
        End Sub
    End Class

    Public Class MyCatalogZone
        Inherits CatalogZone

        Protected Overrides Function CreateCatalogPartChrome() As System.Web.UI.WebControls.WebParts.CatalogPartChrome
            Return New MyCatalogPartChrome(Me)
        End Function
    End Class
End Namespace
' </Snippet2>
