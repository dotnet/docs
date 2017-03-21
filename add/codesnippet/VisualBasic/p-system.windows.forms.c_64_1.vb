    ' This method initializes CheckedListBox1 with a list of all the controls
    ' on the form. It sets the selection mode to single selection and
    ' allows selection with a single click. It adds itself to the list before 
    ' adding itself to the form.
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox

    Private Sub InitializeCheckedListBox()
        Me.CheckedListBox1 = New CheckedListBox
        Me.CheckedListBox1.Location = New System.Drawing.Point(40, 90)
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 94)
        Me.CheckedListBox1.TabIndex = 1
        Me.CheckedListBox1.SelectionMode = SelectionMode.One
        Me.CheckedListBox1.ThreeDCheckBoxes = True

        Dim aControl As Control
        For Each aControl In Me.Controls
            Me.CheckedListBox1.Items.Add(aControl, False)
        Next

        Me.CheckedListBox1.DisplayMember = "Name"
        Me.CheckedListBox1.Items.Add(CheckedListBox1)
        Me.Controls.Add(Me.CheckedListBox1)
    End Sub