
    ' Declare ToolBar1.
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar

    ' Initialize ToolBar1 with Bold(B), Italic(I), and Underline(U) buttons.
    Private Sub InitializeToolBar()
        ToolBar1 = New ToolBar

        ' Set the appearance to Flat.
        ToolBar1.Appearance = ToolBarAppearance.Flat

        ' Set the toolbar to dock at the bottom of the form.
        ToolBar1.Dock = DockStyle.Bottom

        ' Set the toolbar font to 14 points and bold.
        ToolBar1.Font = New System.Drawing.Font _
            (FontFamily.GenericSansSerif, 14, FontStyle.Bold)

        ' Declare fontstyle array with the three font styles.
        Dim fonts() As FontStyle = New FontStyle() _
            {FontStyle.Bold, FontStyle.Italic, FontStyle.Underline}
        Dim count As Integer

        ' Create a button for each value in the array, setting its text to the
        ' first letter of the style and its button's tag property.
        For count = 0 To fonts.Length - 1
            Dim fontButton As New ToolBarButton(fonts(count). _
                ToString.Substring(0, 1))
            fontButton.Style = ToolBarButtonStyle.ToggleButton
            fontButton.Tag = fonts(count)
            ToolBar1.Buttons.Add(fontButton)
        Next
        Me.Controls.Add(Me.ToolBar1)
    End Sub


    ' Declare FontStyle object, which defaults to the Regular FontStyle.
    Dim style As New FontStyle

    Private Sub ToolBar1_ButtonClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
        Handles ToolBar1.ButtonClick

        ' If a button is pushed, use a bitwise Or combination 
        ' of the style variable and the button tag, to set style to 
        ' the correct FontStyle. Set the button's PartialPush property to
        ' true for a Windows XP-like appearance.
        If (e.Button.Pushed) Then
            e.Button.PartialPush = True
            style = style Or e.Button.Tag

        Else
            ' If the button was not pushed, use a bitwise XOR 
            ' combination to turn off that style 
            ' and set the PartialPush property to False.
            e.Button.PartialPush = False
            style = style Xor e.Button.Tag
        End If

        ' Set the font using the existing RichTextBox font and the new
        ' style.
        RichTextBox1.Font = New Font(RichTextBox1.Font, style)
    End Sub