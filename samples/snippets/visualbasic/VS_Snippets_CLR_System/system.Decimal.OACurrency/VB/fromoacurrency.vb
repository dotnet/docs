'<Snippet2>
' Example of the Decimal.FromOACurrency method. 
Imports System
Imports Microsoft.VisualBasic

Module DecimalFromOACurrencyDemo
    
    Const dataFmt As String = "{0,21}{1,25}"

    ' Display the Decimal.FromOACurrency parameter and Decimal result.
    Sub ShowDecimalFromOACurrency( Argument As Long )

        Dim decCurrency As Decimal = _
            Decimal.FromOACurrency( Argument )

        Console.WriteLine( dataFmt, Argument, decCurrency )
    End Sub

    Sub Main( )
        Console.WriteLine( "This example of the " & _
            "Decimal.FromOACurrency( ) method generates " & vbCrLf & _
            "the following output. It displays the OLE Automation " & _
            "Currency " & vbCrLf & "value as a Long and the " & _
            "result as a Decimal." & vbCrLf )
        Console.WriteLine( dataFmt, "OA Currency", "Decimal Value" )
        Console.WriteLine( dataFmt, "-----------", "-------------" )

        ' Convert OLE Automation Currency values to Decimal objects.
        ShowDecimalFromOACurrency( 0L )
        ShowDecimalFromOACurrency( 1L )
        ShowDecimalFromOACurrency( 100000L )
        ShowDecimalFromOACurrency( 100000000000L )
        ShowDecimalFromOACurrency( 1000000000000000000L )
        ShowDecimalFromOACurrency( 1000000000000000001L )
        ShowDecimalFromOACurrency( Long.MaxValue )
        ShowDecimalFromOACurrency( Long.MinValue )
        ShowDecimalFromOACurrency( 123456789L )
        ShowDecimalFromOACurrency( 1234567890000L )
        ShowDecimalFromOACurrency( 1234567890987654321 )
        ShowDecimalFromOACurrency( 4294967295L ) 
    End Sub
End Module 

' This example of the Decimal.FromOACurrency( ) method generates
' the following output. It displays the OLE Automation Currency
' value as a Long and the result as a Decimal.
' 
'           OA Currency            Decimal Value
'           -----------            -------------
'                     0                        0
'                     1                   0.0001
'                100000                       10
'          100000000000                 10000000
'   1000000000000000000          100000000000000
'   1000000000000000001     100000000000000.0001
'   9223372036854775807     922337203685477.5807
'  -9223372036854775808    -922337203685477.5808
'             123456789               12345.6789
'         1234567890000                123456789
'   1234567890987654321     123456789098765.4321
'            4294967295              429496.7295
'</Snippet2>