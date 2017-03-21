        Protected Overrides Sub RenderPartContents(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal catalogPart As System.Web.UI.WebControls.WebParts.CatalogPart)
            writer.AddStyleAttribute("color", "red")
            writer.RenderBeginTag("p")
            writer.Write("Apply all changes")
            writer.RenderEndTag()
            catalogPart.RenderControl(writer)
        End Sub