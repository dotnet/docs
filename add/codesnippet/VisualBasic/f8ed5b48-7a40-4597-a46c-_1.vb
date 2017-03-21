    Protected Overrides Sub OnSelectedWebPartChanged(ByVal sender _
      As Object, ByVal e As WebPartEventArgs)
      If Not (e.WebPart Is Nothing) Then
        e.WebPart.Zone.SelectedPartChromeStyle.BackColor = _
          Color.LightGreen
      End If
      MyBase.OnSelectedWebPartChanged(sender, e)

    End Sub