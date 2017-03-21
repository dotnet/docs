    
    ' Declare ComboBox1.
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    
    ' Initialize ComboBox1.
    Private Sub InitializeComboBox()
        Me.ComboBox1 = New ComboBox
        Me.ComboBox1.Location = New System.Drawing.Point(128, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "Typical"
        Dim installs() As String = New String() _
            {"Typical", "Compact", "Custom"}
        ComboBox1.Items.AddRange(installs)
        Me.Controls.Add(Me.ComboBox1)
    End Sub

    ' Handles the ComboBox1 DropDown event. If the user expands the  
    ' drop-down box, a message box will appear, recommending the
    ' typical installation.
    Private Sub ComboBox1_DropDown _ 
        (ByVal sender As Object, ByVal e As System.EventArgs) _ 
        Handles ComboBox1.DropDown
        MessageBox.Show("Typical installation is strongly recommended.", _
        "Install information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub