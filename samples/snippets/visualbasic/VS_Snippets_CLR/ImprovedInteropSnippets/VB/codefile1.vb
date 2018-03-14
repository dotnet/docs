'System.Runtime.InteropServices.IDispatchImplAttribute
'System.Runtime.InteropServices.IDispatchImplType
' <Snippet1>
Imports System
Imports System.Runtime.InteropServices
' by default all classes in this assembly will use COM implementaion 
<Assembly: IDispatchImpl(IDispatchImplType.CompatibleImpl)> 

Module MyNamespace
	' But this class will use runtime implementaion
	<IDispatchImpl(IDispatchImplType.InternalImpl)> _
	Public Class c
		'
	End Class

End Module
' </Snippet1>

