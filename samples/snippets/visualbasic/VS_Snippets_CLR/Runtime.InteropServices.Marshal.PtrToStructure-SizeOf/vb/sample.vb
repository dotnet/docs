'<SNIPPET1>
Imports System
Imports System.Runtime.InteropServices



Public Structure Point
    Public x As Integer
    Public y As Integer
End Structure


Module Example


    Sub Main()

        ' Create a point struct.
        Dim p As Point
        p.x = 1
        p.y = 1

        Console.WriteLine("The value of first point is " + p.x.ToString + " and " + p.y.ToString + ".")

        ' Initialize unmanged memory to hold the struct.
        Dim pnt As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(p))

        Try

            ' Copy the struct to unmanaged memory.
            Marshal.StructureToPtr(p, pnt, False)

            ' Create another point.
            Dim anotherP As Point

            ' Set this Point to the value of the 
            ' Point in unmanaged memory. 
            anotherP = CType(Marshal.PtrToStructure(pnt, GetType(Point)), Point)

            Console.WriteLine("The value of new point is " + anotherP.x.ToString + " and " + anotherP.y.ToString + ".")

        Finally
            ' Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt)
        End Try

    End Sub
End Module


'</SNIPPET1>