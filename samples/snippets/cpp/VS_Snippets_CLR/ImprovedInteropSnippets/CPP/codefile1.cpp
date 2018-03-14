
//System::Runtime::InteropServices::IDispatchImplAttribute*
//System::Runtime::InteropServices::IDispatchImplType*
// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

// by default all classes in this assembly will use COM implementaion
//   // But this class will use runtime implementaion

[assembly:IDispatchImpl(IDispatchImplType::CompatibleImpl)];
[IDispatchImpl(IDispatchImplType::InternalImpl)]
ref class MyClass{};
// </Snippet1>
