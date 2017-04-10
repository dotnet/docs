' <snippet2>
Partial Class PanelStylevb_aspx
    Inherits Page

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        Dim panelState As StateBag = New StateBag()
        Dim myPanelStyle As PanelStyle = New PanelStyle(panelState)

        ' Set the properties of the PanelStyle class.
        myPanelStyle.HorizontalAlign = HorizontalAlign.Center
        myPanelStyle.ScrollBars = ScrollBars.Both
        myPanelStyle.Wrap = False
        myPanelStyle.Direction = ContentDirection.LeftToRight
        myPanelStyle.BackImageUrl = "~\images\picture.jpg"

        ' Use the ApplyStyle method of the Panel control to apply
        ' the settings from the myPanelStyle object.
        Panel1.ApplyStyle(myPanelStyle)
        Panel2.ApplyStyle(myPanelStyle)
        
    End Sub

End Class
' </snippet2>
