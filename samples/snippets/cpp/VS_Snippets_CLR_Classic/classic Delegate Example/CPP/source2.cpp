//<snippet2>
using namespace System;

ref class EventTester
{
private:
    EventHandler^ baseEvent;

public:
    event EventHandler^ TestEvent
    {
        void add(EventHandler^ handler )
        {
            baseEvent += handler;
        }

        void remove(EventHandler^ handler )
        {
            baseEvent -= handler;
        }

        void raise(Object^ sender, EventArgs^ args)
        {
            baseEvent(sender, args);
        }
    }

    void OnTestEvent()
    {
        TestEvent(this, gcnew EventArgs());
    }

    void ShowEventInfo()
    {
        for each (Delegate^ handler in baseEvent->GetInvocationList())
        {
            Console::WriteLine("EventHandler Method = {0}::{1}",
                handler->Method->DeclaringType, handler->Method->Name);
        }
    }

    void ReverseInvocationList()
    {
        array<Delegate^>^ handlers = baseEvent->GetInvocationList();
        if (handlers->Length > 0)
        {
            // remove the handlers first
            for each (EventHandler^ handler in handlers)
            {
                TestEvent -= handler;
            }
            // reveres the order of the handlers
            Array::Reverse(handlers);
            // now, add the handlers back
            for each (EventHandler^ handler in handlers)
            {
                TestEvent += handler;
            }
        }
    }
};

ref class DelegateExample
{
public:
    static void Main()
    {
        EventTester^ ev = gcnew EventTester();

        // Add two handlers to the event
        ev->TestEvent += gcnew EventHandler(&Handler1);
        ev->TestEvent += gcnew EventHandler(&Handler2);

        // Show what handlers are set to the event
        ev->ShowEventInfo();
        Console::WriteLine();
        // Invoke the handlers
        ev->OnTestEvent();
        Console::WriteLine();
        // Reorder the invocation list
        ev->ReverseInvocationList();
        // Invoke the handlers again
        ev->OnTestEvent();
    }

    static void Handler1(Object^ sender, EventArgs^ args)
    {
        Console::WriteLine("This is Handler1().");
    }

    static void Handler2(Object^ sender, EventArgs^ args)
    {
        Console::WriteLine("This is Handler2().");
    }
};

int main()
{
    DelegateExample::Main();
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
