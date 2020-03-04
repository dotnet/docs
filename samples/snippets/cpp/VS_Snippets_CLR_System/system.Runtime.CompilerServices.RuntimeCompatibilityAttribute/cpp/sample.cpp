//<snippet1>
using namespace System;
using namespace System::Runtime::CompilerServices;

[assembly:RuntimeCompatibilityAttribute(WrapNonExceptionThrows = false)];

void run()
{
     Console::WriteLine("The RuntimeCompatibilityAttribute was applied to disable exception wrapping.");
}

int main()
{
    run();

    return 0;
}
//</snippet1>