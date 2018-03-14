'<Snippet3>
' Example of the Buffer.GetByte method.
Imports System
Imports Microsoft.VisualBasic

Module GetByteDemo

    Const formatter As String = "{0,10}{1,10}{2,9} {3}"

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

    Sub ArrayInfo( arr As Array, name As String, index As Integer )
        
        Dim value As Byte = Buffer.GetByte( arr, index )

        ' Display the array name, index, and byte to be viewed.
        Console.WriteLine( formatter, name, index, value, _
            String.Format( "&H{0:X2}", value ) )
    End Sub

    Sub Main( )

        ' These are the arrays to be viewed with GetByte.
        Dim longs( ) As Long  = _
            { 333333333333333333, 666666666666666666, 999999999999999999 }
        Dim ints( )  As Integer = _
            { 111111111, 222222222, 333333333, 444444444, 555555555 }

        Console.WriteLine( "This example of the " & _
            "Buffer.GetByte( Array, Integer ) " & vbCrLf & _
            "method generates the following output." & vbCrLf & _
            "Note: The arrays are displayed from right to left." )
        Console.WriteLine( vbCrLf & "  Values of arrays:" & vbCrLf )

        ' Display the values of the arrays.
        DisplayArray( longs, "longs" )
        DisplayArray( ints, "ints" )
        Console.WriteLine( )

        Console.WriteLine( formatter, "Array", "index", _
            "value", "" )
        Console.WriteLine( formatter, "-----", "-----", _
            "-----", "----" )

        ' Display the Length and ByteLength for each array.
        ArrayInfo( ints, "ints", 0 )
        ArrayInfo( ints, "ints", 7 )
        ArrayInfo( ints, "ints", 10 )
        ArrayInfo( ints, "ints", 17 )
        ArrayInfo( longs, "longs", 0 )
        ArrayInfo( longs, "longs", 6 )
        ArrayInfo( longs, "longs", 10 )
        ArrayInfo( longs, "longs", 17 )
        ArrayInfo( longs, "longs", 21 )
    End Sub 
End Module 

' This example of the Buffer.GetByte( Array, Integer )
' method generates the following output.
' Note: The arrays are displayed from right to left.
' 
'   Values of arrays:
' 
'   longs: 0DE0B6B3A763FFFF 094079CD1A42AAAA 04A03CE68D215555
'    ints: 211D1AE3 1A7DAF1C 13DE4355 0D3ED78E 069F6BC7
' 
'      Array     index    value
'      -----     -----    ----- ----
'       ints         0      199 &HC7
'       ints         7       13 &H0D
'       ints        10      222 &HDE
'       ints        17       26 &H1A
'      longs         0       85 &H55
'      longs         6      160 &HA0
'      longs        10       66 &H42
'      longs        17      255 &HFF
'      longs        21      182 &HB6
'</Snippet3>