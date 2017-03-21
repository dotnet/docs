 Private Sub CreateMyFormat2()
     Dim myFormat As New DataFormats.Format("AnotherNewFormat", 20916)
        
     ' Displays the contents of myFormat.
     textBox1.Text = "ID value: " + myFormat.Id.ToString() + ControlChars.Cr _
                   + "Format name: " + myFormat.Name
 End Sub
 