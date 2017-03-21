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