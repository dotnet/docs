'<Snippet2>
' Example of the BitConverter.ToInt32 method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToInt32Demo

    Const formatter As String = "{0,5}{1,17}{2,15}"
 
    ' Convert four Byte array elements to an Integer and display it.
    Sub BAToInt32( bytes( ) As Byte, index As Integer )

        Dim value As Integer = BitConverter.ToInt32( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 4 ), value )
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
             15,   0,   0,   0,   0, 128,   0,   0,  16,   0, _
              0, 240, 255,   0, 202, 154,  59,   0,  54, 101, _
            196, 241, 255, 255, 255, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToInt32( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to Integer values." & vbCrLf )

        WriteMultiLineByteArray( byteArray )

        Console.WriteLine( formatter, "index", "array elements", _
            "Integer" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "-------" )
          
        ' Convert Byte array elements to Integer values.
        BAToInt32( byteArray, 1 )
        BAToInt32( byteArray, 0 )
        BAToInt32( byteArray, 21 )
        BAToInt32( byteArray, 6 )
        BAToInt32( byteArray, 9 )
        BAToInt32( byteArray, 13 )
        BAToInt32( byteArray, 17 )
        BAToInt32( byteArray, 22 )
        BAToInt32( byteArray, 2 )
    End Sub 
End Module

' This example of the BitConverter.ToInt32( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to Integer values.
' 
' initial Byte array
' ------------------
' 0F-00-00-00-00-80-00-00-10-00-00-F0-FF-00-CA-9A-3B-00-36-65-
' C4-F1-FF-FF-FF-7F
' 
' index   array elements        Integer
' -----   --------------        -------
'     1      00-00-00-00              0
'     0      0F-00-00-00             15
'    21      F1-FF-FF-FF            -15
'     6      00-00-10-00        1048576
'     9      00-00-F0-FF       -1048576
'    13      00-CA-9A-3B     1000000000
'    17      00-36-65-C4    -1000000000
'    22      FF-FF-FF-7F     2147483647
'     2      00-00-00-80    -2147483648
'</Snippet2>