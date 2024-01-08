' <Snippet4>
Imports System.Runtime.InteropServices

' </Snippet4>

' <Snippet1>
Public Interface INew
    Sub NewMethod()
End Interface
' </Snippet1>


' <Snippet2>
Public Interface ICustomMarshaler
     Function MarshalNativeToManaged( pNativeData As IntPtr ) As Object
     Function MarshalManagedToNative( ManagedObj As Object ) As IntPtr
     Sub CleanUpNativeData( pNativeData As IntPtr )
     Sub CleanUpManagedData( ManagedObj As Object )
     Function GetNativeDataSize() As Integer
End Interface
' </Snippet2>

Namespace scope1

' <Snippet3>
Public Interface IUserData
    Sub DoSomeStuff(pINew As INew)
End Interface
' </Snippet3>

End Namespace

Namespace scope2

' <Snippet5>
Public Interface IUserData
    Sub DoSomeStuff( _
        <MarshalAs(UnmanagedType.CustomMarshaler, _
        MarshalType := "MyCompany.NewOldMarshaler")> pINew As INew)
End Interface
' </Snippet5>
End Namespace

Class StubClass
    Public Shared Sub Main
    End Sub
End Class