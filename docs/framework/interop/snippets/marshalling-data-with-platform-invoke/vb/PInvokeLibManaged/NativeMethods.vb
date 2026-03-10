Imports System.Runtime.InteropServices

' <ManagedTypes>
' Managed type declarations that correspond to the unmanaged types in PinvokeLib.dll.

<StructLayout(LayoutKind.Sequential)>
Friend Structure MyPoint
    Public x As Integer
    Public y As Integer
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
Friend Structure MyPerson
    Public first As String
    Public last As String
End Structure

<StructLayout(LayoutKind.Sequential)>
Friend Structure MyPerson2
    Public person As IntPtr ' Pointer to a MyPerson structure
    Public age As Integer
End Structure

<StructLayout(LayoutKind.Sequential)>
Friend Structure MyPerson3
    Public person As MyPerson ' Embedded MyPerson structure
    Public age As Integer
End Structure

<StructLayout(LayoutKind.Explicit)>
Friend Structure MyUnion
    <FieldOffset(0)> Public i As Integer
    <FieldOffset(0)> Public d As Double
End Structure

<StructLayout(LayoutKind.Sequential)>
Friend Structure MyArrayStruct
    Public flag As Boolean

    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)>
    Public vals As Integer()
End Structure
' </ManagedTypes>

' <NativeMethods>
Friend Class NativeMethods
    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfInts(
        <[In], Out> ByVal array() As Integer, ByVal size As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestRefArrayOfInts(
        ByRef array As IntPtr, ByRef size As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestMatrixOfInts(
        <[In], Out> ByVal matrix(,) As Integer, ByVal row As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStrings(
        <[In], Out> ByVal array() As String, ByVal size As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStructs(
        <[In], Out> ByVal pointArray() As MyPoint, ByVal size As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStructs2(
        <[In], Out> ByVal personArray() As MyPerson, ByVal size As Integer) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestStructInStruct(
        ByRef person2 As MyPerson2) As Integer
    End Function

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestStructInStruct3(ByVal person3 As MyPerson3)
    End Sub

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestUnion(ByVal u As MyUnion, ByVal type As Integer)
    End Sub

    <DllImport("PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestArrayInStruct(ByRef myStruct As MyArrayStruct)
    End Sub
End Class
' </NativeMethods>
