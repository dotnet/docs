    Private Sub MyPropertyCollection()
        ' Creates a new collection and assign it the properties for button1.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        
        ' Displays each property in the collection in a text box.
        Dim myProperty As PropertyDescriptor
        For Each myProperty In  properties
            textBox1.Text &= myProperty.Name & ControlChars.Cr
        Next myProperty
    End Sub 'MyPropertyCollection 