private void MyEnumerator() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);
 
    // Creates an enumerator for the collection.
    System.Collections.IEnumerator ie = attributes.GetEnumerator();
 
    // Prints the type of each attribute in the collection.
    Object myAttribute;
    while(ie.MoveNext()==true) {
       myAttribute = ie.Current;
       textBox1.Text += myAttribute.ToString();
       textBox1.Text += '\n';
    }
 }
