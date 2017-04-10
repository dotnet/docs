'<Snippet1>
Imports System

NameSpace MSInternalLibrary

' Violates rule: MovePInvokesToNativeMethodsClass.
Friend Class UnmanagedApi
    Friend Declare Function RemoveDirectory Lib "kernel32" ( _
       ByVal Name As String) As Boolean
End Class

End NameSpace 
'</Snippet1>
