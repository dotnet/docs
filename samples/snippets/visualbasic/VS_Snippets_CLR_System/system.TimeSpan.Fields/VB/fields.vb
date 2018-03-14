'<Snippet1>
' Example of the TimeSpan fields.
Imports System
Imports Microsoft.VisualBasic

Module TimeSpanFieldsDemo
    
    ' Pad the end of a TimeSpan string with spaces if it does not 
    ' contain milliseconds.
    Function Align( interval As TimeSpan ) As String

        Dim intervalStr As String = interval.ToString( )
        Dim pointIndex  As Integer = intervalStr.IndexOf( ":"c )

        pointIndex = intervalStr.IndexOf( "."c, pointIndex )
        If pointIndex < 0 Then intervalStr &= "        "
        Align = intervalStr
    End Function
    
    Sub Main( )

        Const numberFmt As String = "{0,-22}{1,18:N0}"
        Const timeFmt As String = "{0,-22}{1,26}"

        Console.WriteLine( _
            "This example of the fields of the TimeSpan class" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( numberFmt, "Field", "Value" )
        Console.WriteLine( numberFmt, "-----", "-----" )

        ' Display the maximum, minimum, and zero TimeSpan values.
        Console.WriteLine( timeFmt, "Maximum TimeSpan", _
            Align( TimeSpan.MaxValue ) )
        Console.WriteLine( timeFmt, "Minimum TimeSpan", _
            Align( TimeSpan.MinValue ) )
        Console.WriteLine( timeFmt, "Zero TimeSpan", _
            Align( TimeSpan.Zero ) )
        Console.WriteLine( )

        ' Display the ticks-per-time-unit fields.
        Console.WriteLine( numberFmt, "Ticks per day", _
            TimeSpan.TicksPerDay )
        Console.WriteLine( numberFmt, "Ticks per hour", _
            TimeSpan.TicksPerHour )
        Console.WriteLine( numberFmt, "Ticks per minute", _
            TimeSpan.TicksPerMinute )
        Console.WriteLine( numberFmt, "Ticks per second", _
            TimeSpan.TicksPerSecond )
        Console.WriteLine( numberFmt, "Ticks per millisecond", _
            TimeSpan.TicksPerMillisecond )
    End Sub 
End Module 

' This example of the fields of the TimeSpan class
' generates the following output.
' 
' Field                              Value
' -----                              -----
' Maximum TimeSpan       10675199.02:48:05.4775807
' Minimum TimeSpan      -10675199.02:48:05.4775808
' Zero TimeSpan                   00:00:00
' 
' Ticks per day            864,000,000,000
' Ticks per hour            36,000,000,000
' Ticks per minute             600,000,000
' Ticks per second              10,000,000
' Ticks per millisecond             10,000
'</Snippet1>