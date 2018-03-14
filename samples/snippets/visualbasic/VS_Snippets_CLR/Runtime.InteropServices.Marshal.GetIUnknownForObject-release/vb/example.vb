'<snippet1>
Imports System.Runtime.InteropServices

Module Program


    Sub Run()

        ' Dim an Integer object
        Dim IntegerObject As Integer = 1

        ' Dim a pointer
        Dim pointer As IntPtr

        Console.WriteLine("Calling Marshal.GetIUnknownForObject...")

        ' Get the IUnKnown pointer for the Integer object
        pointer = Marshal.GetIUnknownForObject(IntegerObject)

        Console.WriteLine("Calling Marshal.Release...")

        ' Always call Marshal.Release to decrement the reference count.
        Marshal.Release(pointer)



    End Sub

    Sub Main(ByVal args() As String)

        Run()

    End Sub

End Module


'</snippet1>