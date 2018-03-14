        Dim aDate As Date
        Dim aString As String
        ' The following line of code generates a COMPILER ERROR because of invalid format.
        ' aDate = #February 12, 1969 00:00:00#
        ' Date literals must be in the format #m/d/yyyy# or they are invalid.
        ' The following line of code sets the time component of aDate to midnight.
        aDate = #2/12/1969#
        ' The following conversion suppresses the neutral time value of 00:00:00.
        ' The following line of code sets aString to "2/12/1969".
        aString = CStr(aDate)
        ' The following line of code sets the time component of aDate to one second past midnight.
        aDate = #2/12/1969 12:00:01 AM#
        ' The time component becomes part of the converted value.
        ' The following line of code sets aString to "2/12/1969 12:00:01 AM".
        aString = CStr(aDate)