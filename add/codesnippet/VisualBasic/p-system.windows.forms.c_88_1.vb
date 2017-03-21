    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton

    Private Sub InitializeRadioButtonsAndGroupBox()

        ' Construct the GroupBox object.
        Me.GroupBox1 = New GroupBox

        ' Construct the radio buttons.
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton

        ' Set the location, tab and text for each radio button
        ' to a cursor from the Cursors enumeration.
        Me.RadioButton1.Location = New System.Drawing.Point(24, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Help"
        Me.RadioButton1.Tag = Cursors.Help
        Me.RadioButton1.TextAlign = ContentAlignment.MiddleCenter

        Me.RadioButton2.Location = New System.Drawing.Point(24, 56)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Up Arrow"
        Me.RadioButton2.Tag = Cursors.UpArrow
        Me.RadioButton2.TextAlign = ContentAlignment.MiddleCenter

        Me.RadioButton3.Location = New System.Drawing.Point(24, 80)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "Cross"
        Me.RadioButton3.Tag = Cursors.Cross
        Me.RadioButton3.TextAlign = ContentAlignment.MiddleCenter

        ' Add the radio buttons to the GroupBox.  
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)

        ' Set the location of the GroupBox. 
        Me.GroupBox1.Location = New System.Drawing.Point(56, 64)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 150)

        ' Set the text that will appear on the GroupBox.
        Me.GroupBox1.Text = "Choose a Cursor Style"
        '
        ' Add the GroupBox to the form.
        Me.Controls.Add(Me.GroupBox1)
        '

    End Sub