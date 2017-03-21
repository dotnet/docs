  Protected Sub Button2_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    Label1.Text = "<h3>CatalogPart List</h3>"
    Dim part As CatalogPart
    For Each part In CatalogZone1.CatalogParts
      Label1.Text += part.ID + "<br />"
    Next part

  End Sub