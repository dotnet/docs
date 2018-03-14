'<Snippet2>
' Example of the Decimal.Compare and static Decimal.Equals methods.
Imports System
Imports Microsoft.VisualBasic

Module DecCompareEqualsDemo
    
    Const dataFmt As String = "{0,-45}{1}"

    ' Compare Decimal parameters, and display them with the results.
    Sub CompareDecimals( Left as Decimal, Right as Decimal, _
        RightText as String )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "Right: " & RightText, Right )
        Console.WriteLine( dataFmt, "Decimal.Equals( Left, Right )", _
            Decimal.Equals( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "Decimal.Compare( Left, Right )", _
            Decimal.Compare( Left, Right ) )
    End Sub

    Sub Main( )
        Console.WriteLine( _
            "This example of the Decimal.Equals( Decimal, " & _
            "Decimal ) and " & vbCrLf & "Decimal.Compare( " & _
            "Decimal, Decimal ) methods generates the " & vbCrLf & _
            "following output. It creates several different " & _
            "Decimal " & vbCrLf & "values and compares them " & _
            "with the following reference value." & vbCrLf )

        ' Create a reference Decimal value.
        Dim Left as New Decimal( 123.456 )

        Console.WriteLine( dataFmt, "Left: Decimal( 123.456 )", Left )

        ' Create Decimal values to compare with the reference.
        CompareDecimals( Left, New Decimal( 1.2345600E+2 ), _
            "Decimal( 1.2345600E+2 )" )
        CompareDecimals( Left, 123.4561D, "123.4561D" )
        CompareDecimals( Left, 123.4559D, "123.4559D" )
        CompareDecimals( Left, 123.456000D, "123.456000D" )
        CompareDecimals( Left, _
            New Decimal( 123456000, 0, 0, false, 6 ), _
            "Decimal( 123456000, 0, 0, false, 6 )" )
    End Sub 
End Module 

' This example of the Decimal.Equals( Decimal, Decimal ) and
' Decimal.Compare( Decimal, Decimal ) methods generates the
' following output. It creates several different Decimal
' values and compares them with the following reference value.
' 
' Left: Decimal( 123.456 )                     123.456
' 
' Right: Decimal( 1.2345600E+2 )               123.456
' Decimal.Equals( Left, Right )                True
' Decimal.Compare( Left, Right )               0
' 
' Right: 123.4561D                             123.4561
' Decimal.Equals( Left, Right )                False
' Decimal.Compare( Left, Right )               -1
' 
' Right: 123.4559D                             123.4559
' Decimal.Equals( Left, Right )                False
' Decimal.Compare( Left, Right )               1
' 
' Right: 123.456000D                           123.456
' Decimal.Equals( Left, Right )                True
' Decimal.Compare( Left, Right )               0
' 
' Right: Decimal( 123456000, 0, 0, false, 6 )  123.456000
' Decimal.Equals( Left, Right )                True
' Decimal.Compare( Left, Right )               0
'</Snippet2>