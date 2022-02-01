Option Strict On
Option Infer On

Module Module1
    Sub Main()
        UseUnNamedTuple()
        Console.WriteLine()
        UseNamedTuple()
        Console.WriteLine()
        NamedTupleDeclaration()
        Console.WriteLine()
        Console.WriteLine()
        Console.Write("Press <Enter> to exit... ")
        Console.ReadLine()
    End Sub

    Private Sub UseUnNamedTuple()
        ' <Snippet1>
        Dim holiday = (#07/04/2017#, "Independence Day", True)
        ' </Snippet1>
        ' <Snippet2>
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        ' </Snippet2>
        ' <Snippet3>
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Snippet3> 
    End Sub

    Private Sub UseNamedTuple()
        ' <Snippet4>
        Dim holiday = (EventDate:=#07/04/2017#, Name:="Independence Day", IsHoliday:=True)
        Console.WriteLine($"{holiday.EventDate} Is {holiday.Name}" +
                          $"{If(holiday.IsHoliday, ", a national holiday", String.Empty)}")
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' The example displays the following output:
        '   7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        '   1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Snippet4>
    End Sub

    Private Sub NamedTupleDeclaration()
        '<Snippet5>
        Dim holiday As (EventDate As Date, Name As String, IsHoliday As Boolean) =
            (#07/04/2017#, "Independence Day", True)
        Console.WriteLine(holiday.Name)
        ' Output: Independence Day
        '</Snippet5>

        '<Snippet6>
        Dim events As New List(Of (EventDate As Date, Name As String, IsHoliday As Boolean)) From {
            (#07/04/2017#, "Independence Day", True),
            (#04/22/2017#, "Earth Day", False)
        }
        Console.WriteLine(events(1).IsHoliday)
        ' Output: False
        '</Snippet6>
    End Sub
End Module
