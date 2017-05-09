' <Snippet1>
Imports System.Runtime.InteropServices

'Interface is exposed to COM as dual.
Interface IMyInterface1
     'Insert code here.
End Interface

'Interface is exposed to COM as IDispatch.
<InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)> _
Interface IMyInterface2
    'Insert code here.
End Interface
' </Snippet1>
