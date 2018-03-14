'<snippet1>
Option Strict Off

Imports System.Runtime.InteropServices
Imports SomeNamespace

Namespace SomeNamespace
    ' Force the layout of your fields to the C style struct layout.
    ' Without this, the .NET Framework will reorder your fields.
    
    <StructLayout(LayoutKind.Sequential)> _
    Structure Vertex
        Dim x As Decimal
        Dim y As Decimal
        Dim z As Decimal
    End Structure

    Class SomeClass
        ' Add [In] or [In, Out] attributes as approppriate.
        ' Marshal as a C style array of Vertex, where the second (SizeParamIndex is zero-based)
        '  parameter (size) contains the count of array elements.

        Declare Auto Sub SomeUnsafeMethod Lib "somelib.dll" ( _
                                      <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> data() As Vertex, _
                                      size As Long ) 

        Public Sub SomeMethod()
            Dim verts(3) As Vertex
            SomeUnsafeMethod( verts, verts.Length )
        End Sub

    End Class

End Namespace

Module Test
	Sub Main
        Dim AClass As New SomeClass

        AClass.SomeMethod
    	End Sub
End Module
'</snippet1>
