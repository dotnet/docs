'<Snippet1>
' Example of the Decimal.ToOACurrency method. 
Imports System
Imports Microsoft.VisualBasic

Module DecimalToOACurrencyDemo
    
    Const dataFmt As String = "{0,31}{1,27}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Display the Decimal.ToOACurrency parameter and the result 
    ' or exception.
    Sub ShowDecimalToOACurrency( Argument As Decimal )

        ' Catch the exception if ToOACurrency( ) throws one.
        Try
            Dim oaCurrency As Long = Decimal.ToOACurrency( Argument )
            Console.WriteLine( dataFmt, Argument, _
                oaCurrency )

        Catch ex As Exception
            Console.WriteLine( dataFmt, Argument, _
                GetExceptionType( ex ) )
        End Try
    End Sub

    Sub Main( )
        Console.WriteLine( "This example of the " & _
            "Decimal.ToOACurrency( ) method generates " & vbCrLf & _
            "the following output. It displays the argument as " & _
            "a Decimal " & vbCrLf & "and the OLE Automation " & _
            "Currency value as a Long." & vbCrLf )
        Console.WriteLine( dataFmt, "Argument", _
            "OA Currency or Exception" )
        Console.WriteLine( dataFmt, "--------", _
            "------------------------" )

        ' Convert Decimal values to OLE Automation Currency values.
        ShowDecimalToOACurrency( 0D )
        ShowDecimalToOACurrency( 1D )
        ShowDecimalToOACurrency( _
            Decimal.Parse( "1.0000000000000000000000000000" ) )
        ShowDecimalToOACurrency( 100000000000000D )
        ShowDecimalToOACurrency( _
            Decimal.Parse( "100000000000000.00000000000000" ) )
        ShowDecimalToOACurrency( 10000000000000000000000000000D )
        ShowDecimalToOACurrency( 0.000000000123456789D ) 
        ShowDecimalToOACurrency( 0.123456789D ) 
        ShowDecimalToOACurrency( 123456789D ) 
        ShowDecimalToOACurrency( 123456789000000000D ) 
        ShowDecimalToOACurrency( 4294967295D ) 
        ShowDecimalToOACurrency( 18446744073709551615D ) 
        ShowDecimalToOACurrency( -79.228162514264337593543950335D ) 
        ShowDecimalToOACurrency( -79228162514264.337593543950335D ) 
    End Sub
End Module 

' This example of the Decimal.ToOACurrency( ) method generates
' the following output. It displays the argument as a Decimal
' and the OLE Automation Currency value as a Long.
' 
'                        Argument   OA Currency or Exception
'                        --------   ------------------------
'                               0                          0
'                               1                      10000
'  1.0000000000000000000000000000                      10000
'                 100000000000000        1000000000000000000
'  100000000000000.00000000000000        1000000000000000000
'   10000000000000000000000000000          OverflowException
'            0.000000000123456789                          0
'                     0.123456789                       1235
'                       123456789              1234567890000
'              123456789000000000          OverflowException
'                      4294967295             42949672950000
'            18446744073709551615          OverflowException
' -79.228162514264337593543950335                    -792282
' -79228162514264.337593543950335        -792281625142643376
'</Snippet1>