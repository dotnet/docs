    Private Sub MyForm_Resize(sender As Object, e As EventHandler)
        ' Set the size of button1 to the size of the client area of the form.
        button1.Size = Me.ClientSize
    End Sub 'MyForm_Resize