    Protected Overrides Sub RenderPartContents _
      (ByVal writer As HtmlTextWriter, ByVal part As WebPart)

      If part Is Me.WebPartManager.SelectedWebPart Then
        HttpContext.Current.Response.Write("<span>Not rendered</span>")
      Else
        If (Me.Zone.GetType() Is GetType(MyZone)) Then
          part.RenderControl(writer)
        End If
      End If

    End Sub