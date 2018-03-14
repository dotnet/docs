
// <Snippet1>
using namespace System::Runtime::InteropServices;

//Interface is exposed to COM as dual.
interface class IMyInterface1{};

//Insert code here.
//Interface is exposed to COM as IDispatch.

[InterfaceTypeAttribute(ComInterfaceType::InterfaceIsIDispatch)]
interface class IMyInterface2{};
//Insert code here.
// </Snippet1>
