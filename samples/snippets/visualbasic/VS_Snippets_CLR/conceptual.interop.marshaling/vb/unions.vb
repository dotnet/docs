'<snippet26>
Imports System
Imports System.Runtime.InteropServices

'<snippet28>
' Declares managed structures instead of unions.
<StructLayout(LayoutKind.Explicit)> _
Public Structure MyUnion
    <FieldOffset(0)> Public i As Integer
    <FieldOffset(0)> Public d As Double
End Structure 'MyUnion

<StructLayout(LayoutKind.Explicit, Size := 128)> _
Public Structure MyUnion2_1
    <FieldOffset(0)> Public i As Integer
End Structure 'MyUnion2_1

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyUnion2_2
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst := 128)> _
    Public str As String
End Structure 'MyUnion2_2

Public Class LibWrap
    ' Declares managed prototypes for unmanaged function.
    Declare Sub TestUnion Lib "..\LIB\PinvokeLib.dll" ( _
        ByVal u As MyUnion, ByVal type As Integer)

    Overloads Declare Sub TestUnion2 Lib "..\LIB\PinvokeLib.dll" ( _
        ByVal u As MyUnion2_1, ByVal type As Integer)

    Overloads Declare Sub TestUnion2 Lib "..\LIB\PinvokeLib.dll" ( _
        ByVal u As MyUnion2_2, ByVal type As Integer)
End Class 'LibWrap
'</snippet28>

'<snippet29>
Public Class App
    Public Shared Sub Main()
        Dim mu As New MyUnion()
        mu.i = 99
        LibWrap.TestUnion(mu, 1)

        mu.d = 99.99
        LibWrap.TestUnion(mu, 2)

        Dim mu2_1 As New MyUnion2_1()
        mu2_1.i = 99
        LibWrap.TestUnion2(mu2_1, 1)

        Dim mu2_2 As New MyUnion2_2()
        mu2_2.str = "*** string ***"
        LibWrap.TestUnion2(mu2_2, 2)
    End Sub 'Main
End Class 'App
'</snippet29>
'</snippet26>
