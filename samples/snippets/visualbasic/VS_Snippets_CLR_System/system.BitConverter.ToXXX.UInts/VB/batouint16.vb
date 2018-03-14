'<Snippet1>
' Example of the BitConverter.ToUInt16 method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToUInt16Demo

    Const formatter As String = "{0,5}{1,17}{2,10}"
 
    ' Convert two Byte array elements to a UInt16 and display it.
    Sub BAToUInt16( bytes( ) As Byte, index As Integer )

        Dim value As UInt16 = BitConverter.ToUInt16( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 2 ), value )
    End Sub 
       
    Sub Main( )

        Dim byteArray as Byte( ) = { _
             15, 0, 0, 255, 3, 16, 39, 255, 255, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToUInt16( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to UInt16 values." & vbCrLf )
        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )
        Console.WriteLine( BitConverter.ToString( byteArray ) )
        Console.WriteLine( )
        Console.WriteLine( formatter, "index", "array elements", _
            "UInt16" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "------" )
          
        ' Convert Byte array elements to UInt16 values.
        BAToUInt16( byteArray, 1 )
        BAToUInt16( byteArray, 0 )
        BAToUInt16( byteArray, 3 )
        BAToUInt16( byteArray, 5 )
        BAToUInt16( byteArray, 8 )
        BAToUInt16( byteArray, 7 )
    End Sub 
End Module

' This example of the BitConverter.ToUInt16( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to UInt16 values.
' 
' initial Byte array
' ------------------
' 0F-00-00-FF-03-10-27-FF-FF-7F
' 
' index   array elements    UInt16
' -----   --------------    ------
'     1            00-00         0
'     0            0F-00        15
'     3            FF-03      1023
'     5            10-27     10000
'     8            FF-7F     32767
'     7            FF-FF     65535
'</Snippet1>