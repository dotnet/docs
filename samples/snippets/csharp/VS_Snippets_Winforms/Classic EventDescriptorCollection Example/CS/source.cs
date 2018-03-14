using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Button button1;
// <Snippet1>
private void MyEventCollection() {
    // Creates a new collection and assigns it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Displays each event in the collection in a text box.
    foreach (EventDescriptor myEvent in events)
       textBox1.Text += myEvent.Name + '\n';
 }

// </Snippet1>
}
