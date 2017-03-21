    Private numericUpDown1 As NumericUpDown
    
    Private Sub InitializeAcceleratedUpDown() 
        numericUpDown1 = New NumericUpDown()
        numericUpDown1.Location = New Point(40, 40)
        numericUpDown1.Maximum = 40000
        numericUpDown1.Minimum = - 40000
        
        ' Add some accelerations to the control.
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(2, 100))
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(5, 1000))
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(8, 5000))
        Controls.Add(numericUpDown1)
    
    End Sub
     