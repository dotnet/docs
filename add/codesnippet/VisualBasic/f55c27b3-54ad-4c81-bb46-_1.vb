        Protected Overrides Sub RenderPartContents(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal editorPart As System.Web.UI.WebControls.WebParts.EditorPart)
            writer.AddStyleAttribute("color", "red")
            writer.RenderBeginTag("p")
            writer.Write("Apply all changes")
            writer.RenderEndTag()
            editorPart.RenderControl(writer)
        End Sub