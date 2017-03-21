    Protected Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim currentDay As Integer = Calendar1.VisibleDate.Day
        Dim currentMonth As Integer = Calendar1.VisibleDate.Month
        Dim currentYear As Integer = Calendar1.VisibleDate.Year
        Calendar1.SelectedDates.Clear()
        
        ' Loop through current month and add all Wednesdays to the collection.
        Dim i As Integer
        For i = 1 To System.DateTime.DaysInMonth(currentYear, currentMonth)
            Dim targetDate As New DateTime(currentYear, currentMonth, i)
            If targetDate.DayOfWeek = DayOfWeek.Wednesday Then
                Calendar1.SelectedDates.Add(targetDate)
            End If
        Next i
        TextView1.Text = "Selection Count = " & Calendar1.SelectedDates.Count.ToString()
    End Sub