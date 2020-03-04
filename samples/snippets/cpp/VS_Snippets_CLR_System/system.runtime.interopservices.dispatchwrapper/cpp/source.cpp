using namespace System;
using namespace System::Runtime::InteropServices;

//
// Some interface
//
[Guid("1F948D8D-D9ED-4CCC-BB61-5C1730E39EE9"),
InterfaceType(ComInterfaceType::InterfaceIsDual)]
public interface class ISomeIFace
{
};

public ref class MyObject : public ISomeIFace
{
};

class DispatchWrapperTest
{
public:
    // <Snippet1>
    void MyMethod(Object^ o);

    void DoWrap()
    {
        Object^ o = gcnew MyObject();
        MyMethod(o);                        // passes o as VT_UNKNOWN
        MyMethod(gcnew DispatchWrapper(o)); // passes o as VT_DISPATCH

        //...
    }
    // </Snippet1>
};

int main() {}