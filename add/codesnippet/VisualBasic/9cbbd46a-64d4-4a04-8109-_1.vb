 Private Sub FindProperty()
     ' Creates a new collection and assign it the properties for button1.
     Dim properties As PropertyDescriptorCollection = _
        TypeDescriptor.GetProperties(button1)
        
     ' Sets a PropertyDescriptor to the specific property.
     Dim myProperty As PropertyDescriptor = properties.Find("Opacity", False)
        
     ' Prints the property and the property description.
     textBox1.Text = myProperty.DisplayName & _
        Microsoft.VisualBasic.ControlChars.Cr & myProperty.Description
 End Sub
