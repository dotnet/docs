  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) 
    If WebPartZone1.LayoutOrientation = Orientation.Vertical Then
        WebPartZone1.LayoutOrientation = Orientation.Horizontal
    Else
        WebPartZone1.LayoutOrientation = Orientation.Vertical
    End If
    Page_Load(sender, e)
  End Sub 