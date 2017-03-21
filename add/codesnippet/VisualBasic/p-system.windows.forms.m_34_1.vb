    Private Sub DisplayText()
        Me.MaskedTextBox1.PasswordChar = CChar("*")

        Me.MaskedTextBox1.Mask = "000-00-0000" ' United States Social Security Number
        Me.MaskedTextBox1.Text = "999999999"

        Debug.WriteLine("MaskedControl.Text: " & Me.MaskedTextBox1.Text) ' Displays: 999-99-9
        Me.MaskedTextBox1.Text = ""

        ' Assigning text.
        Me.MaskedTextBox1.AllowPromptAsInput = True
        Me.MaskedTextBox1.Text = "999-99-9999" ' Works
        Me.MaskedTextBox1.Text = "999999999" ' Works
        Me.MaskedTextBox1.AllowPromptAsInput = False
        'Me.MaskedTextBox1.Text = "999-99-9999" ' Does not work
    End Sub