  Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty

    Dim zoneCollection As WebPartZoneCollection = mgr.Zones
    Dim zone As WebPartZone
    For Each zone In zoneCollection
      If zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu Then
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar
      Else
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu
      End If
    Next zone

  End Sub