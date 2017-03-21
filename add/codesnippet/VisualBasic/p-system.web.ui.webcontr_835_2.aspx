  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    If CatalogZone1.AddVerb.Enabled Then
      CatalogZone1.AddVerb.Enabled = False
      CatalogZone1.CloseVerb.Enabled = False
    Else
      CatalogZone1.AddVerb.Enabled = True
      CatalogZone1.CloseVerb.Enabled = True
    End If

  End Sub