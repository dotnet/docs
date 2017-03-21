    Protected Overrides Sub OnDisplayModeChanged(ByVal sender _
      As Object, ByVal e As WebPartDisplayModeEventArgs)
      Me.BackColor = Color.LightGray
      MyBase.OnDisplayModeChanged(sender, e)
    End Sub