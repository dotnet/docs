'<SNIPPET1>
Imports System
Imports System.Runtime.InteropServices



Module Example


    Sub Main()
        ' Create a managed array.
        Dim managedArray As Int64() = {1, 2, 3, 4}

        ' Initialize unmanaged memory to hold the array.
        Dim size As Integer = Marshal.SizeOf(managedArray(0)) * managedArray.Length

        Dim pnt As IntPtr = Marshal.AllocHGlobal(size)

        Try
            ' Copy the array to unmanaged memory.
            Marshal.Copy(managedArray, 0, pnt, managedArray.Length)

            ' Copy the unmanaged array back to another managed array.
            Dim managedArray2(managedArray.Length) As Int64

            Marshal.Copy(pnt, managedArray2, 0, managedArray.Length)

            Console.WriteLine("The array was copied to unmanaged memory and back.")

        Finally
            ' Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt)
        End Try

    End Sub
End Module


'</SNIPPET1>