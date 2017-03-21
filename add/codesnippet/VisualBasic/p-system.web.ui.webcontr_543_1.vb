  Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) 
    Dim builder As New StringBuilder()
    builder.AppendLine("<strong>WebPartZone2 WebPart IDs</strong><br />")
    Dim part As WebPart
    For Each part In  WebPartZone1.WebParts
      builder.AppendLine("ID: " + part.ID + "; Type: " _
                          + part.GetType().ToString() _
                          + "<br />")
    Next part
    Label2.Text = builder.ToString()
    Label2.Visible = True
  End Sub 