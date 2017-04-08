// <Snippet1>
using namespace System;
using namespace System::Timers;

public ref class Example
{
private:
    static System::Timers::Timer^ aTimer;

public:
    static void Demo()
    {
        // Create a timer and set a two second interval.
        aTimer = gcnew System::Timers::Timer();
        aTimer->Interval = 2000;

        // Hook up the Elapsed event for the timer. 
        aTimer->Elapsed += gcnew System::Timers::ElapsedEventHandler(Example::OnTimedEvent);

        // Have the timer fire repeated events (true is the default)
        aTimer->AutoReset = true;

        // Start the timer
        aTimer->Enabled = true;

        Console::WriteLine("Press the Enter key to exit the program at any time... ");
        Console::ReadLine();
    }

private:
    static void OnTimedEvent(Object^ source, System::Timers::ElapsedEventArgs^ e)
    {
        Console::WriteLine("The Elapsed event was raised at {0}", e->SignalTime);
    }
};

int main()
{
    Example::Demo();
}
// The example displays output like the following: 
//       Press the Enter key to exit the program at any time... 
//       The Elapsed event was raised at 5/20/2015 8:48:58 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:00 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:02 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:04 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:06 PM 

// </Snippet1>
