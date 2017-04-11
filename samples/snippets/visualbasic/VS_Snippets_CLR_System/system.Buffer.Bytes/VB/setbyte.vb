'<Snippet2>
' Example of the Buffer.SetByte method.
Imports System
Imports Microsoft.VisualBasic

Module SetByteDemo

    ' Display the array contents in hexadecimal.
    Sub DisplayArray( arr As Array, name As String )

        ' Get the array element width; format the formatting string.
        Dim loopX     As Integer
        Dim elemWidth As Integer = _
            Buffer.ByteLength( arr ) / arr.Length
        Dim format    As String = _
            String.Format( " {{0:X{0}}}", 2 * elemWidth )

        ' Display the array elements from right to left.
        Console.Write( "{0,7}:", name )
        For loopX = arr.Length - 1 to 0 Step -1
            Console.Write( format, arr( loopX ) )
        Next loopX
        Console.WriteLine( )
    End Sub

    Sub Main( )

        ' These are the arrays to be modified with SetByte.
        ' This allocates 10 elements for shorts and 3 elements
        ' for longs in Visual Basic.
        Dim shorts( 9 ) As Short
        Dim longs( 2 )  As Long  

        Console.WriteLine( "This example of the " & _
            "Buffer.SetByte( Array, Integer, Byte ) " & vbCrLf & _
            "method generates the following output." & vbCrLf & _
            "Note: The arrays are displayed from right to left." & _
            vbCrLf )
        Console.WriteLine( "  Initial values of arrays:" & vbCrLf )

        ' Display the initial values of the arrays.
        DisplayArray( shorts, "shorts" )
        DisplayArray( longs, "longs" )

        ' Copy two regions of source array to destination array,
        ' and two overlapped copies from source to source.
        Console.WriteLine( vbCrLf & _
            "  Array values after setting byte 3 = 25, " & vbCrLf & _
            "  byte 6 = 64, byte 12 = 121, and byte 17 = 196:" & vbCrLf )

        Buffer.SetByte( shorts, 3, 25 )
        Buffer.SetByte( shorts, 6, 64 )
        Buffer.SetByte( shorts, 12, 121 )
        Buffer.SetByte( shorts, 17, 196 )
        Buffer.SetByte( longs, 3, 25 )
        Buffer.SetByte( longs, 6, 64 )
        Buffer.SetByte( longs, 12, 121 )
        Buffer.SetByte( longs, 17, 196 )

        ' Display the arrays again.
        DisplayArray( shorts, "shorts" )
        DisplayArray( longs, "longs" )
    End Sub 
End Module 

' This example of the Buffer.SetByte( Array, Integer, Byte )
' method generates the following output.
' Note: The arrays are displayed from right to left.
' 
'   Initial values of arrays:
' 
'  shorts: 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000
'   longs: 0000000000000000 0000000000000000 0000000000000000
' 
'   Array values after setting byte 3 = 25,
'   byte 6 = 64, byte 12 = 121, and byte 17 = 196:
' 
'  shorts: 0000 C400 0000 0079 0000 0000 0040 0000 1900 0000
'   longs: 000000000000C400 0000007900000000 0040000019000000
'</Snippet2>