'<Snippet2>
' Example of the BitConverter.ToUInt32 method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToUInt32Demo

    Const formatter As String = "{0,5}{1,17}{2,15}"
 
    ' Convert four Byte array elements to a UInt32 and display it.
    Sub BAToUInt32( bytes( ) As Byte, index As Integer )

        Dim value As UInt32 = BitConverter.ToUInt32( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 4 ), value )
    End Sub 

    Sub Main( )
        Dim byteArray as Byte( ) = { _
             15,   0,   0,   0,   0,  16,   0, 255,   3,   0, _
              0, 202, 154,  59, 255, 255, 255, 255, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToUInt32( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to UInt32 values." & vbCrLf )
        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )
        Console.WriteLine( BitConverter.ToString( byteArray ) )
        Console.WriteLine( )
        Console.WriteLine( formatter, "index", "array elements", _
            "UInt32" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "------" )
          
        ' Convert Byte array elements to UInt32 values.
        BAToUInt32( byteArray, 1 )
        BAToUInt32( byteArray, 0 )
        BAToUInt32( byteArray, 7 )
        BAToUInt32( byteArray, 3 )
        BAToUInt32( byteArray, 10 )
        BAToUInt32( byteArray, 15 )
        BAToUInt32( byteArray, 14 )
    End Sub 
End Module

' This example of the BitConverter.ToUInt32( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to UInt32 values.
' 
' initial Byte array
' ------------------
' 0F-00-00-00-00-10-00-FF-03-00-00-CA-9A-3B-FF-FF-FF-FF-7F
' 
' index   array elements         UInt32
' -----   --------------         ------
'     1      00-00-00-00              0
'     0      0F-00-00-00             15
'     7      FF-03-00-00           1023
'     3      00-00-10-00        1048576
'    10      00-CA-9A-3B     1000000000
'    15      FF-FF-FF-7F     2147483647
'    14      FF-FF-FF-FF     4294967295
'</Snippet2>