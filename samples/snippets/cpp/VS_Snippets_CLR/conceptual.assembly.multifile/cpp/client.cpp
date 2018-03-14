//<snippet3>
#using "Stringer.netmodule"

using namespace System;
using namespace myStringer; //The namespace created in Stringer.netmodule.

ref class MainClientApp
{
    // Static method Main is the entry point method.
public:
    static void Main()
    {
        Stringer^ myStringInstance = gcnew Stringer();
        Console::WriteLine("Client code executes");
        myStringInstance->StringerMethod();
    }
};

int main()
{
    MainClientApp::Main();
}
//</snippet3>

#if 0
//<snippet4>
cl /clr:pure /FUStringer.netmodule /LN Client.cpp
//</snippet4>

//<snippet5>
cl /clr:pure /LN Stringer.cpp
cl /clr:pure Client.cpp /link /ASSEMBLYMODULE:Stringer.netmodule
//</snippet5>

//<snippet6>
cl /clr:pure /LN Stringer.cpp
cl /clr:pure Client.cpp /link /ASSEMBLYMODULE:Stringer.netmodule
//</snippet6>
#endif
