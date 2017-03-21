<StructLayout(LayoutKind.Sequential)> _
Structure MyStruct
    Public m_outputHandle As IntPtr
End Structure 'MyStruct


NotInheritable Class MySafeHandle
    Inherits SafeHandle

    ' Called by P/Invoke when returning SafeHandles
    Public Sub New()
        MyBase.New(IntPtr.Zero, True)

    End Sub


    Public Function AllocateHandle() As MySafeHandle
        ' Allocate SafeHandle first to avoid failure later.
        Dim sh As New MySafeHandle()

        RuntimeHelpers.PrepareConstrainedRegions()
        Try
        Finally
            Dim myStruct As New MyStruct()
            NativeAllocateHandle(myStruct)
            sh.SetHandle(myStruct.m_outputHandle)
        End Try

        Return sh

    End Function

