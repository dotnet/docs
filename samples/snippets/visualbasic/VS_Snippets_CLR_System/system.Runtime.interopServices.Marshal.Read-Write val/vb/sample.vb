'<Snippet1>
Imports System.Runtime.InteropServices

Module MainModule

    Sub Main(ByVal args() As String)
        ReadWriteIntPtr()
        ReadWriteByte()
        ReadWriteInt16()
        ReadWriteInt32()
        ReadWriteInt64()
    End Sub 

    '<Snippet2>
    Sub ReadWriteIntPtr()
        ' Allocate unmanaged memory.
        Dim elementSize As Integer = Marshal.SizeOf(GetType(IntPtr))
        Dim unmanagedArray As IntPtr = Marshal.AllocHGlobal(10 * elementSize)

        ' Set the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Marshal.WriteIntPtr(unmanagedArray, i * elementSize, CType(i + 1, IntPtr))
        Next i
        Console.WriteLine("Unmanaged memory written.")

        Console.WriteLine("Reading unmanaged memory:")
        ' Print the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Console.WriteLine(Marshal.ReadIntPtr(unmanagedArray, i * elementSize))
        Next i

        Marshal.FreeHGlobal(unmanagedArray)

        Console.WriteLine("Done. Press Enter to continue.")
        Console.ReadLine()
    End Sub
    '</Snippet2>

    '<Snippet3>
    Sub ReadWriteByte()
        ' Allocate unmanaged memory. 
        Dim elementSize As Integer = 1
        Dim unmanagedArray As IntPtr = Marshal.AllocHGlobal(10 * elementSize)

        ' Set the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Marshal.WriteByte(unmanagedArray, i * elementSize, CType(i + 1, Byte))
        Next i
        Console.WriteLine("Unmanaged memory written.")

        Console.WriteLine("Reading unmanaged memory:")
        ' Print the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Console.WriteLine(Marshal.ReadByte(unmanagedArray, i * elementSize))
        Next i

        Marshal.FreeHGlobal(unmanagedArray)

        Console.WriteLine("Done. Press Enter to continue.")
        Console.ReadLine()
    End Sub
    '</Snippet3>

    '<Snippet4>
    Sub ReadWriteInt16()
        ' Allocate unmanaged memory. 
        Dim elementSize As Integer = 2
        Dim unmanagedArray As IntPtr = Marshal.AllocHGlobal(10 * elementSize)

        ' Set the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Marshal.WriteInt16(unmanagedArray, i * elementSize, CType(i + 1, Int16))
        Next i
        Console.WriteLine("Unmanaged memory written.")

        Console.WriteLine("Reading unmanaged memory:")
        ' Print the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Console.WriteLine(Marshal.ReadInt16(unmanagedArray, i * elementSize))
        Next i

        Marshal.FreeHGlobal(unmanagedArray)

        Console.WriteLine("Done. Press Enter to continue.")
        Console.ReadLine()
    End Sub
    '</Snippet4>

    '<Snippet5>
    Sub ReadWriteInt32()
        ' Allocate unmanaged memory. 
        Dim elementSize As Integer = 4
        Dim unmanagedArray As IntPtr = Marshal.AllocHGlobal(10 * elementSize)

        ' Set the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Marshal.WriteInt32(unmanagedArray, i * elementSize, CType(i + 1, Int32))
        Next i
        Console.WriteLine("Unmanaged memory written.")

        Console.WriteLine("Reading unmanaged memory:")
        ' Print the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Console.WriteLine(Marshal.ReadInt32(unmanagedArray, i * elementSize))
        Next i

        Marshal.FreeHGlobal(unmanagedArray)

        Console.WriteLine("Done. Press Enter to continue.")
        Console.ReadLine()
    End Sub
    '</Snippet5>

    '<Snippet6>
    Sub ReadWriteInt64()
        ' Allocate unmanaged memory. 
        Dim elementSize As Integer = 8
        Dim unmanagedArray As IntPtr = Marshal.AllocHGlobal(10 * elementSize)

        ' Set the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Marshal.WriteInt64(unmanagedArray, i * elementSize, CType(i + 1, Int64))
        Next i
        Console.WriteLine("Unmanaged memory written.")

        Console.WriteLine("Reading unmanaged memory:")
        ' Print the 10 elements of the C-style unmanagedArray
        For i As Integer = 0 To 9
            Console.WriteLine(Marshal.ReadInt64(unmanagedArray, i * elementSize))
        Next i

        Marshal.FreeHGlobal(unmanagedArray)

        Console.WriteLine("Done. Press Enter to continue.")
        Console.ReadLine()
    End Sub
    '</Snippet6>
End Module
'</Snippet1>