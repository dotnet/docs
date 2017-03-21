
    ' Computes a week one month from today.
    Private Sub ShowAWeeksVacationOneMonthFromToday()
         
        Dim today As Date = monthCalendar1.TodayDate
        Dim vacationMonth As Integer = today.Month + 1
        Dim vacationYear As Integer = today.Year
        If (today.Month = 12) Then
            vacationYear += 1
            vacationMonth = 1
        End If

        Me.monthCalendar1.SelectionStart = _
            New Date(vacationYear, vacationMonth, today.Day - 1)
        Me.monthCalendar1.SelectionEnd = _
            New Date(vacationYear, vacationMonth, today.Day + 6)
    End Sub