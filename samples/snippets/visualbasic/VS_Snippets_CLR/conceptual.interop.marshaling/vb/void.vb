'<snippet45>
Imports System.Runtime.InteropServices

'<snippet46>
Friend Class NativeMethods
    Friend Enum DataType
        DT_I2 = 1
        DT_I4
        DT_R4
        DT_R8
        DT_STR
    End Enum

    ' Uses AsAny when void* is expected.
    Friend Declare Sub SetData Lib "..\LIB\PInvokeLib.dll" (
        ByVal t As DataType,
        <MarshalAs(UnmanagedType.AsAny)> ByVal o As Object)

    ' Uses overloading when void* is expected.
    Friend Overloads Declare Sub SetData2 Lib "..\LIB\PInvokeLib.dll" Alias _
        "SetData" (ByVal t As DataType, ByRef d As Double)

    Friend Overloads Declare Sub SetData2 Lib "..\LIB\PInvokeLib.dll" Alias _
        "SetData" (ByVal t As DataType, ByVal s As String)
End Class
'</snippet46>

'<snippet47>
Public Class App
    Public Shared Sub Main()
        Console.WriteLine("Calling SetData using AsAny..." + vbNewLine)
        NativeMethods.SetData(NativeMethods.DataType.DT_I2, CShort(12))
        NativeMethods.SetData(NativeMethods.DataType.DT_I4, CLng(12))
        NativeMethods.SetData(NativeMethods.DataType.DT_R4, CSng(12))
        NativeMethods.SetData(NativeMethods.DataType.DT_R8, CDbl(12))
        NativeMethods.SetData(NativeMethods.DataType.DT_STR, "abcd")

        Console.WriteLine(vbNewLine + "Calling SetData using overloading...")
        Console.WriteLine(vbNewLine)
        Dim d As Double = 12
        NativeMethods.SetData2(NativeMethods.DataType.DT_R8, d)
        NativeMethods.SetData2(NativeMethods.DataType.DT_STR, "abcd")
    End Sub
End Class
'</snippet47>
'</snippet45>
