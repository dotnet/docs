        Dim TestDateTime As Date = #1/27/2001 5:04:23 PM#
        Dim TestStr As String
        ' Returns current system time in the system-defined long time format.
        TestStr = Format(Now(), "Long Time")
        ' Returns current system date in the system-defined long date format.
        TestStr = Format(Now(), "Long Date")
        ' Also returns current system date in the system-defined long date 
        ' format, using the single letter code for the format.
        TestStr = Format(Now(), "D")

        ' Returns the value of TestDateTime in user-defined date/time formats.
        ' Returns "5:4:23".
        TestStr = Format(TestDateTime, "h:m:s")
        ' Returns "05:04:23 PM".
        TestStr = Format(TestDateTime, "hh:mm:ss tt")
        ' Returns "Saturday, Jan 27 2001".
        TestStr = Format(TestDateTime, "dddd, MMM d yyyy")
        ' Returns "17:04:23".
        TestStr = Format(TestDateTime, "HH:mm:ss")
        ' Returns "23".
        TestStr = Format(23)

        ' User-defined numeric formats.
        ' Returns "5,459.40".
        TestStr = Format(5459.4, "##,##0.00")
        ' Returns "334.90".
        TestStr = Format(334.9, "###0.00")
        ' Returns "500.00%".
        TestStr = Format(5, "0.00%")