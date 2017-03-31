'<Snippet1>
' Example of the TimeSpan( Long ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module TimeSpanCtorLDemo

    ' Create a TimeSpan object and display its value.
    Sub CreateTimeSpan( ticks As Long )

        Dim elapsedTime As New TimeSpan( ticks )

        ' Format the constructor for display.
        Dim ctor AS String = _
            String.Format( "TimeSpan( {0} )", ticks )

        ' Pad the end of a TimeSpan string with spaces if
        ' it does not contain milliseconds.
        Dim elapsedStr As String = elapsedTime.ToString( )
        Dim pointIndex  As Integer = elapsedStr.IndexOf( ":"c )

        pointIndex = elapsedStr.IndexOf( "."c, pointIndex )
        If pointIndex < 0 Then elapsedStr &= "        "

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-33}{1,24}", ctor, elapsedStr )
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the TimeSpan( Long ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-33}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-33}{1,16}", "-----------", "-----" )

        CreateTimeSpan( 1 )                
        CreateTimeSpan( 999999 )                
        CreateTimeSpan( -1000000000000 )        
        CreateTimeSpan( 18012202000000 )        
        CreateTimeSpan( 999999999999999999 )    
        CreateTimeSpan( 1000000000000000000 )   

    End Sub 
End Module 

' This example of the TimeSpan( Long ) constructor
' generates the following output.
' 
' Constructor                                 Value
' -----------                                 -----
' TimeSpan( 1 )                            00:00:00.0000001
' TimeSpan( 999999 )                       00:00:00.0999999
' TimeSpan( -1000000000000 )            -1.03:46:40
' TimeSpan( 18012202000000 )            20.20:20:20.2000000
' TimeSpan( 999999999999999999 )   1157407.09:46:39.9999999
' TimeSpan( 1000000000000000000 )  1157407.09:46:40
'</Snippet1>