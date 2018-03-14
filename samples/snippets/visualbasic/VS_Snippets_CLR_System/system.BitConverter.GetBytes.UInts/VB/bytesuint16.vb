'<Snippet3>
' Example of the BitConverter.GetBytes( UInt16 ) method.
Imports System
Imports Microsoft.VisualBasic

Module GetBytesUInt16Demo

    Const formatter As String = "{0,10}{1,13}"
 
    ' Convert a UInt16 argument to a Byte array and display it.
    Sub GetBytesUInt16( argument As UInt16 )

        Dim byteArray As Byte( ) = BitConverter.GetBytes( argument )
        Console.WriteLine( formatter, argument, _
            BitConverter.ToString( byteArray ) )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.GetBytes( UInt16 ) " & _
            vbCrLf & "method generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "UInt16", "Byte array" )
        Console.WriteLine( formatter, "------", "----------" )
          
        ' Convert UInt16 values and display the results.
        GetBytesUInt16( Convert.ToUInt16( 15 ) )
        GetBytesUInt16( Convert.ToUInt16( 1023 ) )
        GetBytesUInt16( Convert.ToUInt16( 10000 ) )
        GetBytesUInt16( Convert.ToUInt16( 0 ) )
        GetBytesUInt16( Convert.ToUInt16( Int16.MaxValue ) )
        GetBytesUInt16( Convert.ToUInt16( 65535 ) )
    End Sub 
End Module

' This example of the BitConverter.GetBytes( UInt16 )
' method generates the following output.
' 
'     UInt16   Byte array
'     ------   ----------
'         15        0F-00
'       1023        FF-03
'      10000        10-27
'          0        00-00
'      32767        FF-7F
'      65535        FF-FF
'</Snippet3>