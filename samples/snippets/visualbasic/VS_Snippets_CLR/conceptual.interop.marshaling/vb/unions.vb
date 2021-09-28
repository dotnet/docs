'<snippet26>
Imports System.Runtime.InteropServices

'<snippet28>
' Declares managed structures instead of unions.
<StructLayout(LayoutKind.Explicit)>
Public Structure MyUnion
    <FieldOffset(0)> Public i As Integer
    <FieldOffset(0)> Public d As Double
End Structure

<StructLayout(LayoutKind.Explicit, Size:=128)>
Public Structure MyUnion2_1
    <FieldOffset(0)> Public i As Integer
End Structure

<StructLayout(LayoutKind.Sequential)>
Public Structure MyUnion2_2
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
    Public str As String
End Structure

Friend Class NativeMethods
    ' Declares managed prototypes for unmanaged function.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestUnion(
        ByVal u As MyUnion, ByVal type As Integer)
    End Sub

    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Overloads Shared Sub TestUnion2(
        ByVal u As MyUnion2_1, ByVal type As Integer)
    End Sub

    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Overloads Shared Sub TestUnion2(
        ByVal u As MyUnion2_2, ByVal type As Integer)
    End Sub
End Class
'</snippet28>

'<snippet29>
Public Class App
    Public Shared Sub Main()
        Dim mu As New MyUnion()
        mu.i = 99
        NativeMethods.TestUnion(mu, 1)

        mu.d = 99.99
        NativeMethods.TestUnion(mu, 2)

        Dim mu2_1 As New MyUnion2_1()
        mu2_1.i = 99
        NativeMethods.TestUnion2(mu2_1, 1)

        Dim mu2_2 As New MyUnion2_2()
        mu2_2.str = "*** string ***"
        NativeMethods.TestUnion2(mu2_2, 2)
    End Sub
End Class
'</snippet29>
'</snippet26>
