    Private Sub AddButtonsToMyChildren()
        ' If there are child forms in the parent form, add Button controls to them.
        Dim x As Integer
        For x = 0 To (Me.MdiChildren.Length) - 1
            ' Create a temporary Button control to add to the child form.
            Dim tempButton As New Button()
            ' Set the location and text of the Button control.
            tempButton.Location = New Point(10, 10)
            tempButton.Text = "OK"
            ' Create a temporary instance of a child form (Form 2 in this case).
            Dim tempChild As Form = CType(Me.MdiChildren(x), Form)
            ' Add the Button control to the control collection of the form.
            tempChild.Controls.Add(tempButton)
        Next x
    End Sub 'AddButtonsToMyChildren