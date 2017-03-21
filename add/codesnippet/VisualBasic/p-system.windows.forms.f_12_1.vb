    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Set FontMustExist to true, which causes message box error
        ' if the user enters a font that does not exist. 
        FontDialog1.FontMustExist = True

        ' Set a minimum and maximum size to be
        ' shown in the FontDialog.
        FontDialog1.MaxSize = 32
        FontDialog1.MinSize = 18

        ' Show the Apply button in the dialog.
        FontDialog1.ShowApply = True

        ' Do not show effects such as Underline
        ' and Bold.
        FontDialog1.ShowEffects = False

        ' Save the existing font.
        Dim oldFont As System.Drawing.Font = Me.Font

        ' Show the dialog and save the result.
        Dim result As DialogResult = FontDialog1.ShowDialog()

        ' If The OK button in the Font dialog box is clicked, 
        ' set all the controls' fonts to the chosen font by
        ' calling the FontDialog1_Apply method.
        If result = DialogResult.OK Then
            FontDialog1_Apply(Me.Button1, New System.EventArgs)

            ' If the Cancel button is clicked, set the controls'
            ' fonts back to the original font.
        ElseIf (result = DialogResult.Cancel) Then
            Dim containedControl As Control
            For Each containedControl In Me.Controls
                containedControl.Font = oldFont
            Next

        End If
    End Sub

    ' Handle the Apply event by setting all controls' fonts to 
    ' the chosen font. 
    Private Sub FontDialog1_Apply(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles FontDialog1.Apply

        Me.Font = FontDialog1.Font
        Dim containedControl As Control
        For Each containedControl In Me.Controls
            containedControl.Font = FontDialog1.Font
        Next
    End Sub