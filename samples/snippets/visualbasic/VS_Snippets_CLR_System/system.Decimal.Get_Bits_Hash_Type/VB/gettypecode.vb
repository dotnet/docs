'<Snippet3>
' Example of the Decimal.GetTypeCode method. 
Imports System
Imports Microsoft.VisualBasic

Module DecimalGetTypeCodeDemo
    
    Sub Main( )
        Console.WriteLine( "This example of the " & _
            "Decimal.GetTypeCode( ) " & vbCrLf & "method " & _
            "generates the following output." & vbCrLf )

        ' Create a Decimal object and get its type code.
        Dim aDecimal    As Decimal  = New Decimal( 1.0 )
        Dim typCode     As TypeCode = aDecimal.GetTypeCode( )

        Console.WriteLine( "Type Code:      ""{0}""", typCode )
        Console.WriteLine( "Numeric value:  {0}", CInt( typCode ) )
    End Sub
End Module 

' This example of the Decimal.GetTypeCode( )
' method generates the following output.
' 
' Type Code:      "Decimal"
' Numeric value:  15
'</Snippet3>