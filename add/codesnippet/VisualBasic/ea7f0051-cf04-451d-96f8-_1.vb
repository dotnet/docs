        Protected Overrides Function CreateEditorPartChromeStyle(ByVal editorPart As System.Web.UI.WebControls.WebParts.EditorPart, ByVal chromeType As System.Web.UI.WebControls.WebParts.PartChromeType) As System.Web.UI.WebControls.Style
            Dim editorStyle As Style
            editorStyle = MyBase.CreateEditorPartChromeStyle(editorPart, chromeType)
            editorStyle.BackColor = Drawing.Color.Bisque
            Return editorStyle
        End Function