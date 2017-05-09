//<snippet1>
// Assembly building example in the .NET Framework.
using namespace System;

namespace myStringer
{
    public ref class Stringer
    {
    public:
        void StringerMethod()
        {
            System::Console::WriteLine("This is a line from StringerMethod.");
        }
    };
}
//</snippet1>

#if 0
//<snippet2>
cl /clr:pure /LN Stringer.cpp
//</snippet2>
#endif
