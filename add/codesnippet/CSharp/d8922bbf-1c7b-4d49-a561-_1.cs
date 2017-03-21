private void FindEvent() {
    // Creates a new collection and assigns it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Sets an EventDescriptor to the specific event.
    EventDescriptor myEvent = events.Find("Resize", false);
 
    // Prints the event name and event description.
    textBox1.Text = myEvent.Name + ": " + myEvent.Description;
 }
