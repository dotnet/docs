'<Snippet2>
' Example of the Decimal( Integer, Integer, Integer, Boolean, Byte ) 
' constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorIIIBByDemo

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( low As Integer, mid As Integer, _
        high As Integer, isNeg As Boolean, scale as Byte )

        ' Format the constructor for display.
        Dim ctor As String = String.Format( _
            "Decimal( {0}, {1}, {2}, {3}, {4} )", _
            low, mid, high, isNeg, scale )
        Dim valOrExc As String

        ' Construct the Decimal value.
        Try
            Dim decimalNum As New Decimal( _
                low, mid, high, isNeg, scale )

            ' Format and save the Decimal value.
            valOrExc = decimalNum.ToString( )

        ' Save the exception type if an exception was thrown.
        Catch ex As Exception
            valOrExc =  GetExceptionType( ex ) 
        End Try

        ' Display the constructor and Decimal value or exception.
        Dim ctorLen = 76 - valOrExc.Length
        If ctorLen > ctor.Length Then

            ' Display the data on one line if it will fit.
            Console.WriteLine( "{0}{1}", ctor.PadRight( ctorLen ), _
                valOrExc )

        ' Otherwise, display the data on two lines.
        Else
            Console.WriteLine( "{0}", ctor )
            Console.WriteLine( "{0,76}", valOrExc )
        End If
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( Integer, Integer, " & _
            "Integer, Boolean, Byte ) " & vbCrLf & "constructor " & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-38}{1,38}", "Constructor", _
            "Value or Exception" )
        Console.WriteLine( "{0,-38}{1,38}", "-----------", _
            "------------------" )

        ' Construct Decimal objects from the component fields.
        CreateDecimal( 0, 0, 0, False, 0 )                
        CreateDecimal( 0, 0, 0, False, 27 )                
        CreateDecimal( 0, 0, 0, True, 0 )                
        CreateDecimal( 1000000000, 0, 0, False, 0 )                
        CreateDecimal( 0, 1000000000, 0, False, 0 )                
        CreateDecimal( 0, 0, 1000000000, False, 0 )                
        CreateDecimal( 1000000000, 1000000000, 1000000000, False, 0 )
        CreateDecimal( -1, -1, -1, False, 0 )                
        CreateDecimal( -1, -1, -1, True, 0 )                
        CreateDecimal( -1, -1, -1, False, 15 )                
        CreateDecimal( -1, -1, -1, False, 28 )                
        CreateDecimal( -1, -1, -1, False, 29 )                
        CreateDecimal( Integer.MaxValue, 0, 0, False, 18 )                
        CreateDecimal( Integer.MaxValue, 0, 0, False, 28 )                
        CreateDecimal( Integer.MaxValue, 0, 0, True, 28 )                
    End Sub 
End Module 

' This example of the Decimal( Integer, Integer, Integer, Boolean, Byte )
' constructor generates the following output.
' 
' Constructor                                               Value or Exception
' -----------                                               ------------------
' Decimal( 0, 0, 0, False, 0 )                                               0
' Decimal( 0, 0, 0, False, 27 )                                              0
' Decimal( 0, 0, 0, True, 0 )                                                0
' Decimal( 1000000000, 0, 0, False, 0 )                             1000000000
' Decimal( 0, 1000000000, 0, False, 0 )                    4294967296000000000
' Decimal( 0, 0, 1000000000, False, 0 )          18446744073709551616000000000
' Decimal( 1000000000, 1000000000, 1000000000, False, 0 )
'                                                18446744078004518913000000000
' Decimal( -1, -1, -1, False, 0 )                79228162514264337593543950335
' Decimal( -1, -1, -1, True, 0 )                -79228162514264337593543950335
' Decimal( -1, -1, -1, False, 15 )              79228162514264.337593543950335
' Decimal( -1, -1, -1, False, 28 )              7.9228162514264337593543950335
' Decimal( -1, -1, -1, False, 29 )                 ArgumentOutOfRangeException
' Decimal( 2147483647, 0, 0, False, 18 )                  0.000000002147483647
' Decimal( 2147483647, 0, 0, False, 28 )        0.0000000000000000002147483647
' Decimal( 2147483647, 0, 0, True, 28 )        -0.0000000000000000002147483647
'</Snippet2>