    private void MyPropertyCollection() {
        // Creates a new collection and assign it the properties for button1.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);
     
        // Displays each property in the collection in a text box.
        foreach (PropertyDescriptor myProperty in properties)
           textBox1.Text += myProperty.Name + '\n';
     }