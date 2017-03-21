        Dim year As Long = 1984
        ' Assume the value of year is provided by data or by user input.
        Dim decade As String
        decade = Partition(year, 1950, 2049, 10)
        MsgBox("Year " & CStr(year) & " is in decade " & decade & ".")