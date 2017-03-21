        protected override void RenderPartContents(HtmlTextWriter writer, EditorPart editorPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            editorPart.RenderControl(writer);
        }