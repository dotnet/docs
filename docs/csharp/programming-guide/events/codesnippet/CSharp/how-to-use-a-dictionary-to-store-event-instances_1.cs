using System;
using System.Collections.Generic;

public delegate void EventHandler1(int i);
public delegate void EventHandler2(string s);

public class PropertyEventsSample
{
    private readonly object handlerStorageLock = new object();

    private readonly Dictionary<string, Delegate> handlers;
    private readonly List<EventHandler1> event1Handlers = new List<EventHandler1>();
    private readonly List<EventHandler2> event2Handlers = new List<EventHandler2>();

    public PropertyEventsSample()
    {
        handlers = new Dictionary<string, Delegate>
        {
            ["Event1"] = null,
            ["Event2"] = null
        };
    }

    public event EventHandler1 Event1
    {
        add
        {
            lock (handlerStorageLock)
            {
                event1Handlers.Add(value);
                handlers["Event1"] = (EventHandler1)handlers["Event1"] + value;
            }
        }
        remove
        {
            lock (handlerStorageLock)
            {
                if (!event1Handlers.Contains(value)) return;

                event1Handlers.Remove(value);
                handlers["Event1"] = null;
                foreach (var handler in event1Handlers)
                {
                    handlers["Event1"] = (EventHandler1)handlers["Event1"] + handler;
                }
            }
        }
    }

    public event EventHandler2 Event2
    {
        add
        {
            lock (handlerStorageLock)
            {
                event2Handlers.Add(value);
                handlers["Event2"] = (EventHandler2)handlers["Event2"] + value;
            }
        }
        remove
        {
            lock (handlerStorageLock)
            {
                if (!event2Handlers.Contains(value)) return;

                event2Handlers.Remove(value);
                handlers["Event2"] = null;
                foreach (var handler in event2Handlers)
                {
                    handlers["Event2"] = (EventHandler2)handlers["Event2"] + handler;
                }
            }
        }
    }

    internal void RaiseEvent1(int i)
    {
        EventHandler1 handler1;
        lock (handlerStorageLock)
        {
            handler1 = (EventHandler1)handlers["Event1"];
        }
        handler1?.Invoke(i);
    }

    internal void RaiseEvent2(string s)
    {
        EventHandler2 handler2;
        lock (handlerStorageLock)
        {
            handler2 = (EventHandler2)handlers["Event2"];
        }
        handler2?.Invoke(s);
    }
}

public static class TestClass
{
    private static void Delegate1Method(int i) => Console.WriteLine(i);

    private static void Delegate2Method(string s) => Console.WriteLine(s);

    private static void Main()
    {
        var p = new PropertyEventsSample();

        p.Event1 += Delegate1Method;
        p.Event1 += Delegate1Method;
        p.Event1 -= Delegate1Method;
        p.RaiseEvent1(2);

        p.Event2 += Delegate2Method;
        p.Event2 += Delegate2Method;
        p.Event2 -= Delegate2Method;
        p.RaiseEvent2("TestString");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
// Output:
//   2
//   TestString
