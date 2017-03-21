  Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Dim zoneArray(mgr.Zones.Count) As WebPartZoneBase
    mgr.Zones.CopyTo(zoneArray, 0)
    Label1.Text = zoneArray(2).ID
    Label1.Text += ", " & zoneArray(1).ID
    Label1.Text += ", " & zoneArray(0).ID

  End Sub