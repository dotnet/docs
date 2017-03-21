    ' This method will adjust the size of the form to utilize 
    ' the working area of the screen.

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Retrieve the working rectangle from the Screen class
        ' using the PrimaryScreen and the WorkingArea properties. 
        Dim workingRectangle As System.Drawing.Rectangle = _
            Screen.PrimaryScreen.WorkingArea

        ' Set the size of the form slightly less than size of 
        ' working rectangle.
        Me.Size = New System.Drawing.Size(workingRectangle.Width - 10, _
            workingRectangle.Height - 10)

        ' Set the location so the entire form is visible.
        Me.Location = New System.Drawing.Point(5, 5)

    End Sub