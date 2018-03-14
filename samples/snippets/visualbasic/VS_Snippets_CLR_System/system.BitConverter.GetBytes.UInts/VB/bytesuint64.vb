'<Snippet1>
' Example of the BitConverter.GetBytes( UInt64 ) method.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module GetBytesUInt64Demo

    Const formatter As String = "{0,22}{1,30}"
 
    ' Convert a UInt64 argument to a Byte array and display it.
    Sub GetBytesUInt64( argument As UInt64 )

        Dim byteArray As Byte( ) = BitConverter.GetBytes( argument )
        Console.WriteLine( formatter, argument, _
            BitConverter.ToString( byteArray ) )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.GetBytes( UInt64 ) " & _
            vbCrLf & "method generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "UInt64", "Byte array" )
        Console.WriteLine( formatter, "------", "----------" )
          
        ' Convert UInt64 values and display the results.
        GetBytesUInt64( Convert.ToUInt64( &HFFFFFF ) )
        GetBytesUInt64( Convert.ToUInt64( 1000000000 ) )
        GetBytesUInt64( Convert.ToUInt64( &H100000000 ) )
        GetBytesUInt64( Convert.ToUInt64( &HAAAAAAAAAAAA ) )
        GetBytesUInt64( Convert.ToUInt64( 1000000000000000000 ) )
        GetBytesUInt64( UInt64.Parse( "10000000000000000000" ) )
        GetBytesUInt64( Convert.ToUInt64( 0 ) )
        GetBytesUInt64( Convert.ToUInt64( Int64.MaxValue ) )
        GetBytesUInt64( UInt64.Parse( "18446744073709551615" ) )
    End Sub 
End Module

' This example of the BitConverter.GetBytes( UInt64 )
' method generates the following output.
' 
'                 UInt64                    Byte array
'                 ------                    ----------
'               16777215       FF-FF-FF-00-00-00-00-00
'             1000000000       00-CA-9A-3B-00-00-00-00
'             4294967296       00-00-00-00-01-00-00-00
'        187649984473770       AA-AA-AA-AA-AA-AA-00-00
'    1000000000000000000       00-00-64-A7-B3-B6-E0-0D
'   10000000000000000000       00-00-E8-89-04-23-C7-8A
'                      0       00-00-00-00-00-00-00-00
'    9223372036854775807       FF-FF-FF-FF-FF-FF-FF-7F
'   18446744073709551615       FF-FF-FF-FF-FF-FF-FF-FF
'</Snippet1>