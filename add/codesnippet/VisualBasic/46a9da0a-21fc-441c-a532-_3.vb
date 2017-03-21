        Dim date2Entered As String = InputBox("Enter a date")

        Try
            Dim date2 As Date = Date.Parse(date2Entered)
            Dim date1 As Date = Now

            ' Determine the number of days between the two dates.
            Dim days As Long = DateDiff(DateInterval.Day, date1, date2)

            ' This statement has a string interval argument, and
            ' is equivalent to the above statement.
            'Dim days As Long = DateDiff("d", date1, date2)

            MessageBox.Show("Days from today: " & days.ToString)
        Catch ex As Exception
            MessageBox.Show("Invalid Date: " & ex.Message)
        End Try