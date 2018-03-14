'<Snippet2>
' Example of the BitConverter.GetBytes( UInt32 ) method.
Imports System
Imports Microsoft.VisualBasic

Module GetBytesUInt32Demo

    Const formatter As String = "{0,16}{1,20}"
 
    ' Convert a UInt32 argument to a Byte array and display it.
    Sub GetBytesUInt32( argument As UInt32 )

        Dim byteArray As Byte( ) = BitConverter.GetBytes( argument )
        Console.WriteLine( formatter, argument, _
            BitConverter.ToString( byteArray ) )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.GetBytes( UInt32 ) " & _
            vbCrLf & "method generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "UInt32", "Byte array" )
        Console.WriteLine( formatter, "------", "----------" )
          
        ' Convert UInt32 values and display the results.
        GetBytesUInt32( Convert.ToUInt32( 15 ) )
        GetBytesUInt32( Convert.ToUInt32( 1023 ) )
        GetBytesUInt32( Convert.ToUInt32( &H100000 ) )
        GetBytesUInt32( Convert.ToUInt32( 1000000000 ) )
        GetBytesUInt32( Convert.ToUInt32( 0 ) )
        GetBytesUInt32( Convert.ToUInt32( Int32.MaxValue ) )
        GetBytesUInt32( Convert.ToUInt32( 4294967295 ) )
    End Sub 
End Module

' This example of the BitConverter.GetBytes( UInt32 )
' method generates the following output.
' 
'           UInt32          Byte array
'           ------          ----------
'               15         0F-00-00-00
'             1023         FF-03-00-00
'          1048576         00-00-10-00
'       1000000000         00-CA-9A-3B
'                0         00-00-00-00
'       2147483647         FF-FF-FF-7F
'       4294967295         FF-FF-FF-FF
'</Snippet2>