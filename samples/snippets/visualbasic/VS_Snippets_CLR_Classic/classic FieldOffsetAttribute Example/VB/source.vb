Imports System
Imports System.Runtime.InteropServices

' <Snippet1>
<StructLayout(LayoutKind.Explicit)> _
Public Class SYSTEM_INFO
    <FieldOffset(0)> Private OemId As System.UInt64
    <FieldOffset(8)> Private PageSize As System.UInt64
    <FieldOffset(16)> Private ActiveProcessorMask As System.UInt64
    <FieldOffset(24)> Private NumberOfProcessors As System.UInt64
    <FieldOffset(32)> Private ProcessorType As System.UInt64
End Class
' </Snippet1>
