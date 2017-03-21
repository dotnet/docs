    Private Sub ChangeTheLookOfTheTabControl()

        ' Set the size and location of the TabControl.
        Me.TabControl1.Location = New System.Drawing.Point(20, 20)
        TabControl1.Size = New System.Drawing.Size(250, 250)

        ' Align the tabs along the bottom of the control.
        TabControl1.Alignment = TabAlignment.Bottom

        ' Change the tabs to flat buttons.
        TabControl1.Appearance = TabAppearance.FlatButtons
    End Sub