 Private Sub GetCount()
     ' Creates a new collection and assign it the properties for button1.
     Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        
     ' Prints the number of properties on button1 in a textbox.
     textBox1.Text = properties.Count.ToString()
 End Sub
