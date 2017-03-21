      Dim dateWithoutOffset As Date = #07/16/2007 1:32PM#
      Dim timeFromTicks As New DateTimeOffset(datewithoutOffset.Ticks, _
                               New TimeSpan(-5, 0, 0))
      Console.WriteLine(timeFromTicks.ToString())
      ' The code produces the following output:
      '    7/16/2007 1:32:00 PM -05:00