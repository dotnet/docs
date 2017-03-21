Public Sub Profile_ProfileAutoSaving(sender As Object, args As ProfileAutoSaveEventArgs)
  If Profile.Cart.HasChanged Then
    args.ContinueWithProfileAutoSave = True
  Else
    args.ContinueWithProfileAutoSave = False
  End If
End Sub