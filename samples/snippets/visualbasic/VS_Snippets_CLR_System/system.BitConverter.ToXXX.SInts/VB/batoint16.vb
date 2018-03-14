'<Snippet1>
' Example of the BitConverter.ToInt16 method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToInt16Demo

    Const formatter As String = "{0,5}{1,17}{2,10}"
 
    ' Convert two Byte array elements to a Short and display it.
    Sub BAToInt16( bytes( ) As Byte, index As Integer )

        Dim value As Short = BitConverter.ToInt16( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 2 ), value )
    End Sub 
       
    Sub Main( )

        Dim byteArray as Byte( ) = { _
             15, 0, 0, 128, 16, 39, 240, 216, 241, 255, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToInt16( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to Short values." & vbCrLf )
        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )
        Console.WriteLine( BitConverter.ToString( byteArray ) )
        Console.WriteLine( )
        Console.WriteLine( formatter, "index", "array elements", "Short" )
        Console.WriteLine( formatter, "-----", "--------------", "-----" )
          
        ' Convert Byte array elements to Short values.
        BAToInt16( byteArray, 1 )
        BAToInt16( byteArray, 0 )
        BAToInt16( byteArray, 8 )
        BAToInt16( byteArray, 4 )
        BAToInt16( byteArray, 6 )
        BAToInt16( byteArray, 9 )
        BAToInt16( byteArray, 2 )
    End Sub 
End Module

' This example of the BitConverter.ToInt16( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to Short values.
' 
' initial Byte array
' ------------------
' 0F-00-00-80-10-27-F0-D8-F1-FF-7F
' 
' index   array elements     Short
' -----   --------------     -----
'     1            00-00         0
'     0            0F-00        15
'     8            F1-FF       -15
'     4            10-27     10000
'     6            F0-D8    -10000
'     9            FF-7F     32767
'     2            00-80    -32768
'</Snippet1>