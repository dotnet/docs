    ' Initialize a single-panel status bar.  This is done
    ' by setting the Text property and setting ShowPanels to False.
    Private Sub InitializeSimpleStatusBar()

        ' Declare the StatusBar control
        Dim simpleStatusBar As New StatusBar

        ' Set the ShowPanels property to False.
        simpleStatusBar.ShowPanels = False

        ' Set the text.
        simpleStatusBar.Text = "This is a single-panel status bar"

        ' Set the width and anchor the StatusBar
        simpleStatusBar.Width = 200
        simpleStatusBar.Anchor = AnchorStyles.Top

        ' Add the StatusBar to the form.
        Me.Controls.Add(simpleStatusBar)

    End Sub