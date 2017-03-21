        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
            Dim myColorDialog As New ColorDialog()
            ' Disable selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Enable the help button.
            myColorDialog.ShowHelp = True
            ' Set the initial color to the current color.
            myColorDialog.Color = myDataGrid.HeaderForeColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set the header foreground color.
            myDataGrid.HeaderForeColor = myColorDialog.Color
        End Sub 'button3_Click

        ' Reset the header foregroundcolor.
        Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
            myDataGrid.ResetHeaderForeColor()
        End Sub 'button4_Click
