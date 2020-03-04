//<Snippet1>
using namespace System;
using namespace System::Threading;

public ref class Fibonacci
{
private:
	ManualResetEvent^ _doneEvent;

	int Calculate(int n)
	{
		if (n <= 1)
		{
			return n;
		}
		return Calculate(n - 1) + Calculate(n - 2);
	}

public:
	
	int ID;
	int N;
	int FibOfN;

	Fibonacci(int id, int n, ManualResetEvent^ doneEvent)
	{
		ID = id;
		N = n;
		_doneEvent = doneEvent;
	}

	void Calculate()
	{
		FibOfN = Calculate(N);
	}

	void SetDone()
	{
		_doneEvent->Set();
	}
};

public ref struct Example
{
public:

	static void ThreadProc(Object^ stateInfo)
	{
		Fibonacci^ f = dynamic_cast<Fibonacci^>(stateInfo);
		Console::WriteLine("Thread {0} started...", f->ID);
		f->Calculate();
		Console::WriteLine("Thread {0} result calculated...", f->ID);
		f->SetDone();
	}
};


void main()
{
	const int FibonacciCalculations = 5;

	array<ManualResetEvent^>^ doneEvents = gcnew array<ManualResetEvent^>(FibonacciCalculations);
	array<Fibonacci^>^ fibArray = gcnew array<Fibonacci^>(FibonacciCalculations);
	Random^ rand = gcnew Random();

	Console::WriteLine("Launching {0} tasks...", FibonacciCalculations);

	for (int i = 0; i < FibonacciCalculations; i++)
	{
		doneEvents[i] = gcnew ManualResetEvent(false);
		Fibonacci^ f = gcnew Fibonacci(i, rand->Next(20, 40), doneEvents[i]);
		fibArray[i] = f;
		ThreadPool::QueueUserWorkItem(gcnew WaitCallback(Example::ThreadProc), f);
	}

	WaitHandle::WaitAll(doneEvents);
	Console::WriteLine("All calculations are complete.");

	for (int i = 0; i < FibonacciCalculations; i++)
	{
		Fibonacci^ f = fibArray[i];
		Console::WriteLine("Fibonacci({0}) = {1}", f->N, f->FibOfN);
	}
}
// Output is similar to:
// Launching 5 tasks...
// Thread 3 started...
// Thread 2 started...
// Thread 1 started...
// Thread 0 started...
// Thread 4 started...
// Thread 4 result calculated...
// Thread 1 result calculated...
// Thread 2 result calculated...
// Thread 0 result calculated...
// Thread 3 result calculated...
// All calculations are complete.
// Fibonacci(30) = 832040
// Fibonacci(24) = 46368
// Fibonacci(26) = 121393
// Fibonacci(36) = 14930352
// Fibonacci(20) = 6765
//</Snippet1>
