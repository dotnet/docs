// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Reflection;

// References:
// System.EnterpriseServices
// <snippet1>
[InterfaceQueuing]
interface class IInterfaceQueuingAttribute_Ctor{};
// </snippet1>

// <snippet2>
[InterfaceQueuing(true)]
interface class IInterfaceQueuingAttribute_Ctor_Bool{};
// </snippet2>
// </snippet0>
