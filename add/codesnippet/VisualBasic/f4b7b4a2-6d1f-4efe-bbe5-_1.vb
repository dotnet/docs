        ' Draw the tab page and the tab items.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not TabRenderer.IsSupported Then
                Me.Parent.Text = "CustomTabControl Disabled"
                Return
            End If

            TabRenderer.DrawTabPage(e.Graphics, tabPageRectangle)
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle1, _
                tab1Text, Me.Font, tab1Focused, tab1State)
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle2, _
                tab2Text, Me.Font, tab2Focused, tab2State)
            Me.Parent.Text = "CustomTabControl Enabled"
        End Sub
