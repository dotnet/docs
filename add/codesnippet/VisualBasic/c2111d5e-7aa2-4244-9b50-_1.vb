    Public Sub DrawVisualStyleElementToolBarSplitButtonDropDown6(ByVal e As PaintEventArgs)
        If (VisualStyleRenderer.IsElementDefined( _
         VisualStyleElement.ToolBar.SplitButtonDropDown.HotChecked)) Then
            Dim renderer As New VisualStyleRenderer _
              (VisualStyleElement.ToolBar.SplitButtonDropDown.HotChecked)
            Dim rectangle1 As New Rectangle(10, 50, 50, 50)
            renderer.DrawBackground(e.Graphics, rectangle1)
            e.Graphics.DrawString("VisualStyleElement.ToolBar.SplitButtonDropDown.HotChecked", _
              Me.Font, Brushes.Black, New Point(10, 10))
        Else
            e.Graphics.DrawString("This element is not defined in the current visual style.", _
              Me.Font, Brushes.Black, New Point(10, 10))
        End If
    End Sub