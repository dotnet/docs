  Protected Sub CheckBoxList1_SelectedItemIndexChanged(ByVal sender As [Object], ByVal e As EventArgs)
    Dim item As ListItem
    For Each item In CheckBoxList1.Items
      Dim theVerb As WebPartVerb
      Select Case item.Value
        Case "close"
          theVerb = WebPartZone1.CloseVerb
        Case "export"
          theVerb = WebPartZone1.ExportVerb
        Case "delete"
          theVerb = WebPartZone1.DeleteVerb
        Case "minimize"
          theVerb = WebPartZone1.MinimizeVerb
        Case "restore"
          theVerb = WebPartZone1.RestoreVerb
        Case Else
          theVerb = Nothing
      End Select

      If item.Selected Then
        theVerb.Enabled = True
      Else
        theVerb.Enabled = False
      End If
    Next item

  End Sub