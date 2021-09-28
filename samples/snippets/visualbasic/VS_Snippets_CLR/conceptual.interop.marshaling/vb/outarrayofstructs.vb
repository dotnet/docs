'<snippet19>
Imports System.Runtime.InteropServices

'<snippet20>
' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
Public Class MyStruct
    Public buffer As String
    Public someSize As Integer
End Class

Friend Class NativeMethods
    ' Declares a managed prototype for the unmanaged function.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestOutArrayOfStructs(
        ByRef arrSize As Integer, ByRef outArray As IntPtr)
    End Sub
End Class
'</snippet20>

'<snippet21>
Public Class App
    Public Shared Sub Main()
        Console.WriteLine(vbNewLine + "Using marshal class" + vbNewLine)
        UsingMarshaling()
        'Visual Basic 2005 cannot use unsafe code.
    End Sub

    Public Shared Sub UsingMarshaling()
        Dim arrSize As Integer
        Dim outArray As IntPtr

        NativeMethods.TestOutArrayOfStructs(arrSize, outArray)
        Dim manArray(arrSize - 1) As MyStruct
        Dim current As IntPtr = outArray
        Dim i As Integer

        For i = 0 To arrSize - 1
            manArray(i) = New MyStruct()
            Marshal.PtrToStructure(current, manArray(i))

            Marshal.DestroyStructure(current, GetType(MyStruct))
            current = IntPtr.op_Explicit(current.ToInt64() _
                + Marshal.SizeOf(manArray(i)))

            Console.WriteLine("Element {0}: {1} {2}", i, manArray(i).
                buffer, manArray(i).someSize)
        Next i
        Marshal.FreeCoTaskMem(outArray)
    End Sub
End Class
'</snippet21>
'</snippet19>
