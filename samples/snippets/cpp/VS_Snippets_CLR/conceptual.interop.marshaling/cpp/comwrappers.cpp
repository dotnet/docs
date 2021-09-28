//<snippet48>
using namespace System;
using namespace System::Runtime::InteropServices;

public ref class Snippets
{
public:
    static void Main()
    {
    }

    //<snippet49>
    void M1([MarshalAs(UnmanagedType::LPWStr)] String^ msg)
    {
        // ...
    }
    //</snippet49>

    //<snippet51>
    [returnvalue: MarshalAs(UnmanagedType::LPWStr)]
    String^ GetMessage()
    {
        String^ msg = gcnew String(gcnew array<Char>(128));
        // Load message here ...
        return msg;
    }
    //</snippet51>
};

//<snippet50>
ref class MsgText
{
public:
    [MarshalAs(UnmanagedType::LPWStr)]
    String^ msg;

    MsgText()
    {
        msg = "";
    }
};
//</snippet50>
int main()
{
    Snippets::Main();
}
//</snippet48>
