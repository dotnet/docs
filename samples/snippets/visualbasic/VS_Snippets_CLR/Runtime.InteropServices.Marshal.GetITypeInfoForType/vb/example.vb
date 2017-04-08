'<snippet1>
Imports System.Runtime.InteropServices

Module Program


    Sub Run()

        ' Dim a pointer
        Dim pointer As IntPtr

        Console.WriteLine("Calling Marshal.GetIUnknownForObjectInContext...")

        ' Get the ITypeInfo pointer for an Object type
        pointer = Marshal.GetITypeInfoForType(Type.GetType("System.Object"))

        Console.WriteLine("Calling Marshal.Release...")

        ' Always call Marshal.Release to decrement the reference count.
        Marshal.Release(pointer)



    End Sub

    Sub Main(ByVal args() As String)

        Run()

    End Sub

End Module


'</snippet1>