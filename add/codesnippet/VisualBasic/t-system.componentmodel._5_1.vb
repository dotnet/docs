        ' Creates a new collection and assign it the properties for button1.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Button1)

        ' Sets an PropertyDescriptor to the specific property.
        Dim myProperty As PropertyDescriptor = properties.Find("Text", False)

        ' Prints the property and the property description.
        TextBox1.Text += myProperty.DisplayName & Microsoft.VisualBasic.ControlChars.Cr
        TextBox1.Text += myProperty.Description & Microsoft.VisualBasic.ControlChars.Cr
        TextBox1.Text += myProperty.Category & Microsoft.VisualBasic.ControlChars.Cr