        ' English (US) format.
        Dim TestDate As DateTime = #3/12/1999#

        ' FormatDateTime returns "Friday, March 12, 1999".
        ' The time information is neutral (00:00:00) and therefore suppressed.
        Dim TestString As String = FormatDateTime(TestDate, DateFormat.LongDate)