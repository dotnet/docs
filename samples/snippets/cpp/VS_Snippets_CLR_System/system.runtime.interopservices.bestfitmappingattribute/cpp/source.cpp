using namespace System;
using namespace System::Runtime::InteropServices;

// <Snippet1>
[BestFitMapping(false, ThrowOnUnmappableChar = true)]
interface class IMyInterface1
{
     //Insert code here.
};
// </Snippet1>

public ref class InteropBFMA : IMyInterface1
{
};


int main()
{
    InteropBFMA^ bfma = gcnew InteropBFMA();

    Console::WriteLine(bfma->GetType()->GetInterfaces()[0]->Name);
}

