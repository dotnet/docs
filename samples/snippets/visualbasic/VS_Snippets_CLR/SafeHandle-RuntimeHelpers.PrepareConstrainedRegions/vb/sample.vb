
Imports System
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports System.Runtime.ConstrainedExecution


' <snippet1>
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


    ' </snippet1>
    ' If & only if you need to support user-supplied handles
    Friend Sub New(ByVal preexistingHandle As IntPtr, ByVal ownsHandle As Boolean)
        MyBase.New(IntPtr.Zero, ownsHandle)
        SetHandle(preexistingHandle)

    End Sub 'New

    ' Do not provide a finalizer - SafeHandle's critical finalizer will
    ' call ReleaseHandle for you.

    Public Overrides ReadOnly Property IsInvalid() As Boolean

        Get
            Return IsClosed OrElse handle = IntPtr.Zero
        End Get
    End Property

    <DllImport("kernel32"), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean

    End Function


    Protected Overrides Function ReleaseHandle() As Boolean
        Return CloseHandle(handle)

    End Function 'ReleaseHandle


    <DllImport("kernel32")> _
    Public Shared Function CreateHandle(ByVal someState As Integer) As MySafeHandle

    End Function


    <DllImport("kernel32")> _
    Public Shared Function NativeAllocateHandle(ByRef someState As MyStruct) As MySafeHandle

    End Function
End Class 'MySafeHandle



Public Class Example

    Shared Sub Main()

    End Sub 'Main
End Class 'Example


