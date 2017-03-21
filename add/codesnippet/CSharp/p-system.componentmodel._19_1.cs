private void PrintIndexItem() {
    // Creates a new collection and assigns it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Prints the second event's name.
    textBox1.Text = events[1].ToString();
 }
