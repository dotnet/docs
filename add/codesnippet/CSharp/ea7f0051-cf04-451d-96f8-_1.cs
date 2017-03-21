        protected override Style CreateEditorPartChromeStyle(EditorPart editorPart, PartChromeType chromeType)
        {
            Style editorStyle = base.CreateEditorPartChromeStyle(editorPart, chromeType);
            editorStyle.BackColor = Color.Bisque;
            return editorStyle;
        }