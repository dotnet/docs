//<snippet2>
using System;

class EventTester
{
    public event EventHandler TestEvent;

    public void OnTestEvent()
    {
        TestEvent(this, new EventArgs());
    }

    public void ShowEventInfo()
    {
        foreach (Delegate handler in TestEvent.GetInvocationList())
        {
            Console.WriteLine("EventHandler Method = {0}.{1}",
                handler.Method.DeclaringType, handler.Method.Name);
        }
    }

    public void ReverseInvocationList()
    {
        Delegate[] handlers = TestEvent.GetInvocationList();
        if (handlers.Length > 0)
        {
            // remove the handlers first
            foreach (EventHandler handler in handlers)
            {
                TestEvent -= handler;
            }
            // reveres the order of the handlers
            Array.Reverse(handlers);
            // now, add the handlers back
            foreach (EventHandler handler in handlers)
            {
                TestEvent += handler;
            }
        }
    }
}

class DelegateExample
{
    public static void Main()
    {
        EventTester ev = new EventTester();

        // Add two handlers to the event
        ev.TestEvent += Handler1;
        ev.TestEvent += Handler2;

        // Show what handlers are set to the event
        ev.ShowEventInfo();
        Console.WriteLine();
        // Invoke the handlers
        ev.OnTestEvent();
        Console.WriteLine();
        // Reorder the invocation list
        ev.ReverseInvocationList();
        // Invoke the handlers again
        ev.OnTestEvent();
    }

    public static void Handler1(object sender, EventArgs args)
    {
        Console.WriteLine("This is Handler1().");
    }

    public static void Handler2(object sender, EventArgs args)
    {
        Console.WriteLine("This is Handler2().");
    }
}

// This program will display the following output on the console:
//
// EventHandler Method = DelegateExample.Handler1
// EventHandler Method = DelegateExample.Handler2
//
// This is Handler1().
// This is Handler2().
//
// This is Handler2().
// This is Handler1().
//</snippet2>
