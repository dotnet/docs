    Protected Overrides Function CreateWebPartChromeStyle _
      (ByVal part As WebPart, ByVal chromeType As PartChromeType) As Style

      Dim finalStyle As New Style()
      finalStyle.CopyFrom(MyBase.CreateWebPartChromeStyle(Part, chromeType))
      finalStyle.Font.Name = "Verdana"
      Return finalStyle
    End Function