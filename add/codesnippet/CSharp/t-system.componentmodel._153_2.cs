private void GetAttributeValue() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);
 
    // Gets the designer attribute from the collection.
    DesignerAttribute myDesigner; 
    myDesigner = (DesignerAttribute)attributes[typeof(DesignerAttribute)];
 
    // Prints the value of the attribute in a text box.
    textBox1.Text = myDesigner.DesignerTypeName;
 }