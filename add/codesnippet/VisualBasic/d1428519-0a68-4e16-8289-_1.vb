  Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Label1.Text = "WebPartZone1 index:  " & mgr.Zones.IndexOf(WebPartZone1)

  End Sub