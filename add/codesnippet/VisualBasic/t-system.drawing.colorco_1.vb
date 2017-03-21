    
    Private Sub ShowColorConverter(ByVal e As PaintEventArgs)

        Dim myColor As Color = Color.PaleVioletRed

        ' Create the ColorConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
           System.ComponentModel.TypeDescriptor.GetConverter(myColor)

        Dim colorAsString As String = _
            converter.ConvertToString(Color.PaleVioletRed)
        e.Graphics.DrawString(colorAsString, Me.Font, _
            Brushes.PaleVioletRed, 50.0F, 50.0F)
    End Sub