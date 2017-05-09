'<Snippet1>
' Example of the TimeSpan.CompareTo( Object ) and 
' TimeSpan.Equals( Object ) methods.
Imports System
Imports Microsoft.VisualBasic

Module TSCompToEqualsObjDemo
    
    ' Compare the TimeSpan to the Object parameters, 
    ' and display the Object parameters with the results.
    Sub CompTimeSpanToObject( Left as TimeSpan, Right as Object, _
        RightText as String )

        Console.WriteLine( "{0,-33}{1}", "Object: " & RightText, _
            Right )
        Console.WriteLine( "{0,-33}{1}", "Left.Equals( Object )", _
            Left.Equals( Right ) )
        Console.Write( "{0,-33}", "Left.CompareTo( Object )" )

        ' Catch the exception if CompareTo( ) throws one.
        Try
            Console.WriteLine( "{0}" & vbCrLf, _
                Left.CompareTo( Right ) )
        Catch ex As Exception
            Console.WriteLine( "Error: {0}" & vbCrLf, ex.Message )
        End Try
    End Sub

    Sub Main( )
        Dim Left as new TimeSpan( 0, 5, 0 )

        Console.WriteLine( _
            "This example of the TimeSpan.Equals( Object ) " & _
            "and " & vbCrLf & "TimeSpan.CompareTo( Object ) " & _
            "methods generates the " & vbCrLf & _
            "following output by creating several " & _
            "different TimeSpan " & vbCrLf & "objects and " & _
            "comparing them with a 5-minute TimeSpan." & vbCrLf )
        Console.WriteLine( "{0,-33}{1}" & vbCrLf, _
            "Left: TimeSpan( 0, 5, 0 )", Left )

        ' Create objects to compare with a 5-minute TimeSpan.
        CompTimeSpanToObject( Left, new TimeSpan( 0, 0, 300 ), _
            "TimeSpan( 0, 0, 300 )" )
        CompTimeSpanToObject( Left, new TimeSpan( 0, 5, 1 ), _
            "TimeSpan( 0, 5, 1 )" )
        CompTimeSpanToObject( Left, new TimeSpan( 0, 5, -1 ), _
            "TimeSpan( 0, 5, -1 )" )
        CompTimeSpanToObject( Left, new TimeSpan( 3000000000 ), _
            "TimeSpan( 3000000000 )" )
        CompTimeSpanToObject( Left, 3000000000L, "Long 3000000000L" )
        CompTimeSpanToObject( Left, "00:05:00", _
            "String ""00:05:00""" )
    End Sub
End Module 

' This example of the TimeSpan.Equals( Object ) and
' TimeSpan.CompareTo( Object ) methods generates the
' following output by creating several different TimeSpan
' objects and comparing them with a 5-minute TimeSpan.
' 
' Left: TimeSpan( 0, 5, 0 )        00:05:00
' 
' Object: TimeSpan( 0, 0, 300 )    00:05:00
' Left.Equals( Object )            True
' Left.CompareTo( Object )         0
' 
' Object: TimeSpan( 0, 5, 1 )      00:05:01
' Left.Equals( Object )            False
' Left.CompareTo( Object )         -1
' 
' Object: TimeSpan( 0, 5, -1 )     00:04:59
' Left.Equals( Object )            False
' Left.CompareTo( Object )         1
' 
' Object: TimeSpan( 3000000000 )   00:05:00
' Left.Equals( Object )            True
' Left.CompareTo( Object )         0
' 
' Object: Long 3000000000L         3000000000
' Left.Equals( Object )            False
' Left.CompareTo( Object )         Error: Object must be of type TimeSpan.
' 
' Object: String "00:05:00"        00:05:00
' Left.Equals( Object )            False
' Left.CompareTo( Object )         Error: Object must be of type TimeSpan.
'</Snippet1>