'<Snippet1>
' Example of the Decimal.GetHashCode method. 
Imports System
Imports Microsoft.VisualBasic

Module DecimalGetHashCodeDemo
    
    ' Display the Decimal.GetHashCode argument and the result array.
    Sub ShowDecimalGetHashCode( Argument As Decimal )

        Dim hashCode As Integer = Argument.GetHashCode( )

        Console.WriteLine( "{0,31}{1,14}  0x{1:X8}", Argument, _
            hashCode )
    End Sub

    Sub Main( )
        Console.WriteLine( "This example of the " & _
            "Decimal.GetHashCode( ) method generates " & vbCrLf & _
            "the following output. It displays the hash code of " & _
            "the " & vbCrLf & "Decimal argument in decimal and " & _
            "hexadecimal." & vbCrLf )
        Console.WriteLine( "{0,31}{1,14}", "Argument", "Hash Code" )
        Console.WriteLine( "{0,31}{1,14}", "--------", "---------" )

        ' Generate hash codes for Decimal objects.
        ShowDecimalGetHashCode( 0D )
        ShowDecimalGetHashCode( 1D )
        ShowDecimalGetHashCode( _
            Decimal.Parse( "1.0000000000000000000000000000" ) )
        ShowDecimalGetHashCode( 100000000000000D )
        ShowDecimalGetHashCode( _
            Decimal.Parse( "100000000000000.00000000000000" ) )
        ShowDecimalGetHashCode( 10000000000000000000000000000D )
        ShowDecimalGetHashCode( 10000000000000000000000009999D )
        ShowDecimalGetHashCode( 10000000000000000004294967295D )
        ShowDecimalGetHashCode( 123456789D ) 
        ShowDecimalGetHashCode( 0.123456789D ) 
        ShowDecimalGetHashCode( 0.000000000123456789D ) 
        ShowDecimalGetHashCode( 0.000000000000000000123456789D ) 
        ShowDecimalGetHashCode( 4294967295D ) 
        ShowDecimalGetHashCode( 18446744073709551615D ) 
        ShowDecimalGetHashCode( Decimal.MaxValue ) 
        ShowDecimalGetHashCode( Decimal.MinValue ) 
        ShowDecimalGetHashCode( -7.9228162514264337593543950335D ) 
    End Sub
End Module 

' This example of the Decimal.GetHashCode( ) method generates
' the following output. It displays the hash code of the
' Decimal argument in decimal and hexadecimal.
' 
'                        Argument     Hash Code
'                        --------     ---------
'                               0             0  0x00000000
'                               1    1072693248  0x3FF00000
'  1.0000000000000000000000000000    1072693248  0x3FF00000
'                 100000000000000    1548139716  0x5C46BCC4
'  100000000000000.00000000000000    1548139716  0x5C46BCC4
'   10000000000000000000000000000    1793013094  0x6ADF3566
'   10000000000000000000000009999    1793013094  0x6ADF3566
'   10000000000000000004294967295    1793013094  0x6ADF3566
'                       123456789     362639156  0x159D6F34
'                     0.123456789     143063426  0x0886F982
'            0.000000000123456789    -667156908  0xD83BFE54
'   0.000000000000000000123456789    -261016360  0xF07134D8
'                      4294967295   -1106247681  0xBE0FFFFF
'            18446744073709551615    1139802112  0x43F00000
'   79228162514264337593543950335    1173356544  0x45F00000
'  -79228162514264337593543950335    -974127104  0xC5F00000
' -7.9228162514264337593543950335    2119160044  0x7E4FD0EC
'</Snippet1>