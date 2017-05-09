'<Snippet1>
' Example of the Buffer class methods.
Imports System
Imports Microsoft.VisualBasic

Module BufferClassDemo

    ' Display the array elements from right to left in hexadecimal.
    Sub DisplayArray( arr( ) As Short )

        Console.Write( "  arr:" )
        Dim loopX     As Integer
        For loopX = arr.Length - 1 To 0 Step -1
            Console.Write( " {0:X4}", arr( loopX ) )
        Next loopX
        Console.WriteLine( )
    End Sub

    Sub Main( )

        ' This array is to be modified and displayed.
        Dim arr( ) As Short = { 258, 259, 260, 261, 262, 263, 264, _
                                265, 266, 267, 268, 269, 270, 271 }
        Console.WriteLine( _
            "This example of the Buffer class methods generates " & _
            "the following output." & vbCrLf & "Note: The " & _
            "array is displayed from right to left." & vbCrLf )
        Console.WriteLine( "Initial values of array:" & vbCrLf )

        ' Display the initial array values and ByteLength.
        DisplayArray( arr )
        Console.WriteLine( vbCrLf & _
            "Buffer.ByteLength( arr ): {0}", _
            Buffer.ByteLength( arr ) )

        ' Copy a region of the array; set a byte within the array.
        Console.WriteLine( vbCrLf & _
            "Call these methods: " & vbCrLf & _
            "  Buffer.BlockCopy( arr, 5, arr, 16, 9 )," & vbCrLf & _
            "  Buffer.SetByte( arr, 7, 170 )." & vbCrLf )

        Buffer.BlockCopy( arr, 5, arr, 16, 9 )
        Buffer.SetByte( arr, 7, 170 )

        ' Display the array and a byte within the array.
        Console.WriteLine( "Final values of array:" & vbCrLf )
        DisplayArray( arr )
        Console.WriteLine( vbCrLf & _
            "Buffer.GetByte( arr, 26 ): {0}", _
            Buffer.GetByte( arr, 26 ) )
    End Sub 
End Module 

' This example of the Buffer class methods generates the following output.
' Note: The array is displayed from right to left.
' 
' Initial values of array:
' 
'   arr: 010F 010E 010D 010C 010B 010A 0109 0108 0107 0106 0105 0104 0103 0102
' 
' Buffer.ByteLength( arr ): 28
' 
' Call these methods:
'   Buffer.BlockCopy( arr, 5, arr, 16, 9 ),
'   Buffer.SetByte( arr, 7, 170 ).
' 
' Final values of array:
' 
'   arr: 010F 0101 0801 0701 0601 0501 0109 0108 0107 0106 AA05 0104 0103 0102
' 
' Buffer.GetByte( arr, 26 ): 15
'</Snippet1>