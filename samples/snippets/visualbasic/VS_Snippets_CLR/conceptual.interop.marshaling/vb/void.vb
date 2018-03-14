'<snippet45>
Imports System
Imports System.Runtime.InteropServices

'<snippet46>
Public Class LibWrap
    Public Enum DataType
        DT_I2 = 1
        DT_I4
        DT_R4
        DT_R8
        DT_STR
    End Enum

    ' Uses AsAny when void* is expected.
    Declare Sub SetData Lib "..\LIB\PInvokeLib.dll" ( _
        ByVal t As DataType, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal o As Object)

    ' Uses overloading when void* is expected.
    Overloads Declare Sub SetData2 Lib "..\LIB\PInvokeLib.dll" Alias _
        "SetData" (ByVal t As DataType, ByRef d As Double)

    Overloads Declare Sub SetData2 Lib "..\LIB\PInvokeLib.dll" Alias _
        "SetData" (ByVal t As DataType, ByVal s As String)
End Class
'</snippet46>

'<snippet47>
Public Class App
   Public Shared Sub Main()
        Console.WriteLine("Calling SetData using AsAny..." + vbNewLine)
        LibWrap.SetData(LibWrap.DataType.DT_I2, CShort(12))
        LibWrap.SetData(LibWrap.DataType.DT_I4, CLng(12))
        LibWrap.SetData(LibWrap.DataType.DT_R4, CSng(12))
        LibWrap.SetData(LibWrap.DataType.DT_R8, CDbl(12))
        LibWrap.SetData(LibWrap.DataType.DT_STR, "abcd")

        Console.WriteLine(vbNewLine + "Calling SetData using overloading...")
        Console.WriteLine(vbNewLine)
        Dim d As Double = 12
        LibWrap.SetData2(LibWrap.DataType.DT_R8, d)
        LibWrap.SetData2(LibWrap.DataType.DT_STR, "abcd")
    End Sub
End Class
'</snippet47>
'</snippet45>
