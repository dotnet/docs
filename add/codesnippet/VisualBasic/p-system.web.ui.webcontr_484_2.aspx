  Protected Sub Button5_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    CatalogZone1.PartLinkStyle.ForeColor = _
      System.Drawing.Color.Red
    CatalogZone1.SelectedPartLinkStyle.ForeColor = _
      System.Drawing.Color.Blue
  End Sub