'<Snippet2>
' Example of the TimeSpan( Integer, Integer, Integer ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module TimeSpanCtorIIIDemo

    ' Create a TimeSpan object and display its value.
    Sub CreateTimeSpan( hours As Integer, minutes As Integer, _
        seconds As Integer )

        Dim elapsedTime As New TimeSpan( hours, minutes, seconds )

        ' Format the constructor for display.
        Dim ctor AS String = _
            String.Format( "TimeSpan( {0}, {1}, {2} )", _
                hours, minutes, seconds )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-37}{1,16}", _
            ctor, elapsedTime.ToString( ) )
    End Sub
    
    Sub Main()

        Console.WriteLine( _
            "This example of the " & _
            "TimeSpan( Integer, Integer, Integer ) " & vbCrLf & _
            "constructor generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-37}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-37}{1,16}", "-----------", "-----" )

        CreateTimeSpan( 10, 20, 30 )
        CreateTimeSpan( -10, 20, 30 )
        CreateTimeSpan( 0, 0, 37230 )
        CreateTimeSpan( 1000, 2000, 3000 )
        CreateTimeSpan( 1000, -2000, -3000 )
        CreateTimeSpan( 999999, 999999, 999999 )
    End Sub 
End Module 

' This example of the TimeSpan( Integer, Integer, Integer )
' constructor generates the following output.
' 
' Constructor                                     Value
' -----------                                     -----
' TimeSpan( 10, 20, 30 )                       10:20:30
' TimeSpan( -10, 20, 30 )                     -09:39:30
' TimeSpan( 0, 0, 37230 )                      10:20:30
' TimeSpan( 1000, 2000, 3000 )              43.02:10:00
' TimeSpan( 1000, -2000, -3000 )            40.05:50:00
' TimeSpan( 999999, 999999, 999999 )     42372.15:25:39
'</Snippet2>