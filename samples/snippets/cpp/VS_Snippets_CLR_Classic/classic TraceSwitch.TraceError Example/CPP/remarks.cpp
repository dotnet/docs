// <Snippet2>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

public ref class TraceErr
{
// <Snippet3>
private:
    static TraceSwitch^ appSwitch = gcnew TraceSwitch("mySwitch",
        "Switch in config file");

public:
    static void Main(array<String^>^ args)
    {
        //...
        Console::WriteLine("Trace switch {0} configured as {1}",
        appSwitch->DisplayName, appSwitch->Level.ToString());
        if (appSwitch->TraceError)
        {
            //...
        }
    }
// </Snippet3>
};

int main()
{
    array<String^>^ args = gcnew array<String^>{};
    TraceErr::Main(args);
}
//</Snippet2>