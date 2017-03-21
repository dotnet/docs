        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim myColorDialog As New ColorDialog()
            ' Disable selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Enable the help button.
            myColorDialog.ShowHelp = True
            ' Set the initial color to the current color.
            myColorDialog.Color = myDataGrid.HeaderBackColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set the header background color.   
            myDataGrid.HeaderBackColor = myColorDialog.Color
        End Sub 'button1_Click

        ' Reset the header background color.
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            myDataGrid.ResetHeaderBackColor()
        End Sub 'button2_Click
