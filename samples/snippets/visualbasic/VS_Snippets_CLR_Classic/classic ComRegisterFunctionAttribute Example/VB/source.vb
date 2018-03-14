' <Snippet1>
Imports System
Imports System.Runtime.InteropServices

Public Class MyClassThatNeedsToRegister
    
    <ComRegisterFunctionAttribute()> Public Shared Sub _
      RegisterFunction(t As Type)
        'Insert code here.
    End Sub
    
    <ComUnregisterFunctionAttribute()> Public Shared Sub _
      UnregisterFunction(t As Type)
        'Insert code here.
    End Sub
End Class
' </Snippet1>
