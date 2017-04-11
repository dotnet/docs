'<snippet13>
Imports System
Imports System.Text
Imports System.Runtime.InteropServices

'<snippet14>
' Declares a managed structure for each unmanaged structure.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
Public Structure MyStrStruct
    Public buffer As String
    Public size As Integer
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure MyStrStruct2
    Public buffer As String
    Public size As Integer
End Structure

Public Class LibWrap
    ' Declares managed prototypes for unmanaged functions.
    Declare Function TestStringAsResult Lib "..\LIB\PinvokeLib.dll" () _
        As String
    Declare Sub TestStringInStruct Lib "..\LIB\PinvokeLib.dll" _
        (ByRef mss As MyStrStruct)
    Declare Sub TestStringInStructAnsi Lib "..\LIB\PinvokeLib.dll" _
        (ByRef mss As MyStrStruct2)
End Class
'</snippet14>

'<snippet15>
Public Class App
    Public Shared Sub Main()
        ' String as result.
        Dim str As String = LibWrap.TestStringAsResult()
        Console.WriteLine(vbNewLine + "String returned: {0}", str)

        ' Initializes buffer and appends something to the end so the whole
        ' buffer is passed to the unmanaged side.
        Dim buffer As New StringBuilder("content", 100)
        buffer.Append(ChrW(0))
        buffer.Append("*", buffer.Capacity - 8)

        Dim mss As MyStrStruct
        mss.buffer = buffer.ToString()
        mss.size = mss.buffer.Length

        LibWrap.TestStringInStruct(mss)
        Console.WriteLine(vbNewLine + "Buffer after Unicode function call: {0}", _
            mss.buffer )

        Dim buffer2 As New StringBuilder("content", 100)
        buffer2.Append(ChrW(0))
        buffer2.Append("*", buffer2.Capacity - 8)

        Dim mss2 As MyStrStruct2
        mss2.buffer = buffer2.ToString()
        mss2.size = mss2.buffer.Length

        LibWrap.TestStringInStructAnsi(mss2)
        Console.WriteLine(vbNewLine + "Buffer after Ansi function call: {0}", mss2.buffer)
    End Sub
End Class
'</snippet15>
'</snippet13>
