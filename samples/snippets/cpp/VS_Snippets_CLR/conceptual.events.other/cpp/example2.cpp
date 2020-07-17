//<snippet20>
using namespace System;

public ref class MouseEventArgs : EventArgs
{
};

public ref class EventNameEventArgs : EventArgs
{
};

//<snippet22>
delegate void EventNameEventHandler(Object^ sender, EventNameEventArgs^ e);
//</snippet22>

ref class EventingSnippets
{
    //<snippet21>
public:
    event EventNameEventHandler^ EventName;
    //</snippet21>


    //<snippet23>
    void EventHandler(Object^ sender, EventNameEventArgs^ e) {}
    //</snippet23>

    //<snippet24>
    void Mouse_Moved(Object^ sender, MouseEventArgs^ e){}
    //</snippet24>

    void OnSomeSignal(EventNameEventArgs^ e)
    {
        // Invokes the delegates.
        EventName(this, e);
    }

    static void Main()
    {
        Console::WriteLine("EventingSnippets Main()");
    }
};

int main()
{
    EventingSnippets::Main();
}
//</snippet20>
