 Private Sub GetMyFormatInfomation()
     ' Creates a DataFormats.Format for the Unicode data format.
     Dim myFormat As DataFormats.Format = _
        DataFormats.GetFormat(DataFormats.UnicodeText)
        
     ' Displays the contents of myFormat.
     textBox1.Text = "ID value: " + myFormat.Id.ToString() + ControlChars.Cr _
                   + "Format name: " + myFormat.Name
 End Sub
