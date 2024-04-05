' Visual Basic .NET Document
Option Strict On

Module Example1
    Public Sub Main()
        Implicit()
        Console.WriteLine()
        Explicit()
        Console.WriteLine()
        TimeSpanOperation()
        Console.WriteLine()
        Parse()
        Console.WriteLine()
    End Sub

    Private Sub Implicit()
        ' <Snippet2>
        Dim interval As New TimeSpan()
        Console.WriteLine(interval.Equals(TimeSpan.Zero))     ' Displays "True".
        ' </Snippet2>
    End Sub

    Private Sub Explicit()
        ' <Snippet3>
        Dim interval As New TimeSpan(2, 14, 18)
        Console.WriteLine(interval.ToString())                ' Displays "02:14:18".
        ' </Snippet3>
    End Sub

    Private Sub TimeSpanOperation()
        ' <Snippet4>
        Dim departure As DateTime = #06/12/2010 6:32PM#
        Dim arrival As DateTime = #06/13/2010 10:47PM#
        Dim travelTime As TimeSpan = arrival - departure
        Console.WriteLine("{0} - {1} = {2}", arrival, departure, travelTime)
        ' The example displays the following output:
        '       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00
        ' </Snippet4>
    End Sub

    Private Sub Parse()
        ' <Snippet5>
        Dim values() As String = {"12", "31.", "5.8:32:16", "12:12:15.95", ".12"}
        For Each value As String In values
            Try
                Dim ts As TimeSpan = TimeSpan.Parse(value)
                Console.WriteLine("'{0}' --> {1}", value, ts)
            Catch e As FormatException
                Console.WriteLine("Unable to parse '{0}'", value)
            Catch e As OverflowException
                Console.WriteLine("'{0}' is outside the range of a TimeSpan.", value)
            End Try
        Next
        ' The example displays the following output:
        '       '12' --> 12.00:00:00
        '       Unable to parse '31.'
        '       '5.8:32:16' --> 5.08:32:16
        '       '12:12:15.95' --> 12:12:15.9500000
        '       Unable to parse '.12'  
        ' </Snippet5>    
    End Sub
End Module

' 02:10:21
' 
' 22:26:43
