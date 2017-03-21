using System;
using System.Runtime.InteropServices;
// by default all classes in this assembly will use COM implementaion 
[assembly:IDispatchImpl(IDispatchImplType.CompatibleImpl)]

namespace MyNamespace
{
	// But this class will use runtime implementaion
	[IDispatchImpl(IDispatchImplType.InternalImpl)]
	class MyClass
	{
		//
	}
}
