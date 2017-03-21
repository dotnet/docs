        ' The following statements set datTim1 to a Thursday
        ' and datTim2 to the following Tuesday.
        Dim datTim1 As Date = #1/4/2001#
        Dim datTim2 As Date = #1/9/2001#
        ' Assume Sunday is specified as first day of the week.
        Dim wD As Long = DateDiff(DateInterval.Weekday, datTim1, datTim2)
        Dim wY As Long = DateDiff(DateInterval.WeekOfYear, datTim1, datTim2)