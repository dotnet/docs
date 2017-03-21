    ' Declare a label.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    
    ' Initialize the label.
    Private Sub InitializeLabel()
        Me.Label1 = New Label
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0

        ' Set the label to a small size, but set the AutoSize property 
        ' to true. The label will adjust its length so all the text
        ' is visible, however if the label is wider than the form,
        ' the entire label will not be visible.
        Me.Label1.Size = New System.Drawing.Size(10, 10)
        Me.Controls.Add(Me.Label1)
        Me.Label1.AutoSize = True
        Me.Label1.Text = "The text in this label is longer than the set size."

    End Sub