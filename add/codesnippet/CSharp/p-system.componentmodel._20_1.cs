private void PrintIndexItem() {
    // Creates a new collection and assigns it the properties for button1.
    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);
 
    // Prints the second property's name.
    textBox1.Text = properties[1].ToString();
 }
