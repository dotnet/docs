  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    Label1.Text = String.Empty
        
    Dim descriptions As WebPartDescriptionCollection = _
     DeclarativeCatalogPart1.GetAvailableWebPartDescriptions()
            
    Dim desc As WebPartDescription
        
    For Each desc In descriptions
      Label1.Text += "ID: " & desc.ID & "<br />" & _
        "Title: " & desc.Title & "<br />" & _
        "Description: " & desc.Description & "<br />" & _
        "ImageUrl: " & desc.CatalogIconImageUrl & "<br />" & _
        "<hr />"
    Next
    
  End Sub