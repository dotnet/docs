Option Strict On
Option Infer On

Module Module1
    Sub Main()
        UseUnNamedTuple()
        Console.WriteLine()
        UseNamedTuple()
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
                          $"{IIf(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        ' </Snippet2>
        ' <Snippet3>
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{IIf(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Snippet3> 
    End Sub

    Private Sub UseNamedTuple()
        ' <Snippet4>
        Dim holiday = (EventDate:=#07/04/2017#, Name:="Independence Day", IsHoliday:=True)
        Console.WriteLine($"{holiday.EventDate} Is {holiday.Name}" +
                          $"{IIf(holiday.IsHoliday, ", a national holiday", String.Empty)}")
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{IIf(holiday.Item3, ", a national holiday", String.Empty)}")
        ' The example displays the following output:
        '   7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        '   1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Snippet4>
    End Sub
End Module
