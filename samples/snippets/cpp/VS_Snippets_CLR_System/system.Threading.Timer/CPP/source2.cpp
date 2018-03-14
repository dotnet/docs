// <snippet2>
using namespace System;
using namespace System::Threading;

public ref class Example
{
private:
    static Timer^ ticker;

public:
    static void TimerMethod(Object^ state)
    {
        Console::Write(".");
    }

    static void Main()
    {
        TimerCallback^ tcb =
           gcnew TimerCallback(&TimerMethod);

        ticker = gcnew Timer(tcb, nullptr, 1000, 1000);

        Console::WriteLine("Press the Enter key to end the program.");
        Console::ReadLine();
    }
};

int main()
{
    Example::Main();
}

// </snippet2>