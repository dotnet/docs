'<snippet1>
' Remember that the actual size of System.Char in unmanaged memory is 2.

Imports System
Imports System.Runtime.InteropServices



Module Module1

    Sub Main()
        ' Create a managed array.
        Dim managedArray As Char() = New Char(999) {}
        managedArray(0) = "a"c
        managedArray(1) = "b"c
        managedArray(2) = "c"c
        managedArray(3) = "d"c
        managedArray(999) = "Z"c

        ' Initialize unmanaged memory to hold the array.
        ' Dim size As Integer = Marshal.SizeOf(managedArray[0]) * managedArray.Length;  ' Incorrect
        Dim size As Integer = Marshal.SystemDefaultCharSize * managedArray.Length       ' Correct

        Dim pnt As IntPtr = Marshal.AllocHGlobal(size)

        Try
            ' Copy the array to unmanaged memory.
            Marshal.Copy(managedArray, 0, pnt, managedArray.Length)

            ' Copy the unmanaged array back to another managed array.

            Dim managedArray2 As Char() = New Char(managedArray.Length - 1) {}

            Marshal.Copy(pnt, managedArray2, 0, managedArray.Length)
            Console.WriteLine("Here is the roundtripped array: {0} {1} {2} {3} {4}", managedArray2(0), managedArray2(1), managedArray2(2), managedArray2(3), managedArray2(999))


            Console.WriteLine("The array was copied to unmanaged memory and back.")
        Finally
            ' Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt)

        End Try
    End Sub
End Module
'</snippet1>
