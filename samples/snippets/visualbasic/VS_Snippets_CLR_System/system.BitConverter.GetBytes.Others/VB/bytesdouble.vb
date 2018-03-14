'<Snippet4>
' Example of the BitConverter.GetBytes( Double ) method.
Imports System
Imports Microsoft.VisualBasic

Module GetBytesDoubleDemo

    Const formatter As String = "{0,25:E16}{1,30}"
 
    ' Convert a Double argument to a Byte array and display it.
    Sub GetBytesDouble( argument As Double )

        Dim byteArray As Byte( ) = BitConverter.GetBytes( argument )
        Console.WriteLine( formatter, argument, _
            BitConverter.ToString( byteArray ) )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.GetBytes( Double ) " & _
            vbCrLf & "method generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "Double", "Byte array" )
        Console.WriteLine( formatter, "------", "----------" )
          
        ' Convert Double values and display the results.
        GetBytesDouble( 0.0 )
        GetBytesDouble( 1.0 )
        GetBytesDouble( 255.0 )
        GetBytesDouble( 4294967295.0 )
        GetBytesDouble( 0.00390625 )
        GetBytesDouble( 0.00000000023283064365386962890625 )
        GetBytesDouble( 1.23456789012345E-300 )
        GetBytesDouble( 1.2345678901234565 )
        GetBytesDouble( 1.2345678901234567 )
        GetBytesDouble( 1.2345678901234569 )
        GetBytesDouble( 1.23456789012345678E+300 )
        GetBytesDouble( Double.MinValue )
        GetBytesDouble( Double.MaxValue )
        GetBytesDouble( Double.Epsilon )
        GetBytesDouble( Double.NaN )
        GetBytesDouble( Double.NegativeInfinity )
        GetBytesDouble( Double.PositiveInfinity )
    End Sub 
End Module

' This example of the BitConverter.GetBytes( Double )
' method generates the following output.
' 
'                    Double                    Byte array
'                    ------                    ----------
'   0.0000000000000000E+000       00-00-00-00-00-00-00-00
'   1.0000000000000000E+000       00-00-00-00-00-00-F0-3F
'   2.5500000000000000E+002       00-00-00-00-00-E0-6F-40
'   4.2949672950000000E+009       00-00-E0-FF-FF-FF-EF-41
'   3.9062500000000000E-003       00-00-00-00-00-00-70-3F
'   2.3283064365386963E-010       00-00-00-00-00-00-F0-3D
'   1.2345678901234500E-300       DF-88-1E-1C-FE-74-AA-01
'   1.2345678901234565E+000       FA-59-8C-42-CA-C0-F3-3F
'   1.2345678901234567E+000       FB-59-8C-42-CA-C0-F3-3F
'   1.2345678901234569E+000       FC-59-8C-42-CA-C0-F3-3F
'   1.2345678901234569E+300       52-D3-BB-BC-E8-7E-3D-7E
'  -1.7976931348623157E+308       FF-FF-FF-FF-FF-FF-EF-FF
'   1.7976931348623157E+308       FF-FF-FF-FF-FF-FF-EF-7F
'   4.9406564584124654E-324       01-00-00-00-00-00-00-00
'                       NaN       00-00-00-00-00-00-F8-FF
'                 -Infinity       00-00-00-00-00-00-F0-FF
'                  Infinity       00-00-00-00-00-00-F0-7F
'</Snippet4>