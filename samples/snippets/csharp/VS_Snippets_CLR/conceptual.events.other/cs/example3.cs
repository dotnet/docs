//<snippet30>
using System;
using System.ComponentModel;
using System.Windows.Forms;

//<snippet31>
// The class SampleControl defines two event properties, MouseUp and MouseDown.
class SampleControl : Component
{
    // :
    // Define other control methods and properties.
    // :

    // Define the delegate collection.
    protected EventHandlerList listEventDelegates = new EventHandlerList();

    // Define a unique key for each event.
    static readonly object mouseDownEventKey = new object();
    static readonly object mouseUpEventKey = new object();

    // Define the MouseDown event property.
    public event MouseEventHandler MouseDown
    {
        // Add the input delegate to the collection.
        add
        {
            listEventDelegates.AddHandler(mouseDownEventKey, value);
        }
        // Remove the input delegate from the collection.
        remove
        {
            listEventDelegates.RemoveHandler(mouseDownEventKey, value);
        }
    }

    // Raise the event with the delegate specified by mouseDownEventKey
    private void OnMouseDown(MouseEventArgs e)
    {
        MouseEventHandler mouseEventDelegate =
            (MouseEventHandler)listEventDelegates[mouseDownEventKey];
        mouseEventDelegate(this, e);
    }

    // Define the MouseUp event property.
    public event MouseEventHandler MouseUp
    {
        // Add the input delegate to the collection.
        add
        {
            listEventDelegates.AddHandler(mouseUpEventKey, value);
        }
        // Remove the input delegate from the collection.
        remove
        {
            listEventDelegates.RemoveHandler(mouseUpEventKey, value);
        }
    }

    // Raise the event with the delegate specified by mouseUpEventKey
    private void OnMouseUp(MouseEventArgs e)
    {
        MouseEventHandler mouseEventDelegate =
            (MouseEventHandler)listEventDelegates[mouseUpEventKey];
        mouseEventDelegate(this, e);
    }
}
//</snippet31>

class Dummy
{
    public static void Main()
    {
        Console.WriteLine("Dummy.Main()");
    }
}
//</snippet30>
