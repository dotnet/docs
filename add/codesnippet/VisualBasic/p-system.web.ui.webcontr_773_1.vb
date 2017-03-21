  Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim builder As New StringBuilder()
    builder.AppendLine("<strong>WebPartZone1 DisplayTitle Property</strong><br />")
    builder.AppendLine(WebPartZone1.DisplayTitle + "<br />")
    Label2.Text = builder.ToString()
    Label2.Visible = True
  End Sub