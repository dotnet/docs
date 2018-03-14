'<Snippet1>
' Example of the Decimal( Integer( ) ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorIArrDemo

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( ByVal bits( ) As Integer )

        ' Format and save the constructor.
        Dim ctor As String = String.Format( "Decimal( {{ &H{0:X}", bits( 0 ) )
        Dim valOrExc As String
        Dim index As Integer
        For index = 1 to bits.Length - 1
            ctor &= String.Format( ", &H{0:X}", bits( index ) )
        Next index
        ctor &= " } )"

        ' Construct the Decimal value.
        Try
            Dim decimalNum As New Decimal( bits )

            ' Format the Decimal value for display.
            valOrExc = decimalNum.ToString( )

        ' Save the exception type if an exception was thrown.
        Catch ex As Exception
            valOrExc =  GetExceptionType( ex ) 
        End Try

        ' Display the constructor and Decimal value or exception.
        Dim ctorLen As Integer = 76 - valOrExc.Length
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

        Console.WriteLine( "This example of the " & _
            "Decimal( Integer( ) ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-38}{1,38}", "Constructor", _
            "Value or Exception" )
        Console.WriteLine( "{0,-38}{1,38}", "-----------", _
            "------------------" )

        ' Construct Decimal objects from Integer arrays.
        CreateDecimal( New Integer( ) { 0, 0, 0, 0 } )
        CreateDecimal( New Integer( ) { 0, 0, 0 } )
        CreateDecimal( New Integer( ) { 0, 0, 0, 0, 0 } )
        CreateDecimal( New Integer( ) { 1000000000, 0, 0, 0 } )
        CreateDecimal( New Integer( ) { 0, 1000000000, 0, 0 } )
        CreateDecimal( New Integer( ) { 0, 0, 1000000000, 0 } )
        CreateDecimal( New Integer( ) { 0, 0, 0, 1000000000 } )
        CreateDecimal( New Integer( ) { -1, -1, -1, 0 } )
        CreateDecimal( New Integer( ) { -1, -1, -1, &H80000000 } )
        CreateDecimal( New Integer( ) { -1, 0, 0, &H100000 } )
        CreateDecimal( New Integer( ) { -1, 0, 0, &H1C0000 } )
        CreateDecimal( New Integer( ) { -1, 0, 0, &H1D0000 } )
        CreateDecimal( New Integer( ) { -1, 0, 0, &H1C0001 } )
        CreateDecimal( New Integer( ) _
            { &HF0000, &HF0000, &HF0000, &HF0000 } )
    End Sub 
End Module 

' This example of the Decimal( Integer( ) ) constructor
' generates the following output.
' 
' Constructor                                               Value or Exception
' -----------                                               ------------------
' Decimal( { &H0, &H0, &H0, &H0 } )                                          0
' Decimal( { &H0, &H0, &H0 } )                               ArgumentException
' Decimal( { &H0, &H0, &H0, &H0, &H0 } )                     ArgumentException
' Decimal( { &H3B9ACA00, &H0, &H0, &H0 } )                          1000000000
' Decimal( { &H0, &H3B9ACA00, &H0, &H0 } )                 4294967296000000000
' Decimal( { &H0, &H0, &H3B9ACA00, &H0 } )       18446744073709551616000000000
' Decimal( { &H0, &H0, &H0, &H3B9ACA00 } )                   ArgumentException
' Decimal( { &HFFFFFFFF, &HFFFFFFFF, &HFFFFFFFF, &H0 } )
'                                                79228162514264337593543950335
' Decimal( { &HFFFFFFFF, &HFFFFFFFF, &HFFFFFFFF, &H80000000 } )
'                                               -79228162514264337593543950335
' Decimal( { &HFFFFFFFF, &H0, &H0, &H100000 } )             0.0000004294967295
' Decimal( { &HFFFFFFFF, &H0, &H0, &H1C0000 } ) 0.0000000000000000004294967295
' Decimal( { &HFFFFFFFF, &H0, &H0, &H1D0000 } )              ArgumentException
' Decimal( { &HFFFFFFFF, &H0, &H0, &H1C0001 } )              ArgumentException
' Decimal( { &HF0000, &HF0000, &HF0000, &HF0000 } )
'                                                  18133887298.441562272235520
'</Snippet1>