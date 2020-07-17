//<snippet20>
using System;

public class MouseEventArgs : EventArgs
{
}

public class EventNameEventArgs : EventArgs
{
}

class EventingSnippets
{
    //<snippet21>
    public event EventNameEventHandler EventName;
    //</snippet21>

    //<snippet22>
    public delegate void EventNameEventHandler(object sender, EventNameEventArgs e);
    //</snippet22>

    //<snippet23>
    void EventHandler(object sender, EventNameEventArgs e) {}
    //</snippet23>

    //<snippet24>
    void Mouse_Moved(object sender, MouseEventArgs e){}
    //</snippet24>

    void OnSomeSignal(EventNameEventArgs e)
    {
        EventNameEventHandler handler = EventName;
        if (handler != null)
        {
            // Invokes the delegates.
            handler(this, e);
        }
    }

    public static void Main()
    {

        Console.WriteLine("EventingSnippets Main()");
    }
}
//</snippet20>
