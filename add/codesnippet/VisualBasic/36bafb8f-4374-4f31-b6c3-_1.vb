  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Label1.Text = mgr.Zones.Contains(WebPartZone2).ToString()

  End Sub