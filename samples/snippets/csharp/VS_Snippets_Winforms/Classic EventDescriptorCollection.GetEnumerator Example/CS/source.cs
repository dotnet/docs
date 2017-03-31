using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Button button1;
// <Snippet1>
private void MyEnumerator() {
    // Creates a new collection, and assigns to it the events for button1.
    EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);
 
    // Creates an enumerator.
    IEnumerator ie = events.GetEnumerator();
 
    // Prints the name of each event in the collection.
    Object myEvent;
    while(ie.MoveNext() == true) {
       myEvent = ie.Current;
       textBox1.Text += myEvent.ToString() + '\n';
    }
 }

// </Snippet1>
}
