'<snippet19>
Imports System
Imports System.Runtime.InteropServices

'<snippet20>
' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Class MyStruct
    Public buffer As String
    Public someSize As Integer
End Class 'MyStruct

Public Class LibWrap
    ' Declares a managed prototype for the unmanaged function.
    Declare Sub TestOutArrayOfStructs Lib "..\\LIB\\PinvokeLib.dll" ( _
        ByRef arrSize As Integer, ByRef outArray As IntPtr )
End Class 'LibWrap
'</snippet20>

'<snippet21>
Public Class App
    Public Shared Sub Main()
        Console.WriteLine( vbNewLine + "Using marshal class" + vbNewLine)
        UsingMarshaling()
        'Visual Basic 2005 cannot use unsafe code.
    End Sub 'Main

    Public Shared Sub UsingMarshaling()
        Dim arrSize As Integer
        Dim outArray As IntPtr

        LibWrap.TestOutArrayOfStructs(arrSize, outArray)
        Dim manArray(arrSize - 1) As MyStruct
        Dim current As IntPtr = outArray
        Dim i As Integer

        For i = 0 To arrSize - 1
            manArray(i) = New MyStruct()
            Marshal.PtrToStructure(current, manArray(i))

            Marshal.DestroyStructure(current, GetType(MyStruct))
            current = IntPtr.op_explicit(current.ToInt64() _
                + Marshal.SizeOf(manArray(i)))

            Console.WriteLine( "Element {0}: {1} {2}", i, manArray(i). _
            buffer, manArray(i).someSize)
        Next i
        Marshal.FreeCoTaskMem(outArray)
    End Sub 'UsingMarshal
End Class 'App
'</snippet21>
'</snippet19>
