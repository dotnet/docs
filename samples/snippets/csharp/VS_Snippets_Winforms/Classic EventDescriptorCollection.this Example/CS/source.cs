using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Button button1;
// <Snippet1>
private void PrintIndexItem() {
    // Creates a new collection and assigns it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Prints the second event's name.
    textBox1.Text = events[1].ToString();
 }

// </Snippet1>
}
