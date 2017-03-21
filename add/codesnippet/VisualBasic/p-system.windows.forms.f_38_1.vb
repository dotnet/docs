    Public Sub ClearAllChildFormText()
        ' Obtain a reference to the currently active MDI child form.
        Dim tempChild As Form = Me.ActiveMdiChild
        
        ' Loop through all controls on the child form.
        Dim i As Integer
        For i = 0 To tempChild.Controls.Count - 1
            ' Determine if the current control on the child form is a TextBox.
            If TypeOf tempChild.Controls(i) Is TextBox Then
                ' Clear the contents of the control since it is a TextBox.
                tempChild.Controls(i).Text = ""
            End If
        Next i
    End Sub 'ClearAllChildFormText