    protected override Style CreateWebPartChromeStyle(WebPart part, 
      PartChromeType chromeType)
    {
      Style finalStyle = new Style();
      finalStyle.CopyFrom(base.CreateWebPartChromeStyle(part, chromeType));
      finalStyle.Font.Name = "Verdana";
      return finalStyle;
    }