        Protected Overrides Function CreateCatalogPartChromeStyle(ByVal catalogPart As System.Web.UI.WebControls.WebParts.CatalogPart, ByVal chromeType As System.Web.UI.WebControls.WebParts.PartChromeType) As System.Web.UI.WebControls.Style
            Dim editorStyle As Style
            editorStyle = MyBase.CreateCatalogPartChromeStyle(catalogPart, chromeType)
            editorStyle.BackColor = Drawing.Color.Bisque
            Return editorStyle
        End Function