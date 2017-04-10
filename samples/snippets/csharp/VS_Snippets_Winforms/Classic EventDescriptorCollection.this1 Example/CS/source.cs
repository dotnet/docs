using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Button button1;
// <Snippet1>
private void PrintIndexItem2() {
    // Creates a new collection and assigns it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Sets an EventDescriptor to the specific event.
    EventDescriptor myEvent = events["KeyDown"];
 
    // Prints the name of the event.
    textBox1.Text = myEvent.Name;
 }

// </Snippet1>
}
