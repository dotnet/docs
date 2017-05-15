
// <Snippet1>
using namespace System;
using namespace System::Threading;

ref class StatusChecker
{
private:
    int invokeCount, maxCount;

public:
    StatusChecker(int count)
    {
        invokeCount  = 0;
        maxCount = count;
    }

    // This method is called by the timer delegate.
    void CheckStatus(Object^ stateInfo)
    {
        AutoResetEvent^ autoEvent = dynamic_cast<AutoResetEvent^>(stateInfo);
        Console::WriteLine("{0:h:mm:ss.fff} Checking status {1,2}.",
                           DateTime::Now, ++invokeCount);

        if (invokeCount == maxCount) {
            // Reset the counter and signal the waiting thread.
            invokeCount  = 0;
            autoEvent->Set();
        }
    }
};

ref class TimerExample
{
public:
    static void Main()
    {
        // Create an AutoResetEvent to signal the timeout threshold in the
        // timer callback has been reached.
        AutoResetEvent^ autoEvent = gcnew AutoResetEvent(false);

        StatusChecker^ statusChecker = gcnew StatusChecker(10);

        // Create a delegate that invokes methods for the timer.
        TimerCallback^ tcb =
           gcnew TimerCallback(statusChecker, &StatusChecker::CheckStatus);

        // Create a timer that invokes CheckStatus after one second, 
        // and every 1/4 second thereafter.
        Console::WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
                           DateTime::Now);
        Timer^ stateTimer = gcnew Timer(tcb, autoEvent, 1000, 250);

        // When autoEvent signals, change the period to every half second.
        autoEvent->WaitOne(5000, false);
        stateTimer->Change(0, 500);
        Console::WriteLine("\nChanging period to .5 seconds.\n");

        // When autoEvent signals the second time, dispose of the timer.
        autoEvent->WaitOne(5000, false);
        stateTimer->~Timer();
        Console::WriteLine("\nDestroying timer.");
    }
};

int main()
{
    TimerExample::Main();
}
// The example displays output like the following:
//       11:59:54.202 Creating timer.
//       
//       11:59:55.217 Checking status  1.
//       11:59:55.466 Checking status  2.
//       11:59:55.716 Checking status  3.
//       11:59:55.968 Checking status  4.
//       11:59:56.218 Checking status  5.
//       11:59:56.470 Checking status  6.
//       11:59:56.722 Checking status  7.
//       11:59:56.972 Checking status  8.
//       11:59:57.223 Checking status  9.
//       11:59:57.473 Checking status 10.
//       
//       Changing period to .5 seconds.
//       
//       11:59:57.474 Checking status  1.
//       11:59:57.976 Checking status  2.
//       11:59:58.476 Checking status  3.
//       11:59:58.977 Checking status  4.
//       11:59:59.477 Checking status  5.
//       11:59:59.977 Checking status  6.
//       12:00:00.478 Checking status  7.
//       12:00:00.980 Checking status  8.
//       12:00:01.481 Checking status  9.
//       12:00:01.981 Checking status 10.
//       
//       Destroying timer.
// </Snippet1>
