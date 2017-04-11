'<Snippet3>
' Example of the Convert.ToString( numeric types ) and 
' Convert.ToString( numeric types, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ConvertNumericProviderDemo

    Sub Main( )

        ' Create a NumberFormatInfo object and set several of its
        ' properties that apply to numbers.
        Dim provider    As NumberFormatInfo = new NumberFormatInfo( )
        Dim formatter   As String           = "{0,22}   {1}"

        ' These properties will affect the conversion.
        provider.NegativeSign = "minus "
        provider.NumberDecimalSeparator = " point "

        ' These properties will not be applied.
        provider.NumberDecimalDigits = 2
        provider.NumberGroupSeparator = "."
        provider.NumberGroupSizes = New Integer( ) { 3 }

        ' Convert these values using default values and the
        ' format provider created above.
        Dim ByteA       As Byte     = 140
        Dim SByteA      As SByte    = Convert.ToSByte( -60 )
        Dim UInt16A     As UInt16   = Convert.ToUInt16( 61680 )
        Dim Int16A      As Short    = -3855

        Dim UInt32A     As UInt32   = Convert.ToUInt32( 4042322160 )
        Dim Int32A      As Integer  = -252645135   
        Dim UInt64A     As UInt64   = _
                            Convert.ToUInt64( 8138269444283625712 )
        Dim Int64A      As Long     = -1085102592571150095

        Dim SingleA     As Single   = -32.375F
        Dim DoubleA     As Double   = 61680.3855
        Dim DecimA      As Decimal  = 4042322160.252645135D
        Dim ObjDouble   As Object   = CType( -98765.4321, Object )

        Console.WriteLine( "This example of " & _
            "Convert.ToString( numeric types ) and " & vbCrLf & _
            "Convert.ToString( numeric types, IFormatProvider ) " & _
            vbCrLf & "converts values of each of the CLR base " & _
            "numeric types to strings, " & vbCrLf & "using " & _
            "default formatting and a NumberFormatInfo object." )
        Console.WriteLine( vbCrLf & _
            "Note: Of the several NumberFormatInfo properties " & _
            "that are changed, " & vbCrLf & "only the negative " & _
            "sign and decimal separator affect the conversions." )
        Console.WriteLine( vbCrLf & formatter, _
            "Default", "Format Provider" )
        Console.WriteLine( formatter, _
            "-------", "---------------" )

        ' Convert the values with and without a format provider.
        Console.WriteLine( formatter, Convert.ToString( ByteA ), _
            Convert.ToString( ByteA, provider ) )
        Console.WriteLine( formatter, Convert.ToString( SByteA ), _
            Convert.ToString( SByteA, provider ) )
        Console.WriteLine( formatter, Convert.ToString( UInt16A ), _
            Convert.ToString( UInt16A, provider ) )
        Console.WriteLine( formatter, Convert.ToString( Int16A ), _
            Convert.ToString( Int16A, provider ) )

        Console.WriteLine( formatter, Convert.ToString( UInt32A ), _
            Convert.ToString( UInt32A, provider ) )
        Console.WriteLine( formatter, Convert.ToString( Int32A ), _
            Convert.ToString( Int32A, provider ) )
        Console.WriteLine( formatter, Convert.ToString( UInt64A ), _
            Convert.ToString( UInt64A, provider ) )
        Console.WriteLine( formatter, Convert.ToString( Int64A ), _
            Convert.ToString( Int64A, provider ) )

        Console.WriteLine( formatter, Convert.ToString( SingleA ), _
            Convert.ToString( SingleA, provider ) )
        Console.WriteLine( formatter, Convert.ToString( DoubleA ), _
            Convert.ToString( DoubleA, provider ) )
        Console.WriteLine( formatter, Convert.ToString( DecimA ), _
            Convert.ToString( DecimA, provider ) )
        Console.WriteLine( formatter, Convert.ToString( ObjDouble ), _
            Convert.ToString( ObjDouble, provider ) )
    End Sub
End Module

' This example of Convert.ToString( numeric types ) and
' Convert.ToString( numeric types, IFormatProvider )
' converts values of each of the CLR base numeric types to strings,
' using default formatting and a NumberFormatInfo object.
' 
' Note: Of the several NumberFormatInfo properties that are changed,
' only the negative sign and decimal separator affect the conversions.
' 
'                Default   Format Provider
'                -------   ---------------
'                    140   140
'                    -60   minus 60
'                  61680   61680
'                  -3855   minus 3855
'             4042322160   4042322160
'             -252645135   minus 252645135
'    8138269444283625712   8138269444283625712
'   -1085102592571150095   minus 1085102592571150095
'                -32.375   minus 32 point 375
'             61680.3855   61680 point 3855
'   4042322160.252645135   4042322160 point 252645135
'            -98765.4321   minus 98765 point 4321
'</Snippet3>