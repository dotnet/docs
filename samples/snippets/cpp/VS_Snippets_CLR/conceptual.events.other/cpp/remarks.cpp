using namespace System;

// Code section for remarks
namespace EventRemarks
{
    public ref class AlarmEventArgs : EventArgs
    {
    };

    // <Snippet2>
    public delegate void AlarmEventHandler(Object^ sender, AlarmEventArgs^ e);
    // </Snippet2>

    public ref class AlarmClock
    {
    public:
        event AlarmEventHandler^ Alarm;
    };

    public ref class NextClass
    {
    public:
        // <Snippet4>
        delegate void EventtHandler(Object^ sender, EventArgs^ e);
        // </Snippet4>
    };

    // <Snippet3>
    public ref class WakeMeUp
    {
    public:
        // AlarmRang has the same signature as AlarmEventHandler.
        void AlarmRang(Object^ sender, AlarmEventArgs^ e)
        {
            //...
        }
        //...
    };
    // </Snippet3>

    public ref class AlarmDriver
    {
    public:
        static void Main()
        {
            // <Snippet5>
            // Create an instance of WakeMeUp.
            WakeMeUp^ w = gcnew WakeMeUp();

            // Instantiate the event delegate.
            AlarmEventHandler^ alhandler = gcnew AlarmEventHandler(w, &WakeMeUp::AlarmRang);
            // </Snippet5>

            // <Snippet6>
            // Instantiate the event source.
            AlarmClock^ clock = gcnew AlarmClock();

            // Add the delegate instance to the event.
            clock->Alarm += alhandler;
            // </Snippet6>
        }
    };
}

int main()
{
    EventRemarks::AlarmDriver::Main();
}
