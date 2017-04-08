'<Snippet1>
' Example of the Buffer.ByteLength method.
Imports System
Imports Microsoft.VisualBasic

Module ByteLengthDemo

    Const formatter As String = "{0,10}{1,20}{2,9}{3,12}"

    Sub ArrayInfo( arr As Array, name As String )

        Dim byteLength As Integer = Buffer.ByteLength( arr )

        ' Display the array name, type, Length, and ByteLength.
        Console.WriteLine( formatter, name, arr.GetType, arr.Length, _
            byteLength )
    End Sub

    Sub Main( )
        Dim bytes( )   As Byte    = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }
        Dim bools( )   As Boolean = { True, False, True, False, True }
        Dim chars( )   As Char    = { " "c, "$"c, """"c, "A"c, "{"c }
        Dim shorts( )  As Short   = { 258, 259, 260, 261, 262, 263 }
        Dim singles( ) As Single  = { 1, 678, 2.37E33, .00415, 8.9 }
        Dim doubles( ) As Double  = { 2E-22, .003, 4.4E44, 555E55 }
        Dim longs( )   As Long    = { 1, 10, 100, 1000, 10000, 100000 }

        Console.WriteLine( _
            "This example of the Buffer.ByteLength( Array ) " & _
            vbCrLf & "method generates the following output." & vbCrLf )
        Console.WriteLine( formatter, "Array name", "Array type", _
            "Length", "ByteLength" )
        Console.WriteLine( formatter, "----------", "----------", _
            "------", "----------" )

        ' Display the Length and ByteLength for each array.
        ArrayInfo( bytes, "bytes" )
        ArrayInfo( bools, "bools" )
        ArrayInfo( chars, "chars" )
        ArrayInfo( shorts, "shorts" )
        ArrayInfo( singles, "singles" )
        ArrayInfo( doubles, "doubles" )
        ArrayInfo( longs, "longs" )
    End Sub 
End Module 

' This example of the Buffer.ByteLength( Array )
' method generates the following output.
' 
' Array name          Array type   Length  ByteLength
' ----------          ----------   ------  ----------
'      bytes       System.Byte[]       10          10
'      bools    System.Boolean[]        5           5
'      chars       System.Char[]        5          10
'     shorts      System.Int16[]        6          12
'    singles     System.Single[]        5          20
'    doubles     System.Double[]        4          32
'      longs      System.Int64[]        6          48
'</Snippet1>