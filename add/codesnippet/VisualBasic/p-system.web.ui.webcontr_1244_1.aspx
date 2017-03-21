Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) 
    Dim list As New ArrayList(2)
    list.Add(PageCatalogPart1)
    list.Add(DeclarativeCatalogPart1)
    ' Pass an ICollection object to the constructor.
    Dim myParts As New CatalogPartCollection(list)
    Dim catalog As CatalogPart
    For Each catalog In  myParts
        catalog.Description = "My " + catalog.DisplayTitle
    Next catalog
    
    ' Use the IndexOf property to locate a CatalogPart control.
    Dim PageCatalogPartIndex As Integer = _
      myParts.IndexOf(PageCatalogPart1)
    myParts(PageCatalogPartIndex).ChromeType = PartChromeType.TitleOnly
    
    ' Use the Contains method to see if a CatalogPart control exists.
    If myParts.Contains(PageCatalogPart1) Then
        Dim closedWebPart As WebPart = Nothing
        Dim descriptions As WebPartDescriptionCollection = _
          PageCatalogPart1.GetAvailableWebPartDescriptions()
        If descriptions.Count > 0 Then
            closedWebPart = PageCatalogPart1.GetWebPart(descriptions(0))
            closedWebPart.AllowClose = False
        End If
    End If
    
    ' Use indexers to display the details of the CatalogPart controls.
    Label1.Text = String.Empty
    Label1.Text = _
      "<h3>PageCatalogPart Details</h3>" & _
      "ID: " & myParts(0).ID + "<br />" & _
      "Count: " & myParts(0).GetAvailableWebPartDescriptions().Count
    Label1.Text += _
      "<h3>DeclarativeCatalogPart Details</h3>" & _
      "ID: " & myParts("DeclarativeCatalogPart1").ID & "<br />" & _
      "Count: " & myParts("DeclarativeCatalogPart1") _
        .GetAvailableWebPartDescriptions().Count

End Sub 