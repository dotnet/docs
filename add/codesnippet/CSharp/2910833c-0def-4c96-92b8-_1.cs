        protected override void  RenderPartContents(HtmlTextWriter writer, CatalogPart catalogPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            catalogPart.RenderControl(writer);
        }