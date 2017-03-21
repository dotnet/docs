' Add a GroupBox to a form and set some of its common properties.
Private Sub AddMyGroupBox()
   ' Create a GroupBox and add a TextBox to it.
   Dim groupBox1 As New GroupBox()
   Dim textBox1 As New TextBox()
   textBox1.Location = New Point(15, 15)
   groupBox1.Controls.Add(textBox1)
   
   ' Set the Text and Dock properties of the GroupBox.
   groupBox1.Text = "MyGroupBox"
   groupBox1.Dock = DockStyle.Top
   
   ' Disable the GroupBox (which disables all its child controls)
   groupBox1.Enabled = False
   
   ' Add the Groupbox to the form.
   Me.Controls.Add(groupBox1)
End Sub