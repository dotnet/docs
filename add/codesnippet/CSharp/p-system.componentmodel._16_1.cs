private void GetCount() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);
 
    // Prints the number of items in the collection.
    textBox1.Text = attributes.Count.ToString();
 }
