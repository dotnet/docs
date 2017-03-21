
    ' Declare comboBox1 as a ComboBox.
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

    ' This method initializes the combo box, adding a large string 
    ' array but limiting the drop-down size to six rows so the combo box
    ' doesn't cover other controls when it expands.
    Private Sub InitializeComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Dim employees() As String = New String() {"Hamilton, David", _
            "Hensien, Kari", "Hammond, Maria", "Harris, Keith", _
            "Henshaw, Jeff D.", "Hanson, Mark", "Harnpadoungsataya, Sariya", _
            "Harrington, Mark", "Harris, Keith", "Hartwig, Doris", _
            "Harui, Roger", "Hassall, Mark", "Hasselberg, Jonas", _
            "Harnpadoungsataya, Sariya", "Henshaw, Jeff D.", "Henshaw, Jeff D.", _
            "Hensien, Kari", "Harris, Keith", "Henshaw, Jeff D.", _
            "Hensien, Kari", "Hasselberg, Jonas", "Harrington, Mark", _
            "Hedlund, Magnus", "Hay, Jeff", "Heidepriem, Brandon D."}

        ComboBox1.Items.AddRange(employees)
        Me.ComboBox1.Location = New System.Drawing.Point(136, 32)
        Me.ComboBox1.IntegralHeight = False
        Me.ComboBox1.MaxDropDownItems = 5
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 81)
        Me.ComboBox1.TabIndex = 0
        Me.Controls.Add(Me.ComboBox1)
    End Sub

