'<Snippet1>
' Example of the Decimal.CompareTo and Decimal.Equals instance methods.
Imports System
Imports Microsoft.VisualBasic

Module DecCompToEqualsObjDemo
    
    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Compare the Decimal to the Object parameters, 
    ' and display the Object parameters with the results.
    Sub CompDecimalToObject( Left as Decimal, Right as Object, _
        RightText as String )

        Console.WriteLine( "{0,-46}{1}", "Object: " & RightText, _
            Right )
        Console.WriteLine( "{0,-46}{1}", "Left.Equals( Object )", _
            Left.Equals( Right ) )
        Console.Write( "{0,-46}", "Left.CompareTo( Object )" )

        ' Catch the exception if CompareTo( ) throws one.
        Try
            Console.WriteLine( "{0}" & vbCrLf, _
                Left.CompareTo( Right ) )
        Catch ex As Exception
            Console.WriteLine( "{0}" & vbCrLf, _
                GetExceptionType( ex ) )
        End Try
    End Sub

    Sub Main( )
        Console.WriteLine( _
            "This example of the Decimal.Equals( Object ) " & _
            "and " & vbCrLf & "Decimal.CompareTo( Object ) " & _
            "methods generates the " & vbCrLf & _
            "following output. It creates several different " & _
            "Decimal " & vbCrLf & "values and compares them " & _
            "with the following reference value." & vbCrLf )

        ' Create a reference Decimal value.
        Dim Left as New Decimal( 987.654 )

        Console.WriteLine( "{0,-46}{1}" & vbCrLf, _
            "Left: Decimal( 987.654 )", Left )

        ' Create objects to compare with the reference.
        CompDecimalToObject( Left, New Decimal( 9.8765400E+2 ), _
            "Decimal( 9.8765400E+2 )" )
        CompDecimalToObject( Left, 987.6541D, "987.6541D" )
        CompDecimalToObject( Left, 987.6539D, "987.6539D" )
        CompDecimalToObject( Left, _
            New Decimal( 987654000, 0, 0, false, 6 ), _
            "Decimal( 987654000, 0, 0, false, 6 )" )
        CompDecimalToObject( Left, 9.8765400E+2, _
            "Double 9.8765400E+2" )
        CompDecimalToObject( Left, "987.654", _
            "String ""987.654""" )
    End Sub
End Module 

' This example of the Decimal.Equals( Object ) and
' Decimal.CompareTo( Object ) methods generates the
' following output. It creates several different Decimal
' values and compares them with the following reference value.
' 
' Left: Decimal( 987.654 )                      987.654
' 
' Object: Decimal( 9.8765400E+2 )               987.654
' Left.Equals( Object )                         True
' Left.CompareTo( Object )                      0
' 
' Object: 987.6541D                             987.6541
' Left.Equals( Object )                         False
' Left.CompareTo( Object )                      -1
' 
' Object: 987.6539D                             987.6539
' Left.Equals( Object )                         False
' Left.CompareTo( Object )                      1
' 
' Object: Decimal( 987654000, 0, 0, false, 6 )  987.654000
' Left.Equals( Object )                         True
' Left.CompareTo( Object )                      0
' 
' Object: Double 9.8765400E+2                   987.654
' Left.Equals( Object )                         False
' Left.CompareTo( Object )                      ArgumentException
' 
' Object: String "987.654"                      987.654
' Left.Equals( Object )                         False
' Left.CompareTo( Object )                      ArgumentException
'</Snippet1>