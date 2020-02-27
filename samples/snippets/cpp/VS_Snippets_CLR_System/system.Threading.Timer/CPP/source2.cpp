// <snippet2>
using namespace System;
using namespace System::Threading;

ref class TimerState
{
public:
	int counter;
};

ref class Example
{
private:
	static Timer^ timer;

public:
	static void TimerTask(Object^ state)
	{
		Console::WriteLine("{0:HH:mm:ss.fff}: starting a new callback.", DateTime::Now);

		TimerState^ timerState = dynamic_cast<TimerState^>(state);
		Interlocked::Increment(timerState->counter);
	}

	static void Main()
	{
		TimerCallback^ tcb = gcnew TimerCallback(&TimerTask);
		TimerState^ state = gcnew TimerState();
		state->counter = 0;
		timer = gcnew Timer(tcb, state, 1000, 2000);

		while (state->counter <= 10)
		{
			Thread::Sleep(1000);
		}

		timer->~Timer();
		Console::WriteLine("{0:HH:mm:ss.fff}: done.", DateTime::Now);
	}
};

int main()
{
	Example::Main();
}
// </snippet2>