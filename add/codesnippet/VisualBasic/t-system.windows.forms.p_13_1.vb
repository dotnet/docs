 Public Sub New()
        
     ' The initial constructor code goes here.
     
     Dim propertyGrid1 As New PropertyGrid()
     propertyGrid1.CommandsVisibleIfAvailable = True
     propertyGrid1.Location = New Point(10, 20)
     propertyGrid1.Size = New System.Drawing.Size(400, 300)
     propertyGrid1.TabIndex = 1
     propertyGrid1.Text = "Property Grid"
        
     Me.Controls.Add(propertyGrid1)
        
     propertyGrid1.SelectedObject = textBox1
 End Sub