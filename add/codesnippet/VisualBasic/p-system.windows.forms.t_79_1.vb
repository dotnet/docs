    'Declare a textbox called TextBox1.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    'Initialize TextBox1.
    Private Sub InitializeTextBox()
        Me.TextBox1 = New TextBox
        Me.TextBox1.Location = New System.Drawing.Point(32, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Type and hit enter here..."

        'Keep the selection highlighted, even after textbox loses focus.
        TextBox1.HideSelection = False
        Me.Controls.Add(TextBox1)
    End Sub