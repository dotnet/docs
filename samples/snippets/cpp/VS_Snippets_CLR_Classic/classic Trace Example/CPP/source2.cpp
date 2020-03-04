// <snippet2>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

ref class TraceIntroExample
{
public:
    static void Main()
    {
        // <snippet3>
        Trace::WriteLine("Hello World!");
        Debug::WriteLine("Hello World!");
        // </snippet3>

       // <snippet4>
       bool errorFlag = false;
       Trace::WriteLine("Error in AppendData procedure.");
       Trace::WriteLineIf(errorFlag, "Error in AppendData procedure.");
       // </snippet4>
    }
};

int main()
{
    TraceIntroExample::Main();
}
// </snippet2>
