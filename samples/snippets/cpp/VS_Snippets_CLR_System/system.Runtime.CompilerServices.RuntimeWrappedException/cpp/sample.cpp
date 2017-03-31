//<snippet1>
using namespace System;
using namespace System::Runtime::CompilerServices;

[assembly:RuntimeCompatibilityAttribute(WrapNonExceptionThrows = true)]; 

void run()
{
    try
    {
        throw gcnew String("This is a string");

    }
    catch(RuntimeWrappedException^ e)
    {
        Console::WriteLine("RuntimeWrappedException caught!");
    }
}

int main()
{
    run();

    return 0;
}
//</snippet1>