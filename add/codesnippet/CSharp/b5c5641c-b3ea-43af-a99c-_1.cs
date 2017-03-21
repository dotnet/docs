        protected override Style  CreateCatalogPartChromeStyle(CatalogPart catalogPart, PartChromeType chromeType)
        {
            Style catalogStyle = base.CreateCatalogPartChromeStyle(catalogPart, chromeType);
            catalogStyle.BackColor = Color.Bisque;
            return catalogStyle;
        }