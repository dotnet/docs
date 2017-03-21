Public Interface ICustomMarshaler
     Function MarshalNativeToManaged( pNativeData As IntPtr ) As Object
     Function MarshalManagedToNative( ManagedObj As Object ) As IntPtr
     Sub CleanUpNativeData( pNativeData As IntPtr )
     Sub CleanUpManagedData( ManagedObj As Object )
     Function GetNativeDataSize() As Integer
End Interface