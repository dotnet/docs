Partial Public Class Window1

    Public Sub New()
        InitializeComponent()

        '<Snippet1> 

        '<Snippet2> 
        ' Create a Calendar that displays 1/10/2009 
        ' through 4/18/2009. 
        Dim basicCalendar As New Calendar()
        basicCalendar.DisplayDateStart = New DateTime(2009, 1, 10)
        basicCalendar.DisplayDateEnd = New DateTime(2009, 4, 18)
        basicCalendar.DisplayDate = New DateTime(2009, 3, 15)
        basicCalendar.SelectedDate = New DateTime(2009, 2, 15)

        ' root is a Panel that is defined elswhere. 
        root.Children.Add(basicCalendar)
        '</Snippet2> 

        '<Snippet3> 
        ' Create a Calendar that displays dates through 
        ' Januarary 31, 2009 and has dates that are not selectable. 
        Dim calendarWithBlackoutDates As New Calendar()
        calendarWithBlackoutDates.IsTodayHighlighted = False
        calendarWithBlackoutDates.DisplayDate = New DateTime(2009, 1, 1)
        calendarWithBlackoutDates.DisplayDateEnd = New DateTime(2009, 1, 31)
        calendarWithBlackoutDates.SelectionMode = CalendarSelectionMode.MultipleRange

        ' Add the dates that are not selectable. 
        calendarWithBlackoutDates.BlackoutDates.Add(New CalendarDateRange(New DateTime(2009, 1, 2), New DateTime(2009, 1, 4)))
        calendarWithBlackoutDates.BlackoutDates.Add(New CalendarDateRange(New DateTime(2009, 1, 9)))
        calendarWithBlackoutDates.BlackoutDates.Add(New CalendarDateRange(New DateTime(2009, 1, 16)))
        calendarWithBlackoutDates.BlackoutDates.Add(New CalendarDateRange(New DateTime(2009, 1, 23), New DateTime(2009, 1, 25)))
        calendarWithBlackoutDates.BlackoutDates.Add(New CalendarDateRange(New DateTime(2009, 1, 30)))

        ' Add the selected dates. 
        calendarWithBlackoutDates.SelectedDates.Add(New DateTime(2009, 1, 5))
        calendarWithBlackoutDates.SelectedDates.AddRange(New DateTime(2009, 1, 12), New DateTime(2009, 1, 15))
        calendarWithBlackoutDates.SelectedDates.Add(New DateTime(2009, 1, 27))

        ' root is a Panel that is defined elswhere. 
        root.Children.Add(calendarWithBlackoutDates)
        '</Snippet3> 

        '</Snippet1> 

        '<Snippet4> 
        Dim yearCalendar As New Calendar()
        yearCalendar.DisplayMode = CalendarMode.Year
        AddHandler yearCalendar.DisplayModeChanged, AddressOf Calendar_DisplayModeChanged

        ' root is a Panel that is defined elswhere. 
        root.Children.Add(yearCalendar)
        '</Snippet4> 

    End Sub

    '<Snippet5> 
    Private Sub Calendar_DisplayModeChanged(ByVal sender As Object, ByVal e As CalendarModeChangedEventArgs)
        Dim calObj As Calendar = TryCast(sender, Calendar)

        calObj.DisplayMode = CalendarMode.Year
    End Sub

    '<Snippet7>
    Private Sub calendar1_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim cal = TryCast(sender, Calendar)
        cal.BlackoutDates.AddDatesInPast()
    End Sub
    '</Snippet7>

End Class
'</Snippet5> 