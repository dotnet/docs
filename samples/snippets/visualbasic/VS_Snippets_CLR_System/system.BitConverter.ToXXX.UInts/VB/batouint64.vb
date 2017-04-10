'<Snippet3>
' Example of the BitConverter.ToUInt64 method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToUInt64Demo

    Const formatter As String = "{0,5}{1,27}{2,24}"
 
    ' Convert eight Byte array elements to a UInt64 and display it.
    Sub BAToUInt64( bytes( ) As Byte, index As Integer )

        Dim value As UInt64 = BitConverter.ToUInt64( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 8 ), value )
    End Sub 

    ' Display a Byte array, using multiple lines if necessary.
    Sub WriteMultiLineByteArray( bytes( ) As Byte )
       
        Const rowSize As Integer = 20 
        Dim iter As Integer

        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )

        For iter = 0 To bytes.Length - rowSize - 1 Step rowSize
            Console.Write( _
                BitConverter.ToString( bytes, iter, rowSize ) )
            Console.WriteLine( "-" )
        Next iter

        Console.WriteLine( BitConverter.ToString( bytes, iter ) )
        Console.WriteLine( )
    End Sub

    Sub Main( )
        Dim byteArray as Byte( ) = { _
            255, 255, 255,   0,   0,   0,   0,   0,   0,   0, _
              0,   1,   0,   0,   0, 100, 167, 179, 182, 224, _
             13,   0, 202, 154,  59,   0,   0,   0,   0, 170, _
            170, 170, 170, 170, 170,   0,   0, 232, 137,   4, _
             35, 199, 138, 255, 255, 255, 255, 255, 255, 255, _
            255, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToUInt64( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to UInt64 values." & vbCrLf )

        WriteMultiLineByteArray( byteArray )

        Console.WriteLine( formatter, "index", "array elements", _
            "UInt64" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "------" )
          
        ' Convert Byte array elements to UInt64 values.
        BAToUInt64( byteArray, 3 )
        BAToUInt64( byteArray, 0 )
        BAToUInt64( byteArray, 21 )
        BAToUInt64( byteArray, 7 )
        BAToUInt64( byteArray, 29 )
        BAToUInt64( byteArray, 13 )
        BAToUInt64( byteArray, 35 )
        BAToUInt64( byteArray, 44 )
        BAToUInt64( byteArray, 43 )
    End Sub 
End Module

' This example of the BitConverter.ToUInt64( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to UInt64 values.
' 
' initial Byte array
' ------------------
' FF-FF-FF-00-00-00-00-00-00-00-00-01-00-00-00-64-A7-B3-B6-E0-
' 0D-00-CA-9A-3B-00-00-00-00-AA-AA-AA-AA-AA-AA-00-00-E8-89-04-
' 23-C7-8A-FF-FF-FF-FF-FF-FF-FF-FF-7F
' 
' index             array elements                  UInt64
' -----             --------------                  ------
'     3    00-00-00-00-00-00-00-00                       0
'     0    FF-FF-FF-00-00-00-00-00                16777215
'    21    00-CA-9A-3B-00-00-00-00              1000000000
'     7    00-00-00-00-01-00-00-00              4294967296
'    29    AA-AA-AA-AA-AA-AA-00-00         187649984473770
'    13    00-00-64-A7-B3-B6-E0-0D     1000000000000000000
'    35    00-00-E8-89-04-23-C7-8A    10000000000000000000
'    44    FF-FF-FF-FF-FF-FF-FF-7F     9223372036854775807
'    43    FF-FF-FF-FF-FF-FF-FF-FF    18446744073709551615
'</Snippet3>