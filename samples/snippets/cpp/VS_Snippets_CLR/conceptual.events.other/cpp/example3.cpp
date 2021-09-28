//<snippet30>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

//<snippet31>
// The class SampleControl defines two event properties, MouseUp and MouseDown.
ref class SampleControl : Component
{
    // :
    // Define other control methods and properties.
    // :

    // Define the delegate collection.
protected:
    EventHandlerList^ listEventDelegates;

private:
    // Define a unique key for each event.
    static Object^ mouseDownEventKey = gcnew Object();
    static Object^ mouseUpEventKey = gcnew Object();

    // Define the MouseDown event property.
public:
    SampleControl()
    {
        listEventDelegates = gcnew EventHandlerList();
    }

    event MouseEventHandler^ MouseDown
    {
        // Add the input delegate to the collection.
        void add(MouseEventHandler^ value)
        {
            listEventDelegates->AddHandler(mouseDownEventKey, value);
        }
        // Remove the input delegate from the collection.
        void remove(MouseEventHandler^ value)
        {
            listEventDelegates->RemoveHandler(mouseDownEventKey, value);
        }
        // Raise the event with the delegate specified by mouseDownEventKey
        void raise(Object^ sender, MouseEventArgs^ e)
        {
            MouseEventHandler^ mouseEventDelegate =
                (MouseEventHandler^)listEventDelegates[mouseDownEventKey];
            mouseEventDelegate(sender, e);
        }
    }

    // Define the MouseUp event property.
    event MouseEventHandler^ MouseUp
    {
        // Add the input delegate to the collection.
        void add(MouseEventHandler^ value)
        {
            listEventDelegates->AddHandler(mouseUpEventKey, value);
        }
        // Remove the input delegate from the collection.
        void remove(MouseEventHandler^ value)
        {
            listEventDelegates->RemoveHandler(mouseUpEventKey, value);
        }
        // Raise the event with the delegate specified by mouseUpEventKey
        void raise(Object^ sender, MouseEventArgs^ e)
        {
            MouseEventHandler^ mouseEventDelegate =
                (MouseEventHandler^)listEventDelegates[mouseUpEventKey];
            mouseEventDelegate(sender, e);
        }
    }
};
//</snippet31>

int main()
{
    return 0;
}
//</snippet30>
